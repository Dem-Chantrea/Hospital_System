using System;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrmTreatment
{
    static class Program
    {
        public static SqlConnection Connection;
        public static Config Config;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!ReadConfig())
                return;

            if (!OpenConnection())
                return;

            //Application.Run(new FrmTreatment());
            Application.Run(new LoginFrm());
            //Application.Run(new MainForm());
        }

        private static bool ReadConfig()
        {
            try
            {
                var jsonPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsetting.json");
                var json = File.ReadAllText(jsonPath);
                Config = JsonSerializer.Deserialize<Config>(json) ?? new Config();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to read configuration: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private static bool OpenConnection()
        {
            try
            {
                Connection = new SqlConnection(Config.GetConnectionString());
                Connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database connection error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }

    public class Config
    {
        public string server { get; set; }
        public string database { get; set; }
        public string uid { get; set; }
        public string password { get; set; }

        public string GetConnectionString()
        {
            return $"Server={server};Database={database};User Id={uid};Password={password};Encrypt=False;";
        }
    }
}
