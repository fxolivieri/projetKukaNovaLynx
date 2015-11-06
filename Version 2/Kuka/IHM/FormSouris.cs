using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLX.Robot.Kuka.Controller;

namespace Kuka
{
    
    public partial class FormSouris : Form
    {
        private bool grabState = false; //Etat initiale de la pince
        private RobotController robot = new RobotController();

        public FormSouris()
        {
            InitializeComponent();

            //ControlBox = false;
            buttonTranslation.Enabled = false;
            buttonRotation.Enabled = false;
            buttonStart.Enabled = false;
            buttonPoint.Enabled = false;
            pictureBox1.Enabled = false;
            label2.Enabled = false;
            label1.Enabled = false;
            label3.Enabled = false;
            label4.Enabled = false;
            label5.Enabled = false;
            label6.Enabled = false;
            grabClosed.Enabled = false;
            grabOpened.Enabled = false;
            dataX.Enabled = false;
            dataY.Enabled = false;
            dataZ.Enabled = false;
            dataA.Enabled = false;
            dataB.Enabled = false;
            dataC.Enabled = false;
            label7.Enabled = false;
            buttonPredefiniMode.Enabled = false;
            buttonApprentissageMode.Enabled = false;
            pictureBox2.Enabled = false;
            pictureBox3.Enabled = false;
            pictureBox4.Enabled = false;
            pictureBox5.Enabled = false;
            pictureBox6.Enabled = false;
            pictureBox7.Enabled = false;
            pictureBox8.Enabled = false;
            pictureBox9.Enabled = false;
            pictureBox10.Enabled = false;
            pictureBox11.Enabled = false;
            pictureBox12.Enabled = false;
            pictureBox13.Enabled = false;
            pictureBox14.Enabled = false;
            pictureBox15.Enabled = false;
            pictureBox16.Enabled = false;
            pictureBox17.Enabled = false;
            point0x.Enabled = false;
            point0y.Enabled = false;
            point1x.Enabled = false;
            point1y.Enabled = false;
            point2y.Enabled = false;
            point2x.Enabled = false;
            point3y.Enabled = false;
            point3x.Enabled = false;
            point4y.Enabled = false;
            point4x.Enabled = false;
            point5y.Enabled = false;
            point5x.Enabled = false;
            point6y.Enabled = false;
            point6x.Enabled = false;
            point7y.Enabled = false;
            point7x.Enabled = false;
            point8y.Enabled = false;
            point8x.Enabled = false;
            point9y.Enabled = false;
            point9x.Enabled = false;
            point10y.Enabled = false;
            point10x.Enabled = false;
            point11y.Enabled = false;
            point11x.Enabled = false;
            point12y.Enabled = false;
            point12x.Enabled = false;
            point13y.Enabled = false;
            point13x.Enabled = false;
            point14y.Enabled = false;
            point14x.Enabled = false;
            point15y.Enabled = false;
            point15x.Enabled = false;
                        
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
                //stop_Click();
            }

            return base.ProcessCmdKey(ref msg, keyData);

        }


        //private void buttonFormSouris_Click(object sender, EventArgs e)
        //{
        //    Form1 parent = Application.OpenForms["form1"] as Form1;
        //    parent.enableButton();
        //    this.Visible = false;
        //}

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

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            try
            {
                
                //ControlBox = true;
                buttonTranslation.Enabled = true;
                buttonRotation.Enabled = true;
                buttonStart.Enabled = true;
                buttonPoint.Enabled = true;
                pictureBox1.Enabled = true;
                label2.Enabled = true;
                label1.Enabled = true;
                label3.Enabled = true;
                label4.Enabled = true;
                label5.Enabled = true;
                label6.Enabled = true;
                grabClosed.Enabled = true;
                grabOpened.Enabled = true;
                dataX.Enabled = true;
                dataY.Enabled = true;
                dataZ.Enabled = true;
                dataA.Enabled = true;
                dataB.Enabled = true;
                dataC.Enabled = true;
                label7.Enabled = true;
                buttonPredefiniMode.Enabled = true;
                buttonApprentissageMode.Enabled = true;
                pictureBox2.Enabled = true;
                pictureBox3.Enabled = true;
                pictureBox4.Enabled = true;
                pictureBox5.Enabled = true;
                pictureBox6.Enabled = true;
                pictureBox7.Enabled = true;
                pictureBox8.Enabled = true;
                pictureBox9.Enabled = true;
                pictureBox10.Enabled = true;
                pictureBox11.Enabled = true;
                pictureBox12.Enabled = true;
                pictureBox13.Enabled = true;
                pictureBox14.Enabled = true;
                pictureBox15.Enabled = true;
                pictureBox16.Enabled = true;
                pictureBox17.Enabled = true;
                point0x.Enabled = true;
                point0y.Enabled = true;
                point1x.Enabled = true;
                point1y.Enabled = true;
                point2y.Enabled = true;
                point2x.Enabled = true;
                point3y.Enabled = true;
                point3x.Enabled = true;
                point4y.Enabled = true;
                point4x.Enabled = true;
                point5y.Enabled = true;
                point5x.Enabled = true;
                point6y.Enabled = true;
                point6x.Enabled = true;
                point7y.Enabled = true;
                point7x.Enabled = true;
                point8y.Enabled = true;
                point8x.Enabled = true;
                point9y.Enabled = true;
                point9x.Enabled = true;
                point10y.Enabled = true;
                point10x.Enabled = true;
                point11y.Enabled = true;
                point11x.Enabled = true;
                point12y.Enabled = true;
                point12x.Enabled = true;
                point13y.Enabled = true;
                point13x.Enabled = true;
                point14y.Enabled = true;
                point14x.Enabled = true;
                point15y.Enabled = true;
                point15x.Enabled = true;
                
            }
            catch
            {
                MessageBox.Show("Connection failed !!!");
            }
        }
    }
}
