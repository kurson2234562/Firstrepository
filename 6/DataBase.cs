﻿using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace _6
{
    public partial class DataBase : Form
    {

        SqlDataAdapter sda;
        BindingSource bs1 = new BindingSource();
        //SqlCommandBuilder scb;
        DataTable dt;
        SqlConnection con = new SqlConnection();
        public DataBase()
        {
            InitializeComponent();
        }

        private void DataBase_Load(object sender, EventArgs e)
        {
            this.songerTableAdapter.Fill(this.audio_libDataSet.Songer);
            con.ConnectionString = @"Data Source=.;Initial Catalog=Audio_lib; Integrated Security=true";
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            bs1.DataSource = dt;
            bindingNavigator1.BindingSource = bs1;
            dataGridView1.DataSource = bs1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() != "")
            {
                sda = new SqlDataAdapter(@"Select * From " + comboBox1.SelectedItem.ToString(), con);
                dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            dataGridView1.Width = dataGridView1.Columns.Count * dataGridView1.Columns[1].Width+50;
            if(dataGridView1.Columns.Count * dataGridView1.Columns[1].Width + 50 > 430)
            this.Width = dataGridView1.Columns.Count * dataGridView1.Columns[1].Width+75;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form ChangeDatabase = new ChangeDatabase();
            ChangeDatabase.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            TextBox txt = (TextBox)e.Control;
            txt.ReadOnly = true;
        }
    }
}