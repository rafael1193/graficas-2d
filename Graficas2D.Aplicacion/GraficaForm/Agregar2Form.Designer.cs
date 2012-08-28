namespace Graficas2D.Aplicacion
{
    partial class Agregar2Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Agregar2Form));
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.aceptarButton = new System.Windows.Forms.Button();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.colorPanel = new System.Windows.Forms.Panel();
            this.funcionYTextBox = new System.Windows.Forms.TextBox();
            this.intervaloIniTextBox = new System.Windows.Forms.TextBox();
            this.intervaloFinTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.funcionXTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.grosorNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.grosorNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // aceptarButton
            // 
            this.aceptarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.aceptarButton.Location = new System.Drawing.Point(147, 108);
            this.aceptarButton.Name = "aceptarButton";
            this.aceptarButton.Size = new System.Drawing.Size(78, 23);
            this.aceptarButton.TabIndex = 7;
            this.aceptarButton.Text = "Aceptar";
            this.aceptarButton.UseVisualStyleBackColor = true;
            this.aceptarButton.Click += new System.EventHandler(this.aceptarButton_Click);
            // 
            // cancelarButton
            // 
            this.cancelarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelarButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelarButton.Location = new System.Drawing.Point(231, 108);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(78, 23);
            this.cancelarButton.TabIndex = 8;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.UseVisualStyleBackColor = true;
            // 
            // colorPanel
            // 
            this.colorPanel.BackColor = System.Drawing.Color.Red;
            this.colorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorPanel.Location = new System.Drawing.Point(272, 26);
            this.colorPanel.Name = "colorPanel";
            this.colorPanel.Size = new System.Drawing.Size(32, 32);
            this.colorPanel.TabIndex = 4;
            this.colorPanel.Click += new System.EventHandler(this.colorPanel_Click);
            // 
            // funcionYTextBox
            // 
            this.funcionYTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funcionYTextBox.Location = new System.Drawing.Point(81, 45);
            this.funcionYTextBox.Name = "funcionYTextBox";
            this.funcionYTextBox.Size = new System.Drawing.Size(173, 23);
            this.funcionYTextBox.TabIndex = 0;
            // 
            // intervaloIniTextBox
            // 
            this.intervaloIniTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.intervaloIniTextBox.Location = new System.Drawing.Point(81, 74);
            this.intervaloIniTextBox.Name = "intervaloIniTextBox";
            this.intervaloIniTextBox.Size = new System.Drawing.Size(58, 23);
            this.intervaloIniTextBox.TabIndex = 2;
            this.intervaloIniTextBox.Text = "-20";
            this.intervaloIniTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // intervaloFinTextBox
            // 
            this.intervaloFinTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.intervaloFinTextBox.Location = new System.Drawing.Point(196, 74);
            this.intervaloFinTextBox.Name = "intervaloFinTextBox";
            this.intervaloFinTextBox.Size = new System.Drawing.Size(58, 23);
            this.intervaloFinTextBox.TabIndex = 3;
            this.intervaloFinTextBox.Text = "20";
            this.intervaloFinTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Y(t)   =";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(141, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "< x <";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Intervalo: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(266, 6);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Color:";
            // 
            // funcionXTextBox
            // 
            this.funcionXTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.funcionXTextBox.Location = new System.Drawing.Point(81, 16);
            this.funcionXTextBox.Name = "funcionXTextBox";
            this.funcionXTextBox.Size = new System.Drawing.Size(173, 23);
            this.funcionXTextBox.TabIndex = 9;
            this.funcionXTextBox.Text = "t";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(29, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "X(t)   =";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 39.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(-9, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 64);
            this.label6.TabIndex = 13;
            this.label6.Text = "{";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(14, 111);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(85, 19);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Derivar Y(t)";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(260, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 17);
            this.label7.TabIndex = 15;
            this.label7.Text = "Grosor:";
            // 
            // grosorNumericUpDown
            // 
            this.grosorNumericUpDown.Location = new System.Drawing.Point(269, 81);
            this.grosorNumericUpDown.Maximum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.grosorNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.grosorNumericUpDown.Name = "grosorNumericUpDown";
            this.grosorNumericUpDown.Size = new System.Drawing.Size(40, 23);
            this.grosorNumericUpDown.TabIndex = 5;
            this.grosorNumericUpDown.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // Agregar2Form
            // 
            this.AcceptButton = this.aceptarButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.CancelButton = this.cancelarButton;
            this.ClientSize = new System.Drawing.Size(321, 143);
            this.Controls.Add(this.grosorNumericUpDown);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.funcionXTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.intervaloFinTextBox);
            this.Controls.Add(this.intervaloIniTextBox);
            this.Controls.Add(this.funcionYTextBox);
            this.Controls.Add(this.colorPanel);
            this.Controls.Add(this.cancelarButton);
            this.Controls.Add(this.aceptarButton);
            this.Controls.Add(this.label6);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Agregar2Form";
            this.ShowInTaskbar = false;
            this.Text = "Agregar nueva función...";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.AgregarForm_Load);
            this.Enter += new System.EventHandler(this.AgregarForm_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.grosorNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button aceptarButton;
        private System.Windows.Forms.Button cancelarButton;
        internal System.Windows.Forms.Panel colorPanel;
        internal System.Windows.Forms.TextBox funcionYTextBox;
        internal System.Windows.Forms.TextBox intervaloIniTextBox;
        internal System.Windows.Forms.TextBox intervaloFinTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox funcionXTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.NumericUpDown grosorNumericUpDown;
    }
}