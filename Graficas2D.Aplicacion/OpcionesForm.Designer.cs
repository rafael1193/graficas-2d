namespace Graficas2D.Aplicacion
{
    partial class OpcionesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpcionesForm));
            this.cancelarButton = new System.Windows.Forms.Button();
            this.aplicarButton = new System.Windows.Forms.Button();
            this.aceptarButton = new System.Windows.Forms.Button();
            this.barraIconosCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.constantesListBox = new System.Windows.Forms.ListBox();
            this.nuevaConstanteButton = new System.Windows.Forms.Button();
            this.eliminarConstanteButton = new System.Windows.Forms.Button();
            this.modificarConstanteButton = new System.Windows.Forms.Button();
            this.modificarConstanteTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelarButton
            // 
            this.cancelarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelarButton.Location = new System.Drawing.Point(250, 248);
            this.cancelarButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(75, 28);
            this.cancelarButton.TabIndex = 0;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.UseVisualStyleBackColor = true;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // aplicarButton
            // 
            this.aplicarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.aplicarButton.Location = new System.Drawing.Point(331, 248);
            this.aplicarButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.aplicarButton.Name = "aplicarButton";
            this.aplicarButton.Size = new System.Drawing.Size(75, 28);
            this.aplicarButton.TabIndex = 1;
            this.aplicarButton.Text = "Aplicar";
            this.aplicarButton.UseVisualStyleBackColor = true;
            this.aplicarButton.Click += new System.EventHandler(this.aplicarButton_Click);
            // 
            // aceptarButton
            // 
            this.aceptarButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.aceptarButton.Location = new System.Drawing.Point(169, 248);
            this.aceptarButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.aceptarButton.Name = "aceptarButton";
            this.aceptarButton.Size = new System.Drawing.Size(75, 28);
            this.aceptarButton.TabIndex = 2;
            this.aceptarButton.Text = "Aceptar";
            this.aceptarButton.UseVisualStyleBackColor = true;
            this.aceptarButton.Click += new System.EventHandler(this.aceptarButton_Click);
            // 
            // barraIconosCheckBox
            // 
            this.barraIconosCheckBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.barraIconosCheckBox.AutoSize = true;
            this.barraIconosCheckBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barraIconosCheckBox.Location = new System.Drawing.Point(16, 25);
            this.barraIconosCheckBox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.barraIconosCheckBox.Name = "barraIconosCheckBox";
            this.barraIconosCheckBox.Size = new System.Drawing.Size(163, 21);
            this.barraIconosCheckBox.TabIndex = 6;
            this.barraIconosCheckBox.Text = "Activar barra de Iconos";
            this.barraIconosCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.barraIconosCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(394, 58);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Interfaz";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.modificarConstanteTextBox);
            this.groupBox2.Controls.Add(this.modificarConstanteButton);
            this.groupBox2.Controls.Add(this.nuevaConstanteButton);
            this.groupBox2.Controls.Add(this.eliminarConstanteButton);
            this.groupBox2.Controls.Add(this.constantesListBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(394, 158);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Constantes";
            // 
            // constantesListBox
            // 
            this.constantesListBox.FormattingEnabled = true;
            this.constantesListBox.ItemHeight = 17;
            this.constantesListBox.Location = new System.Drawing.Point(16, 24);
            this.constantesListBox.Name = "constantesListBox";
            this.constantesListBox.Size = new System.Drawing.Size(156, 89);
            this.constantesListBox.TabIndex = 0;
            this.constantesListBox.SelectedIndexChanged += new System.EventHandler(this.constantesListBox_SelectedIndexChanged);
            // 
            // nuevaConstanteButton
            // 
            this.nuevaConstanteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nuevaConstanteButton.Location = new System.Drawing.Point(16, 121);
            this.nuevaConstanteButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.nuevaConstanteButton.Name = "nuevaConstanteButton";
            this.nuevaConstanteButton.Size = new System.Drawing.Size(75, 28);
            this.nuevaConstanteButton.TabIndex = 9;
            this.nuevaConstanteButton.Text = "Nueva";
            this.nuevaConstanteButton.UseVisualStyleBackColor = true;
            // 
            // eliminarConstanteButton
            // 
            this.eliminarConstanteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.eliminarConstanteButton.Location = new System.Drawing.Point(97, 121);
            this.eliminarConstanteButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.eliminarConstanteButton.Name = "eliminarConstanteButton";
            this.eliminarConstanteButton.Size = new System.Drawing.Size(75, 28);
            this.eliminarConstanteButton.TabIndex = 10;
            this.eliminarConstanteButton.Text = "Eliminar";
            this.eliminarConstanteButton.UseVisualStyleBackColor = true;
            // 
            // modificarConstanteButton
            // 
            this.modificarConstanteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.modificarConstanteButton.Location = new System.Drawing.Point(307, 57);
            this.modificarConstanteButton.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.modificarConstanteButton.Name = "modificarConstanteButton";
            this.modificarConstanteButton.Size = new System.Drawing.Size(75, 28);
            this.modificarConstanteButton.TabIndex = 11;
            this.modificarConstanteButton.Text = "Modificar";
            this.modificarConstanteButton.UseVisualStyleBackColor = true;
            // 
            // modificarConstanteTextBox
            // 
            this.modificarConstanteTextBox.Location = new System.Drawing.Point(186, 24);
            this.modificarConstanteTextBox.Name = "modificarConstanteTextBox";
            this.modificarConstanteTextBox.Size = new System.Drawing.Size(196, 25);
            this.modificarConstanteTextBox.TabIndex = 12;
            // 
            // OpcionesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(418, 289);
            this.Controls.Add(this.aplicarButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.aceptarButton);
            this.Controls.Add(this.cancelarButton);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OpcionesForm";
            this.Text = "Preferencias";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.OpcionesForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cancelarButton;
        private System.Windows.Forms.Button aplicarButton;
        private System.Windows.Forms.Button aceptarButton;
        private System.Windows.Forms.CheckBox barraIconosCheckBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox modificarConstanteTextBox;
        private System.Windows.Forms.Button modificarConstanteButton;
        private System.Windows.Forms.Button nuevaConstanteButton;
        private System.Windows.Forms.Button eliminarConstanteButton;
        private System.Windows.Forms.ListBox constantesListBox;
    }
}