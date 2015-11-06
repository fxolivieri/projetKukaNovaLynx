namespace Kuka
{
    partial class FormClavier
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonFormClavier = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonRotation = new System.Windows.Forms.Button();
            this.buttonTranslation = new System.Windows.Forms.Button();
            this.buttonPoint = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataC = new System.Windows.Forms.Label();
            this.dataB = new System.Windows.Forms.Label();
            this.dataA = new System.Windows.Forms.Label();
            this.dataZ = new System.Windows.Forms.Label();
            this.dataY = new System.Windows.Forms.Label();
            this.dataX = new System.Windows.Forms.Label();
            this.grabOpened = new System.Windows.Forms.PictureBox();
            this.grabClosed = new System.Windows.Forms.PictureBox();
            this.buttonApprentissageMode = new System.Windows.Forms.Button();
            this.buttonPredefiniMode = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grabOpened)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grabClosed)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonFormClavier
            // 
            this.buttonFormClavier.Location = new System.Drawing.Point(12, 12);
            this.buttonFormClavier.Name = "buttonFormClavier";
            this.buttonFormClavier.Size = new System.Drawing.Size(75, 23);
            this.buttonFormClavier.TabIndex = 0;
            this.buttonFormClavier.Text = "return";
            this.buttonFormClavier.UseVisualStyleBackColor = true;
            this.buttonFormClavier.Click += new System.EventHandler(this.buttonFormClavier_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Kuka.Properties.Resources.bouton_d_arrêt_d_urgence_93;
            this.pictureBox1.Location = new System.Drawing.Point(784, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 76);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // buttonRotation
            // 
            this.buttonRotation.Location = new System.Drawing.Point(259, 424);
            this.buttonRotation.Name = "buttonRotation";
            this.buttonRotation.Size = new System.Drawing.Size(82, 34);
            this.buttonRotation.TabIndex = 7;
            this.buttonRotation.Text = "Rotation";
            this.buttonRotation.UseVisualStyleBackColor = true;
            // 
            // buttonTranslation
            // 
            this.buttonTranslation.Location = new System.Drawing.Point(131, 424);
            this.buttonTranslation.Name = "buttonTranslation";
            this.buttonTranslation.Size = new System.Drawing.Size(85, 34);
            this.buttonTranslation.TabIndex = 6;
            this.buttonTranslation.Text = "Translation";
            this.buttonTranslation.UseVisualStyleBackColor = true;
            // 
            // buttonPoint
            // 
            this.buttonPoint.Location = new System.Drawing.Point(12, 424);
            this.buttonPoint.Name = "buttonPoint";
            this.buttonPoint.Size = new System.Drawing.Size(88, 34);
            this.buttonPoint.TabIndex = 5;
            this.buttonPoint.Text = "Save point";
            this.buttonPoint.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(14, 280);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 24);
            this.label6.TabIndex = 18;
            this.label6.Text = "C :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 242);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 24);
            this.label5.TabIndex = 17;
            this.label5.Text = "B :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 24);
            this.label4.TabIndex = 16;
            this.label4.Text = "A :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 24);
            this.label3.TabIndex = 15;
            this.label3.Text = "Z :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 24);
            this.label1.TabIndex = 14;
            this.label1.Text = "Y :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 24);
            this.label2.TabIndex = 13;
            this.label2.Text = "X :";
            // 
            // dataC
            // 
            this.dataC.AutoSize = true;
            this.dataC.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataC.Location = new System.Drawing.Point(51, 280);
            this.dataC.Name = "dataC";
            this.dataC.Size = new System.Drawing.Size(20, 24);
            this.dataC.TabIndex = 26;
            this.dataC.Text = "0";
            // 
            // dataB
            // 
            this.dataB.AutoSize = true;
            this.dataB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataB.Location = new System.Drawing.Point(51, 242);
            this.dataB.Name = "dataB";
            this.dataB.Size = new System.Drawing.Size(20, 24);
            this.dataB.TabIndex = 25;
            this.dataB.Text = "0";
            // 
            // dataA
            // 
            this.dataA.AutoSize = true;
            this.dataA.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataA.Location = new System.Drawing.Point(51, 204);
            this.dataA.Name = "dataA";
            this.dataA.Size = new System.Drawing.Size(20, 24);
            this.dataA.TabIndex = 24;
            this.dataA.Text = "0";
            // 
            // dataZ
            // 
            this.dataZ.AutoSize = true;
            this.dataZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataZ.Location = new System.Drawing.Point(52, 153);
            this.dataZ.Name = "dataZ";
            this.dataZ.Size = new System.Drawing.Size(20, 24);
            this.dataZ.TabIndex = 23;
            this.dataZ.Text = "0";
            // 
            // dataY
            // 
            this.dataY.AutoSize = true;
            this.dataY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataY.Location = new System.Drawing.Point(52, 116);
            this.dataY.Name = "dataY";
            this.dataY.Size = new System.Drawing.Size(20, 24);
            this.dataY.TabIndex = 22;
            this.dataY.Text = "0";
            // 
            // dataX
            // 
            this.dataX.AutoSize = true;
            this.dataX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataX.Location = new System.Drawing.Point(52, 80);
            this.dataX.Name = "dataX";
            this.dataX.Size = new System.Drawing.Size(20, 24);
            this.dataX.TabIndex = 21;
            this.dataX.Text = "0";
            // 
            // grabOpened
            // 
            this.grabOpened.Image = global::Kuka.Properties.Resources.pinceFerme;
            this.grabOpened.Location = new System.Drawing.Point(-3, 310);
            this.grabOpened.Name = "grabOpened";
            this.grabOpened.Size = new System.Drawing.Size(79, 108);
            this.grabOpened.TabIndex = 28;
            this.grabOpened.TabStop = false;
            // 
            // grabClosed
            // 
            this.grabClosed.Image = global::Kuka.Properties.Resources.pinceF;
            this.grabClosed.Location = new System.Drawing.Point(-3, 310);
            this.grabClosed.Name = "grabClosed";
            this.grabClosed.Size = new System.Drawing.Size(74, 108);
            this.grabClosed.TabIndex = 27;
            this.grabClosed.TabStop = false;
            this.grabClosed.Visible = false;
            // 
            // buttonApprentissageMode
            // 
            this.buttonApprentissageMode.Location = new System.Drawing.Point(784, 337);
            this.buttonApprentissageMode.Name = "buttonApprentissageMode";
            this.buttonApprentissageMode.Size = new System.Drawing.Size(90, 43);
            this.buttonApprentissageMode.TabIndex = 42;
            this.buttonApprentissageMode.Text = "Apprentissage mode";
            this.buttonApprentissageMode.UseVisualStyleBackColor = true;
            // 
            // buttonPredefiniMode
            // 
            this.buttonPredefiniMode.Location = new System.Drawing.Point(784, 280);
            this.buttonPredefiniMode.Name = "buttonPredefiniMode";
            this.buttonPredefiniMode.Size = new System.Drawing.Size(90, 43);
            this.buttonPredefiniMode.TabIndex = 41;
            this.buttonPredefiniMode.Text = "Pre defini mode";
            this.buttonPredefiniMode.UseVisualStyleBackColor = true;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(800, 430);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(74, 34);
            this.buttonStart.TabIndex = 40;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(255, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 24);
            this.label7.TabIndex = 43;
            this.label7.Text = "16 points";
            // 
            // FormClavier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 470);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonApprentissageMode);
            this.Controls.Add(this.buttonPredefiniMode);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.grabOpened);
            this.Controls.Add(this.grabClosed);
            this.Controls.Add(this.dataC);
            this.Controls.Add(this.dataB);
            this.Controls.Add(this.dataA);
            this.Controls.Add(this.dataZ);
            this.Controls.Add(this.dataY);
            this.Controls.Add(this.dataX);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonRotation);
            this.Controls.Add(this.buttonTranslation);
            this.Controls.Add(this.buttonPoint);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonFormClavier);
            this.Name = "FormClavier";
            this.Text = "FormClavier";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grabOpened)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grabClosed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFormClavier;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonRotation;
        private System.Windows.Forms.Button buttonTranslation;
        private System.Windows.Forms.Button buttonPoint;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label dataC;
        private System.Windows.Forms.Label dataB;
        private System.Windows.Forms.Label dataA;
        private System.Windows.Forms.Label dataZ;
        private System.Windows.Forms.Label dataY;
        private System.Windows.Forms.Label dataX;
        private System.Windows.Forms.PictureBox grabOpened;
        private System.Windows.Forms.PictureBox grabClosed;
        private System.Windows.Forms.Button buttonApprentissageMode;
        private System.Windows.Forms.Button buttonPredefiniMode;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label label7;
    }
}