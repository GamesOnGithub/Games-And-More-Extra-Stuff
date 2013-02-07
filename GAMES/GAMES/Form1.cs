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
            //zufallsPicBoxGrossSetzen();
        }
        void zufallsPicBoxGrossSetzen()
        {
            Random r = new Random();
            int tempInt = r.Next(1, 3);
            if (tempInt == 1)
            {
                picBox1GrossSetzen();
            }
            if (tempInt == 2)
            {
                picBox2GrossSetzen();
            }
            if (tempInt == 3)
            {
                picBox3GrossSetzen();
            }
        }
        void picBox1GrossSetzen()
        {
            pictureBox1.Size = new Size(200, 200);
            pictureBox1.Location = new Point(12, 38);
            pictureBox2.Size = new Size(50, 50);
            pictureBox2.Location = new Point(218, 188);
            pictureBox3.Size = new Size(50, 50);
            pictureBox3.Location = new Point(274, 188);
            this.BackgroundImage = null;
            this.BackColor = Color.DimGray;
        }
        void picBox2GrossSetzen()
        {
            pictureBox2.Size = new Size(200, 200);
            pictureBox2.Location = new Point(68, 38);
            pictureBox1.Size = new Size(50, 50);
            pictureBox1.Location = new Point(12, 188);
            pictureBox3.Size = new Size(50, 50);
            pictureBox3.Location = new Point(274, 188);
            this.BackgroundImage = null;
            this.BackColor = Color.CornflowerBlue;
        }
        void picBox3GrossSetzen()
        {
            pictureBox3.Size = new Size(200, 200);
            pictureBox3.Location = new Point(124, 38);
            pictureBox1.Size = new Size(50, 50);
            pictureBox1.Location = new Point(12, 188);
            pictureBox2.Size = new Size(50, 50);
            pictureBox2.Location = new Point(68, 188);
            this.BackgroundImage = null;
            this.BackColor = Color.IndianRed;
        }
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            picBox1GrossSetzen();
        }
        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Empty;
            this.BackgroundImage = Properties.Resources.BackUnderGround;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

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

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            picBox2GrossSetzen();
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Empty;
            this.BackgroundImage = Properties.Resources.BackUnderGround;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            picBox3GrossSetzen();
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Empty;
            this.BackgroundImage = Properties.Resources.BackUnderGround;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
           
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
    }
}
