﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLiteSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Database db = new Database();

        private void Form1_Load(object sender, EventArgs e)
        {
            db.FileName = "sample.db";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.Create();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            db.Add(txtUserName.Text, txtPassword.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.GetAll();
        }
    }
}
