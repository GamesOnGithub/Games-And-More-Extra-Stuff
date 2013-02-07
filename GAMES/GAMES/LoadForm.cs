using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;

namespace GAMES
{
    public partial class LoadForm : Form
    {
        //Konstruktor
        public LoadForm()
        {
            InitializeComponent();
        }

        //LoadForm_Load
        private void LoadForm_Load(object sender, EventArgs e)
        {
            LoadForm.CheckForIllegalCrossThreadCalls = false;
            System.Threading.Thread loadThread = new System.Threading.Thread(new System.Threading.ThreadStart(load));
            loadThread.Start();

            gxxlPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\GAMES\\gxxl.exe";
            tttPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\GAMES\\ttt.exe";
            rsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\GAMES\\rs.exe";
        }

        public static string gxxlPath;
        public static string gxxlUriPath;
        public static string tttPath;
        public static string tttUriPath;
        public static string rsPath;
        public static string rsUriPath;
        bool isAllowedToClose = false;

        bool isFinisedDonwloading = false;

        //Load-Method
        void load()
        {
            //Set operation count
            progressBar1.Maximum = 5;

            WebClient Webclient1 = new WebClient();
            Webclient1.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadCompleted);
            Webclient1.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadStatusChanged);

            bool gxxlUpdate = false;
            bool tttUpdate = false;
            bool rsUpdate = false;

            Settings settings = new Settings();

            #region OrdnerKreieren
            statusLabel.Text = "Überprüfe GAMES-Ordner...";

            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\GAMES\\"))
            {
                statusLabel.Text = "Erstelle GAMES-Ordner...";
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\GAMES\\");
            }

            if (!File.Exists(gxxlPath))
            {
                settings.gxxlVersion = 0;
            }
            if (!File.Exists(rsPath))
            {
                settings.rsVersion = 0;
            }
            if (!File.Exists(tttPath))
            {
                settings.tttVersion = 0;
            }

            statusLabel.Text = "Bitte Warten...";
            progressBar1.Value++;
            #endregion


            #region UpdateStatusAbrufen
            statusLabel.Text = "Überprüfe auf Updates...";

            string s1 = FTPClass.DateiAuslesen(@"ftp://ftp.lima-city.de/GAMES/update.txt", "Hausseite", "tingle25");
            string[] lines = s1.Split(new string[] { "|" }, StringSplitOptions.None);

            //ttt
            if (Convert.ToInt32(lines[0].Replace("ttt", "").Trim()) > settings.tttVersion)
            {
                tttUpdate = true;
                settings.tttVersion = Convert.ToInt32(lines[0].Replace("ttt", "").Trim());
            }

            //rs
            if (Convert.ToInt32(lines[1].Replace("rs", "").Trim()) > settings.rsVersion)
            {
                rsUpdate = true;
                settings.rsVersion = Convert.ToInt32(lines[1].Replace("rs", "").Trim());
            }

            //gxxl
            if (Convert.ToInt32(lines[2].Replace("gxxl", "").Trim()) > settings.gxxlVersion)
            {
                gxxlUpdate = true;
                settings.gxxlVersion = Convert.ToInt32(lines[2].Replace("gxxl", "").Trim());
            }

            tttUriPath = lines[3];
            rsUriPath = lines[4];
            gxxlUriPath = lines[5];

            if (tttUriPath == "noLink")
            {
                tttUpdate = false;

                if (settings.tttVersion == 0)
                    MessageBox.Show("TicTacToe ist derzeit (noch) nicht verfügbar. Probieren sie es zu einem späteren Zeitpunkt noch einmal.", "Sorry!");
            }
            if (rsUriPath == "noLink")
            {
                rsUpdate = false;

                if (settings.rsVersion == 0)
                    MessageBox.Show("RanSen ist derzeit (noch) nicht verfügbar. Probieren sie es zu einem späteren Zeitpunkt noch einmal.", "Sorry!");
            }
            if (gxxlUriPath == "noLink")
            {
                gxxlUpdate = false;

                if (settings.gxxlVersion == 0)
                    MessageBox.Show("Gourmet XXL ist derzeit (noch) nicht verfügbar. Probieren sie es zu einem späteren Zeitpunkt noch einmal.", "Sorry!");
            }

            statusLabel.Text = "Bitte Warten...";
            progressBar1.Value++;
            #endregion


            #region gxxl
            if (gxxlUpdate)
            {
                statusLabel.Text = "Aktualisiere Gourmet XXL...";
                try
                {
                    Webclient1.DownloadFileAsync(new Uri(gxxlUriPath), gxxlPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                while (!isFinisedDonwloading) ;
                isFinisedDonwloading = false;
            }
            statusLabel.Text = "Bitte Warten...";
            statusLabel2.Text = "Bitte Warten...";
            progressBar2.Value = 0;
            progressBar1.Value++;
            #endregion

            #region ttt
            if (tttUpdate)
            {
                statusLabel.Text = "Aktualisiere TicTacToe...";
                try
                {
                    Webclient1.DownloadFileAsync(new Uri(tttUriPath), tttPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                while (!isFinisedDonwloading) ;
                isFinisedDonwloading = false;
            }
            statusLabel.Text = "Bitte Warten...";
            statusLabel2.Text = "Bitte Warten...";
            progressBar2.Value = 0;
            progressBar1.Value++;
            #endregion

            #region rs
            if (rsUpdate)
            {
                statusLabel.Text = "Aktualisiere RanSen...";
                try
                {
                    Webclient1.DownloadFileAsync(new Uri(rsUriPath), rsPath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                while (!isFinisedDonwloading) ;
                isFinisedDonwloading = false;
            }
            statusLabel.Text = "Bitte Warten...";
            statusLabel2.Text = "Bitte Warten...";
            progressBar2.Value = 0;
            progressBar1.Value++;
            #endregion


            statusLabel.Text = "Fertig!";
            settings.Save();
            isAllowedToClose = true;
            this.Close();
        }

        private void DownloadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            // prüfen, ob der Download mit oder ohne Fehler beendet wurde
            if (e.Error != null)
                MessageBox.Show("Download fehlerhaft: " + e.Error);

            isFinisedDonwloading = true;
        }

        private void DownloadStatusChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // Prozentualen Fortschritt in progressBar1 anzeigen
            progressBar2.Value = e.ProgressPercentage;

            statusLabel2.Text = e.ProgressPercentage + "% (" + e.BytesReceived + " von " + e.TotalBytesToReceive + " Bytes)";
        }

        private void LoadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            toolTip1.Show("GAMES arbeitet gerade...", this, this.Height - 20, 1, 3000);

            e.Cancel = !isAllowedToClose;
        }
    }
}