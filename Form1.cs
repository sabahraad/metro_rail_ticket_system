﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MetroRail_Ticketing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void Login(object sender, EventArgs e)
        {
            string username = tbUname.Text;
            string password = tbpassword.Text;
            var conn = Database.ConnectDb();
            conn.Open();
            string query =string.Format("select * from Employee where UserName='{0}'and Password='{1}'",username,password);
            SqlCommand cmd = new SqlCommand(query,conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
               
                this.Hide();
                new Option().Show();
            }
            else
            {
                MessageBox.Show("InValid User");
            }
            conn.Close();
        }

        private void Register(object sender, EventArgs e)
        {
            this.Hide();
            new Registration().Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
