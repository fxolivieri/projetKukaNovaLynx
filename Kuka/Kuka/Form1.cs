﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDx.TDxInput;
using NLX.Robot.Kuka.Controller;
using System.IO;

//string fileName;

namespace Kuka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonConnection_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("Connection clicked");
            RobotController Robot = new RobotController();
            try
            {
                Robot.Connect("192.168.1.1"); 
                buttonSouris.Enabled = true;
                buttonSourisVirtuelle.Enabled = true;
                buttonConnection.Enabled = false;
                MessageBox.Show("Connected");
            }
            catch
            {
                MessageBox.Show("Connection failed !!!");
            }
            
        }

       
        private void buttonSouris_Click(object sender, EventArgs e)
        {
           FormSouris souris = new FormSouris();
       
           souris.Show();
           buttonSouris.Enabled = false;
           buttonSourisVirtuelle.Enabled = false;     
    
        }
          
        private void buttonSourisVirtuelle_Click(object sender, EventArgs e)
        {
            FormClavier clavier = new FormClavier();
      
            clavier.Show();
            buttonSouris.Enabled = false;
            buttonSourisVirtuelle.Enabled = false; 
        }

        public void enableButton()
        {
            buttonSouris.Enabled = true;
            buttonSourisVirtuelle.Enabled = true;
        }


    }
}