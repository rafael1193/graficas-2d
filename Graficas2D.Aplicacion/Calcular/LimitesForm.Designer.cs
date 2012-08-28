namespace Graficas2D.Aplicacion
{
    partial class LimitesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LimitesForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.calcularButton = new System.Windows.Forms.Button();
            this.valxTextBox = new System.Windows.Forms.TextBox();
            this.masInfButton = new System.Windows.Forms.Button();
            this.menosInfButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // calcularButton
            // 
            resources.ApplyResources(this.calcularButton, "calcularButton");
            this.calcularButton.Name = "calcularButton";
            this.calcularButton.UseVisualStyleBackColor = true;
            this.calcularButton.Click += new System.EventHandler(this.calcularButton_Click);
            // 
            // valxTextBox
            // 
            resources.ApplyResources(this.valxTextBox, "valxTextBox");
            this.valxTextBox.BackColor = System.Drawing.Color.AliceBlue;
            this.valxTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.valxTextBox.Name = "valxTextBox";
            // 
            // masInfButton
            // 
            resources.ApplyResources(this.masInfButton, "masInfButton");
            this.masInfButton.Name = "masInfButton";
            this.masInfButton.UseVisualStyleBackColor = true;
            this.masInfButton.Click += new System.EventHandler(this.masInfButton_Click);
            // 
            // menosInfButton
            // 
            resources.ApplyResources(this.menosInfButton, "menosInfButton");
            this.menosInfButton.Name = "menosInfButton";
            this.menosInfButton.UseVisualStyleBackColor = true;
            this.menosInfButton.Click += new System.EventHandler(this.menosInfButton_Click);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Name = "label4";
            // 
            // LimitesForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
            this.Controls.Add(this.label4);
            this.Controls.Add(this.menosInfButton);
            this.Controls.Add(this.masInfButton);
            this.Controls.Add(this.valxTextBox);
            this.Controls.Add(this.calcularButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LimitesForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button calcularButton;
        private System.Windows.Forms.TextBox valxTextBox;
        private System.Windows.Forms.Button masInfButton;
        private System.Windows.Forms.Button menosInfButton;
        private System.Windows.Forms.Label label4;
    }
}