using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace GAMES
{
    public partial class LoadForm : Form
    {
        //Konstruktor
        public LoadForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Pfad zur Gourmet XXL .exe
        /// </summary>
        public static string gxxlPath = @"C:\TestOrdner\gxxl.exe";

        //gxxlFertig
        bool isGxxlFinished = false;


        //LoadForm_Load
        private void LoadForm_Load(object sender, EventArgs e)
        {
            LoadForm.CheckForIllegalCrossThreadCalls = false;
            System.Threading.Thread loadThread = new System.Threading.Thread(new System.Threading.ThreadStart(load));
            loadThread.Start();
        }

        //Load-Method
        void load()
        {
            //Set operation count
            progressBar1.Maximum = 3;

            statusLabel.Text = "Lade Daten...";

            WebClient client = new WebClient();
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(clientProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(clientFertig);

            progressBar1.Value++;

            statusLabel.Text = "Aktualisiere Programme...";

            //gxxl
            client.DownloadFileAsync(new Uri("https://mega.co.nz/#!ZVR23TJC!JsUdvQoQ_eOiFwQCgUWXUBxoTTcWcSqMqORh0ZGU684"), gxxlPath);

            while (!isGxxlFinished) ;

            progressBar1.Value++;
            statusLabel.Text = "Fertig!";
            this.Close();
        }

        //DownloadFile Event
        void clientProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar2.Value = e.ProgressPercentage;
            statusLabel2.Text = e.ProgressPercentage + "% heruntergeladen (" + e.BytesReceived + " von " + e.TotalBytesToReceive + "Bytes)";
        }

        //Fertig-Event
        void clientFertig(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
                isGxxlFinished = true;

            else if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
                Application.Exit();
            }
        }
    }
}
