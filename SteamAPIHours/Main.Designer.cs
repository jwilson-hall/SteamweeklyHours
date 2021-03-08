namespace SteamAPIHours
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.txtSteamID = new System.Windows.Forms.TextBox();
            this.lblSteamID = new System.Windows.Forms.Label();
            this.linkSteamIDFinder = new System.Windows.Forms.LinkLabel();
            this.btnGo = new System.Windows.Forms.Button();
            this.GameHoursChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTotalHours = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GameHoursChart)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSteamID
            // 
            this.txtSteamID.Location = new System.Drawing.Point(12, 23);
            this.txtSteamID.Name = "txtSteamID";
            this.txtSteamID.Size = new System.Drawing.Size(131, 20);
            this.txtSteamID.TabIndex = 0;
            // 
            // lblSteamID
            // 
            this.lblSteamID.AutoSize = true;
            this.lblSteamID.Location = new System.Drawing.Point(12, 7);
            this.lblSteamID.Name = "lblSteamID";
            this.lblSteamID.Size = new System.Drawing.Size(79, 13);
            this.lblSteamID.TabIndex = 1;
            this.lblSteamID.Text = "Enter Steam ID";
            // 
            // linkSteamIDFinder
            // 
            this.linkSteamIDFinder.AutoSize = true;
            this.linkSteamIDFinder.Location = new System.Drawing.Point(98, 7);
            this.linkSteamIDFinder.Name = "linkSteamIDFinder";
            this.linkSteamIDFinder.Size = new System.Drawing.Size(83, 13);
            this.linkSteamIDFinder.TabIndex = 2;
            this.linkSteamIDFinder.TabStop = true;
            this.linkSteamIDFinder.Tag = "https://steamidfinder.com/";
            this.linkSteamIDFinder.Text = "Steam ID Finder";
            this.linkSteamIDFinder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkSteamIDFinder_LinkClicked);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(149, 23);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(45, 20);
            this.btnGo.TabIndex = 3;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // GameHoursChart
            // 
            chartArea2.Name = "ChartArea1";
            this.GameHoursChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.GameHoursChart.Legends.Add(legend2);
            this.GameHoursChart.Location = new System.Drawing.Point(12, 66);
            this.GameHoursChart.Name = "GameHoursChart";
            this.GameHoursChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Hours";
            this.GameHoursChart.Series.Add(series2);
            this.GameHoursChart.Size = new System.Drawing.Size(776, 340);
            this.GameHoursChart.TabIndex = 4;
            this.GameHoursChart.Text = "Past 2 Weeks";
            // 
            // lblTotalHours
            // 
            this.lblTotalHours.AutoSize = true;
            this.lblTotalHours.BackColor = System.Drawing.Color.White;
            this.lblTotalHours.Location = new System.Drawing.Point(683, 103);
            this.lblTotalHours.Name = "lblTotalHours";
            this.lblTotalHours.Size = new System.Drawing.Size(68, 13);
            this.lblTotalHours.TabIndex = 5;
            this.lblTotalHours.Text = "Total Hours: ";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTotalHours);
            this.Controls.Add(this.GameHoursChart);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.linkSteamIDFinder);
            this.Controls.Add(this.lblSteamID);
            this.Controls.Add(this.txtSteamID);
            this.Name = "Main";
            this.Text = "Steam API";
            ((System.ComponentModel.ISupportInitialize)(this.GameHoursChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSteamID;
        private System.Windows.Forms.Label lblSteamID;
        private System.Windows.Forms.LinkLabel linkSteamIDFinder;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.DataVisualization.Charting.Chart GameHoursChart;
        private System.Windows.Forms.Label lblTotalHours;
    }
}

