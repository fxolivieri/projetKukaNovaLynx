using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kuka
{
    public partial class FormClavier : Form
    {
        private bool grabState = false;

        public FormClavier()
        {
            InitializeComponent();
            ControlBox = false;
            buttonTranslation1.Enabled = false;
            buttonRotation.Enabled = false;
            buttonStart.Enabled = false;
            buttonPoint.Enabled = false;
        }

        private void buttonFormClavier_Click(object sender, EventArgs e)
        {
            Form1 parent = Application.OpenForms["form1"] as Form1;
            parent.enableButton();
            this.Visible = false;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.G)
            {
                changeStateGrabe();
                return true;
            }

            if (keyData == Keys.Escape)
            {
                changeStateStop();
            }


            return base.ProcessCmdKey(ref msg, keyData);

        }

        private void buttonPoint_Click(object sender, EventArgs e)
        {

        }

        

        private void changeStateGrabe()
        {

            if (grabState == false)
            {
                grabOpened.Visible = true;
                grabClosed.Visible = false;
                grabState = true;
            }

            else
            {
                grabOpened.Visible = false;
                grabClosed.Visible = true;
                grabState = false;
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {

        }

        private void buttonTranslation_Click(object sender, EventArgs e)
        {

        }

        private void buttonRotation_Click(object sender, EventArgs e)
        {

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {

        }

        private void buttonPredefiniMode_Click_1(object sender, EventArgs e)
        {
            buttonTranslation1.Enabled = false;
            buttonRotation.Enabled = false;
            buttonStart.Enabled = false;
            buttonPoint.Enabled = false;
        }

        private void buttonApprentissageMode_Click_1(object sender, EventArgs e)
        {
            buttonTranslation1.Enabled = true;
            buttonRotation.Enabled = true;
            buttonStart.Enabled = true;
            buttonPoint.Enabled = true;
        }

        private void changeStateStop()
        {

            pictureStop.Visible = true;
            pictureStop.Visible = true;
            buttonTranslation1.Enabled = false;
            buttonRotation.Enabled = false;
            buttonStart.Enabled = false;
            buttonPoint.Enabled = false;
            buttonApprentissageMode.Enabled = false;
            buttonPredefiniMode.Enabled = false;

        }

        private void pictureButtonStop1_Click(object sender, EventArgs e)
        {
            changeStateStop();
        }

       
    }
}
