namespace Graficas2D.Aplicacion
{
	partial class RPNForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RPNForm));
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.varDataGridView = new System.Windows.Forms.DataGridView();
			this.nombreColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.valorColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.varDataGridView)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.textBox1.BackColor = System.Drawing.Color.AliceBlue;
			this.textBox1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.errorProvider1.SetIconAlignment(this.textBox1, System.Windows.Forms.ErrorIconAlignment.BottomRight);
			this.textBox1.Location = new System.Drawing.Point(12, 12);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(305, 23);
			this.textBox1.TabIndex = 0;
			this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
			this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
			this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(323, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(144, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Calcular";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// errorProvider1
			// 
			this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
			this.errorProvider1.ContainerControl = this;
			// 
			// richTextBox1
			// 
			this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBox1.BackColor = System.Drawing.Color.AliceBlue;
			this.richTextBox1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.richTextBox1.Location = new System.Drawing.Point(12, 43);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.Size = new System.Drawing.Size(305, 220);
			this.richTextBox1.TabIndex = 2;
			this.richTextBox1.Text = "";
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.BackColor = System.Drawing.Color.Transparent;
			this.button2.Location = new System.Drawing.Point(242, 269);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 3;
			this.button2.Text = "Limpiar";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// varDataGridView
			// 
			this.varDataGridView.AllowUserToAddRows = false;
			this.varDataGridView.AllowUserToDeleteRows = false;
			this.varDataGridView.AllowUserToResizeRows = false;
			this.varDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.varDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.varDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.nombreColumn,
									this.valorColumn});
			this.varDataGridView.Location = new System.Drawing.Point(6, 20);
			this.varDataGridView.MultiSelect = false;
			this.varDataGridView.Name = "varDataGridView";
			this.varDataGridView.RowHeadersVisible = false;
			this.varDataGridView.Size = new System.Drawing.Size(132, 194);
			this.varDataGridView.TabIndex = 7;
			this.varDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.VarDataGridViewCellEndEdit);
			// 
			// nombreColumn
			// 
			this.nombreColumn.HeaderText = "Variable";
			this.nombreColumn.Name = "nombreColumn";
			this.nombreColumn.ReadOnly = true;
			this.nombreColumn.Width = 64;
			// 
			// valorColumn
			// 
			this.valorColumn.HeaderText = "Valor";
			this.valorColumn.Name = "valorColumn";
			this.valorColumn.Width = 65;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.varDataGridView);
			this.groupBox1.Location = new System.Drawing.Point(323, 43);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(144, 220);
			this.groupBox1.TabIndex = 10;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Variables";
			// 
			// RPNForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
			this.ClientSize = new System.Drawing.Size(479, 304);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox1);
			this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.HelpButton = true;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(200, 107);
			this.Name = "RPNForm";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Calculadora";
			((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.varDataGridView)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.DataGridViewTextBoxColumn valorColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn nombreColumn;
		private System.Windows.Forms.DataGridView varDataGridView;
		private System.Windows.Forms.GroupBox groupBox1;

		#endregion

		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.Button button2;
	}
}