namespace Laboratiorio_2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            botonSol = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            groupBox1 = new GroupBox();
            solLabel = new Label();
            pictureBox1 = new PictureBox();
            label3 = new Label();
            textBox2 = new TextBox();
            label4 = new Label();
            botonNuevo = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // botonSol
            // 
            botonSol.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            botonSol.Location = new Point(45, 247);
            botonSol.Name = "botonSol";
            botonSol.Size = new Size(84, 29);
            botonSol.TabIndex = 0;
            botonSol.Text = "Solucionar";
            botonSol.UseVisualStyleBackColor = true;
            botonSol.Click += botonSol_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(142, 9);
            label1.Name = "label1";
            label1.Size = new Size(341, 21);
            label1.TabIndex = 1;
            label1.Text = "SOLUCIONADOR DE ECUACIONES LINEALES";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(108, 135);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(145, 23);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(45, 138);
            label2.Name = "label2";
            label2.Size = new Size(54, 19);
            label2.TabIndex = 3;
            label2.Text = "Recta 1";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(solLabel);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox1.Location = new Point(318, 45);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(301, 266);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Resultados";
            // 
            // solLabel
            // 
            solLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            solLabel.Location = new Point(20, 180);
            solLabel.Name = "solLabel";
            solLabel.Size = new Size(264, 83);
            solLabel.TabIndex = 1;
            solLabel.Text = "Solución: ";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(20, 28);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(264, 143);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(45, 209);
            label3.Name = "label3";
            label3.Size = new Size(54, 19);
            label3.TabIndex = 6;
            label3.Text = "Recta 2";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(108, 205);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(145, 23);
            textBox2.TabIndex = 5;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(12, 45);
            label4.Name = "label4";
            label4.Size = new Size(290, 64);
            label4.TabIndex = 7;
            label4.Text = "Ingrese por favor las ecuaciones de dos rectas en el formato canónico  y = mx + b o en la forma de punto pendiente y - y1 = m(x - x1)";
            // 
            // botonNuevo
            // 
            botonNuevo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            botonNuevo.Location = new Point(169, 247);
            botonNuevo.Name = "botonNuevo";
            botonNuevo.Size = new Size(84, 29);
            botonNuevo.TabIndex = 8;
            botonNuevo.Text = "Nuevo";
            botonNuevo.UseVisualStyleBackColor = true;
            botonNuevo.Click += botonNuevo_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(631, 321);
            Controls.Add(botonNuevo);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox2);
            Controls.Add(groupBox1);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(botonSol);
            Name = "Form1";
            Text = "ECUACIONES LINEALES";
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button botonSol;
        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private GroupBox groupBox1;
        private Label label3;
        private TextBox textBox2;
        private Label label4;
        private Label solLabel;
        private PictureBox pictureBox1;
        private Button botonNuevo;
    }
}