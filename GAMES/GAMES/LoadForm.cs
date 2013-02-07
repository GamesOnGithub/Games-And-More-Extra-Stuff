using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        }

        //Load-Method
        void load()
        {
            //Set operation count
            progressBar1.Maximum = 3;

            statusLabel.Text = "Lade Daten...";
            //TODO: Create all useful objects
            progressBar1.Value++;

            statusLabel.Text = "Überprüfe auf Programme zum Download...";
            //TODO: Check programs to update
            progressBar1.Value++;

            statusLabel.Text = "Aktualisiere Programme...";
            //TODO: Update programs
            progressBar1.Value++;

            this.Close();
        }
    }
}
