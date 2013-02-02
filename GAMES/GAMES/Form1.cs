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
        }
    }
}
