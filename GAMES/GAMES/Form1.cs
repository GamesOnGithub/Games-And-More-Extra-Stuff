using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace GAMES
{
    public partial class Form1 : Form
    {
        //Konstruktor
        public Form1()
        {
            InitializeComponent();
        }

        //Load this form
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadForm lForm = new LoadForm();
            lForm.ShowDialog();

            gxxlinfothis = LoadForm.gxxlinfo;
            rsinfothis = LoadForm.rsinfo;
            tttinfothis = LoadForm.tttinfo;
        }

        //INFOS(-TEALER.Snifula.XYZ)
        string gxxlinfothis, rsinfothis, tttinfothis;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(LoadForm.gxxlPath);
            }
            catch (Exception ex)
            {
                if (MessageBox.Show("Gourmet XXL ist noch nicht installiert! Soll ein Update gemacht werden?", "Fehler", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    LoadForm lForm = new LoadForm();
                    lForm.ShowDialog();
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(LoadForm.rsPath);
            }
            catch(Exception ex)
            {
                if (MessageBox.Show("RanSen ist noch nicht installiert! Soll ein Update gemacht werden?", "Fehler", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    LoadForm lForm = new LoadForm();
                    lForm.ShowDialog();
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(LoadForm.tttPath);
            }
            catch (Exception ex)
            {
                if (MessageBox.Show("TicTacToe ist noch nicht installiert! Soll ein Update gemacht werden?", "Fehler", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                {
                    LoadForm lForm = new LoadForm();
                    lForm.ShowDialog();
                }
            }
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            PictureBox sendBox = (PictureBox)sender;
            sendBox.BackColor = Color.DimGray;

            if (sender.Equals(pictureBox1))
            {
                label2.Text = "Gourmet XXL";
                label1.Text = gxxlinfothis;
            }

            if (sender.Equals(pictureBox2))
            {
                label2.Text = "RanSen";
                label1.Text = rsinfothis;
            }

            if (sender.Equals(pictureBox3))
            {
                label2.Text = "TicTacToe";
                label1.Text = tttinfothis;
            }
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            PictureBox sendBox = (PictureBox)sender;
            sendBox.BackColor = Color.Transparent;
        }
    }
}
