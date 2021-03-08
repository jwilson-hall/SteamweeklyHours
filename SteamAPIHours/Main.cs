using System;
using System.Text;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Security.Cryptography;
using System.IO;

namespace SteamAPIHours
{
    public partial class Main : Form
    {
        //-------------------------Objects-----------------------------
        private string steamProfileID = "&steamid=76561198199033779";
        private string steamAPI2WeeksCall = "http://api.steampowered.com/IPlayerService/GetRecentlyPlayedGames/v0001/?key=";
        private string steamAPIFormat = "&format=json";
        private string APIKey = "KVkih8ZbA30e4ePOvMXGgxcFGdUN5rFIcAHgEJmRvz4=";
        const string PasswordHash = "J&&Uj1kl";
        const string SaltKey = "J$JI&KEY";
        const string VIKey = "#6V9j4K0y1H4l3M2";
        Root jData = new Root();
        //-------------------------Objects-----------------------------

        public Main()
        {
            InitializeComponent();

            
        }
        private void deserialiseJSON(string strJSON)
        {
            try
            {
                jData = JsonConvert.DeserializeObject<Root>(strJSON);
            }
            catch (JsonReaderException e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        public static string Decrypt(string encryptedText)
        {
            if (encryptedText.Length % 4 != 0)
            {
                return encryptedText;
            }
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            try
            {
                int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                memoryStream.Close();
                cryptoStream.Close();
                return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
            }
            catch (CryptographicException)
            {

                return null;
            }
        }

        private void linkSteamIDFinder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://steamidfinder.com/");
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            steamProfileID = "&steamid="+txtSteamID.Text;
            GameHoursChart.Series["Hours"].Points.Clear();
            HttpClient client = new HttpClient();
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(steamAPI2WeeksCall +Decrypt(APIKey)+ steamProfileID + steamAPIFormat).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var dataObjects = response.Content.ReadAsStringAsync();
                deserialiseJSON(dataObjects.Result);
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            client.Dispose();
            double totalHrs = 0;
            try
            {
                foreach (var item in jData.response.games)
                {
                    if (item.playtime_2weeks > 0)
                    {
                        double temptime = item.playtime_2weeks / 60.0;
                        totalHrs = totalHrs + temptime;
                        Console.WriteLine("Game : {0}   Past 2 weeks play time: {1} hrs", item.name, Math.Round(temptime, 1));
                        GameHoursChart.Series["Hours"].Points.AddXY(item.name, Math.Round(temptime, 1));
                    }
                }
                lblTotalHours.Text = ("Total Hours: "+ Math.Round(totalHrs,1));
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Invalid Steam ID");
            }
            
            Console.WriteLine("Total Hours: {0}", Math.Round(totalHrs, 1));
        }
    }
}
