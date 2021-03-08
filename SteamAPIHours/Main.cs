using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Diagnostics;

namespace SteamAPIHours
{
    public partial class Main : Form
    {
        //-------------------------Objects-----------------------------
        private string steamProfileID = "76561198199033779";
        private string steamAPI2WeeksCall = "http://api.steampowered.com/IPlayerService/GetRecentlyPlayedGames/v0001/?key=4855D3D95FA2A9484B68297725A23814&steamid=";
        private string steamAPIFormat = "&format=json";
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

        private void linkSteamIDFinder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://steamidfinder.com/");
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            steamProfileID = txtSteamID.Text;
            GameHoursChart.Series["Hours"].Points.Clear();
            HttpClient client = new HttpClient();
            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(steamAPI2WeeksCall + steamProfileID + steamAPIFormat).Result;  // Blocking call! Program will wait here until a response is received or a timeout occurs.
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var dataObjects = response.Content.ReadAsStringAsync();  //Make sure to add a reference to System.Net.Http.Formatting.dll
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
