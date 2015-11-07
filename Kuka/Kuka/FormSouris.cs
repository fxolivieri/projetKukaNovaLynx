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
    
    public partial class FormSouris : Form
    {
        private bool grabState = false; //Etat initiale de la pince 
       

        public FormSouris()
        {
            InitializeComponent();
            ControlBox = false;
            buttonTranslation.Enabled = false;
            buttonRotation.Enabled = false;
            buttonStart.Enabled = false;
            buttonPoint.Enabled = false;
            pictureStop.Visible = false;

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


        private void buttonFormSouris_Click(object sender, EventArgs e)
        {
            Form1 parent = Application.OpenForms["form1"] as Form1;
            parent.enableButton();
            this.Visible = false;
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


        private void changeStateStop()
        {

            pictureStop.Visible = true;
            buttonTranslation.Enabled = false;
            buttonRotation.Enabled = false;
            buttonStart.Enabled = false;
            buttonPoint.Enabled = false;
            buttonApprentissageMode.Enabled = false;
            buttonPredefiniMode.Enabled = false;

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

        private void buttonPredefiniMode_Click(object sender, EventArgs e)
        {
            buttonTranslation.Enabled = false;
            buttonRotation.Enabled = false;
            buttonStart.Enabled = false;
            buttonPoint.Enabled = false;
            


        }

        private void buttonApprentissageMode_Click(object sender, EventArgs e)
        {
            buttonTranslation.Enabled = true;
            buttonRotation.Enabled = true;
            buttonStart.Enabled = true;
            buttonPoint.Enabled = true;
            

        }

        private void buttonPoint_Click(object sender, EventArgs e)
        {

        }

        private void pictureButtonStop_Click(object sender, EventArgs e)
        {
            changeStateStop();
        }

    }
}
