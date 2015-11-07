using System.Windows.Forms;
namespace Kuka
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>

        
        private void InitializeComponent()
        {
            this.buttonSouris = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSourisVirtuelle = new System.Windows.Forms.Button();
            this.buttonConnection = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSouris
            // 
            this.buttonSouris.Enabled = false;
            this.buttonSouris.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSouris.Location = new System.Drawing.Point(62, 143);
            this.buttonSouris.Name = "buttonSouris";
            this.buttonSouris.Size = new System.Drawing.Size(103, 40);
            this.buttonSouris.TabIndex = 0;
            this.buttonSouris.Text = "Mouse 3D";
            this.buttonSouris.UseVisualStyleBackColor = true;
            this.buttonSouris.Click += new System.EventHandler(this.buttonSouris_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(57, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 52);
            this.label1.TabIndex = 1;
            this.label1.Text = "Trajectoires Robot KUKA\r\n     By BB, MM, JB, FXO";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonSourisVirtuelle
            // 
            this.buttonSourisVirtuelle.Enabled = false;
            this.buttonSourisVirtuelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSourisVirtuelle.Location = new System.Drawing.Point(232, 143);
            this.buttonSourisVirtuelle.Name = "buttonSourisVirtuelle";
            this.buttonSourisVirtuelle.Size = new System.Drawing.Size(103, 40);
            this.buttonSourisVirtuelle.TabIndex = 2;
            this.buttonSourisVirtuelle.Text = "Keyboard";
            this.buttonSourisVirtuelle.UseVisualStyleBackColor = true;
            this.buttonSourisVirtuelle.Click += new System.EventHandler(this.buttonSourisVirtuelle_Click);
            // 
            // buttonConnection
            // 
            this.buttonConnection.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConnection.Location = new System.Drawing.Point(137, 77);
            this.buttonConnection.Name = "buttonConnection";
            this.buttonConnection.Size = new System.Drawing.Size(137, 39);
            this.buttonConnection.TabIndex = 3;
            this.buttonConnection.Text = "Connection";
            this.buttonConnection.UseVisualStyleBackColor = true;
            this.buttonConnection.Click += new System.EventHandler(this.buttonConnection_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Kuka.Properties.Resources.Agilusss;
            this.pictureBox1.Location = new System.Drawing.Point(378, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(309, 428);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 449);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonConnection);
            this.Controls.Add(this.buttonSourisVirtuelle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSouris);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSouris;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSourisVirtuelle;
        private System.Windows.Forms.Button buttonConnection;
        private PictureBox pictureBox1;
    }
}

