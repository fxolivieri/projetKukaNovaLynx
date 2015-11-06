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
        //private bool grabeState = false;

        public FormClavier()
        {
            InitializeComponent();
            ControlBox = false;
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
                //changeStateGrabe();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);

        }

        

        /*private void changeStateGrabe()
        {

            if (grabeState == false)
            {
                grabeOpened.Visible = true;
                grabeClosed.Visible = false;
                grabeState = true;
            }

            else
            {
                grabeOpened.Visible = false;
                grabeClosed.Visible = true;
                grabeState = false;
            }
        }*/
    }
}
