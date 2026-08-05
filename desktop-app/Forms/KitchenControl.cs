using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ArayuzProject.Controls
{
    public partial class KitchenControl : UserControl
    {
        private const string RoomName = "kitchen";
        private const string DefaultPortName = "COM3";
        private const int BaudRate = 115200;

        private readonly string connectionString =
            @"Data Source=YOUR_SERVER_NAME;
              Initial Catalog=arayuz;
              Integrated Security=True;
              Encrypt=False";

        private SerialPort serialPort;
        private Timer measurementTimer;
        private Timer clockTimer;

        public KitchenControl()
        {
            InitializeComponent();

            InitializeClockTimer();
            InitializeSerialPort();
            InitializeMeasurementTimer();

            ShowCurrentDate();
            LoadTemperatureData();
        }

        private void InitializeSerialPort()
        {
            serialPort = new SerialPort
            {
                PortName = DefaultPortName,
                BaudRate = BaudRate,
                DataBits = 8,
                Parity = Parity.None,
                StopBits = StopBits.One,
                ReadTimeout = 1000,
                WriteTimeout = 1000,
                NewLine = "\r\n"
            };

            try
            {
                serialPort.Open();
            }
            catch (UnauthorizedAccessException)
            {
                ShowError("Seri port başka bir uygulama tarafından kullanılıyor.");
            }
            catch (Exception ex)
            {
                ShowError($"Seri port açılamadı: {ex.Message}");
            }
        }

        private void InitializeMeasurementTimer()
        {
            measurementTimer = new Timer
            {
                Interval = 1000
            };

            measurementTimer.Tick += MeasurementTimer_Tick;
            measurementTimer.Start();
        }

        private void InitializeClockTimer()
        {
            clockTimer = new Timer
            {
                Interval = 1000
            };

            clockTimer.Tick += ClockTimer_Tick;
            clockTimer.Start();
        }

        private void MeasurementTimer_Tick(object sender, EventArgs e)
        {
            ReadAndProcessTemperature();
        }

        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            ShowCurrentDate();
        }

        private void ReadAndProcessTemperature()
        {
            if (serialPort == null || !serialPort.IsOpen)
            {
                return;
            }

            try
            {
                string serialMessage = serialPort.ReadLine();

                if (!TryExtractTemperature(serialMessage, out float temperature))
                {
                    return;
                }

                UpdateTemperatureLabel(temperature);
                SaveTemperatureToDatabase(RoomName, temperature);
            }
            catch (TimeoutException)
            {
                // Veri gelmediğinde uygulamayı mesaj kutusuyla durdurmamak için
                // zaman aşımı sessizce geçilir.
            }
            catch (Exception ex)
            {
                ShowError($"Sıcaklık verisi işlenirken hata oluştu: {ex.Message}");
            }
        }

        private static bool TryExtractTemperature(
            string serialMessage,
            out float temperature)
        {
            temperature = 0;

            if (string.IsNullOrWhiteSpace(serialMessage))
            {
                return false;
            }

            /*
             * Desteklenen örnekler:
             * 24.50
             * Temperature : 24.50 C
             * Sıcaklık: 24,50°C
             */
            Match match = Regex.Match(
                serialMessage,
                @"-?\d+(?:[.,]\d+)?");

            if (!match.Success)
            {
                return false;
            }

            string numericValue = match.Value.Replace(',', '.');

            return float.TryParse(
                numericValue,
                NumberStyles.Float,
                CultureInfo.InvariantCulture,
                out temperature);
        }

        private void UpdateTemperatureLabel(float temperature)
        {
            lblMutfakSicaklik.Text =
                $"{temperature:0.00} °C";
        }

        private void SaveTemperatureToDatabase(
            string roomName,
            float temperature)
        {
            const string query = @"
                INSERT INTO dbo.Temperature_tbl
                (
                    Room,
                    Temperature,
                    [Timestamp]
                )
                VALUES
                (
                    @Room,
                    @Temperature,
                    @Timestamp
                );";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(
                        "@Room",
                        SqlDbType.NVarChar,
                        50).Value = roomName;

                    command.Parameters.Add(
                        "@Temperature",
                        SqlDbType.Float).Value = temperature;

                    command.Parameters.Add(
                        "@Timestamp",
                        SqlDbType.DateTime).Value = DateTime.Now;

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                ShowError($"Sıcaklık verisi kaydedilemedi: {ex.Message}");
            }
        }

        private void LoadTemperatureData()
        {
            const string query = @"
                SELECT TOP (5)
                    Temperature,
                    [Timestamp]
                FROM dbo.Temperature_tbl
                WHERE Room = @Room
                ORDER BY [Timestamp] DESC;";

            try
            {
                chartLivingRoom.Series[0].Points.Clear();

                using (var connection = new SqlConnection(connectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(
                        "@Room",
                        SqlDbType.NVarChar,
                        50).Value = RoomName;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime timestamp =
                                Convert.ToDateTime(reader["Timestamp"]);

                            double temperature =
                                Convert.ToDouble(reader["Temperature"]);

                            chartLivingRoom.Series[0]
                                .Points.AddXY(timestamp, temperature);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                ShowError($"Geçmiş sıcaklık verileri yüklenemedi: {ex.Message}");
            }
        }

        private void ShowCurrentDate()
        {
            lblDate.Text =
                DateTime.Now.ToString(
                    "dd MMMM yyyy HH:mm:ss",
                    new CultureInfo("tr-TR"));
        }

        private static void ShowError(string message)
        {
            MessageBox.Show(
                message,
                "Hata",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                measurementTimer?.Stop();
                measurementTimer?.Dispose();

                clockTimer?.Stop();
                clockTimer?.Dispose();

                if (serialPort != null)
                {
                    if (serialPort.IsOpen)
                    {
                        serialPort.Close();
                    }

                    serialPort.Dispose();
                }

                components?.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}

