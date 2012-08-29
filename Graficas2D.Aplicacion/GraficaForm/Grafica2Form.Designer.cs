namespace Graficas2D.Aplicacion
{
    partial class Grafica2Form
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Grafica2Form));
        	this.groupBox1 = new System.Windows.Forms.GroupBox();
        	this.checkBox3 = new System.Windows.Forms.CheckBox();
        	this.centrarButton = new System.Windows.Forms.Button();
        	this.zoomLabel = new System.Windows.Forms.Label();
        	this.zoomTrackBar = new System.Windows.Forms.TrackBar();
        	this.derechaButton = new System.Windows.Forms.Button();
        	this.izquierdaButton = new System.Windows.Forms.Button();
        	this.abajoButton = new System.Windows.Forms.Button();
        	this.arribaButton = new System.Windows.Forms.Button();
        	this.checkBox1 = new System.Windows.Forms.CheckBox();
        	this.checkBox2 = new System.Windows.Forms.CheckBox();
        	this.funcionesCheckedListBox = new System.Windows.Forms.CheckedListBox();
        	this.groupBox2 = new System.Windows.Forms.GroupBox();
        	this.eliminarButton = new System.Windows.Forms.Button();
        	this.agregarButton = new System.Windows.Forms.Button();
        	this.modificarButton = new System.Windows.Forms.Button();
        	this.exportarImagenSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
        	this.toolStrip1 = new System.Windows.Forms.ToolStrip();
        	this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
        	this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
        	this.abrirToolStripButton = new System.Windows.Forms.ToolStripButton();
        	this.guardarSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
        	this.exportarTextoSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
        	this.groupBox3 = new System.Windows.Forms.GroupBox();
        	this.panel1 = new System.Windows.Forms.Panel();
        	this.label3 = new System.Windows.Forms.Label();
        	this.label5 = new System.Windows.Forms.Label();
        	this.intervaloIniTextBox = new System.Windows.Forms.TextBox();
        	this.intervaloFinTextBox = new System.Windows.Forms.TextBox();
        	this.esDerivadaCheckBox = new System.Windows.Forms.CheckBox();
        	this.label4 = new System.Windows.Forms.Label();
        	this.colorPanel = new System.Windows.Forms.Panel();
        	this.label2 = new System.Windows.Forms.Label();
        	this.label1 = new System.Windows.Forms.Label();
        	this.YTextBox = new System.Windows.Forms.TextBox();
        	this.XTextBox = new System.Windows.Forms.TextBox();
        	this.splitContainer1 = new System.Windows.Forms.SplitContainer();
        	this.papel = new Graficas2D.Control.Papel2();
        	this.exportarToolStripButton = new System.Windows.Forms.ToolStripButton();
        	this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
        	this.groupBox1.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.zoomTrackBar)).BeginInit();
        	this.groupBox2.SuspendLayout();
        	this.toolStrip1.SuspendLayout();
        	this.groupBox3.SuspendLayout();
        	this.panel1.SuspendLayout();
        	this.splitContainer1.Panel1.SuspendLayout();
        	this.splitContainer1.Panel2.SuspendLayout();
        	this.splitContainer1.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// groupBox1
        	// 
        	this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.groupBox1.Controls.Add(this.checkBox3);
        	this.groupBox1.Controls.Add(this.centrarButton);
        	this.groupBox1.Controls.Add(this.zoomLabel);
        	this.groupBox1.Controls.Add(this.zoomTrackBar);
        	this.groupBox1.Controls.Add(this.derechaButton);
        	this.groupBox1.Controls.Add(this.izquierdaButton);
        	this.groupBox1.Controls.Add(this.abajoButton);
        	this.groupBox1.Controls.Add(this.arribaButton);
        	this.groupBox1.Controls.Add(this.checkBox1);
        	this.groupBox1.Controls.Add(this.checkBox2);
        	this.groupBox1.Location = new System.Drawing.Point(8, 229);
        	this.groupBox1.Name = "groupBox1";
        	this.groupBox1.Size = new System.Drawing.Size(249, 144);
        	this.groupBox1.TabIndex = 2;
        	this.groupBox1.TabStop = false;
        	this.groupBox1.Text = "Controles";
        	// 
        	// checkBox3
        	// 
        	this.checkBox3.AutoSize = true;
        	this.checkBox3.Checked = true;
        	this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
        	this.checkBox3.Location = new System.Drawing.Point(151, 117);
        	this.checkBox3.Name = "checkBox3";
        	this.checkBox3.Size = new System.Drawing.Size(78, 19);
        	this.checkBox3.TabIndex = 14;
        	this.checkBox3.Text = "Ver escala";
        	this.checkBox3.UseVisualStyleBackColor = true;
        	this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
        	// 
        	// centrarButton
        	// 
        	this.centrarButton.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.centrarButton.Location = new System.Drawing.Point(28, 49);
        	this.centrarButton.Name = "centrarButton";
        	this.centrarButton.Size = new System.Drawing.Size(23, 23);
        	this.centrarButton.TabIndex = 10;
        	this.centrarButton.Text = "●";
        	this.centrarButton.UseVisualStyleBackColor = true;
        	this.centrarButton.Click += new System.EventHandler(this.centrarButton_Click);
        	// 
        	// zoomLabel
        	// 
        	this.zoomLabel.AutoSize = true;
        	this.zoomLabel.Location = new System.Drawing.Point(121, 18);
        	this.zoomLabel.Name = "zoomLabel";
        	this.zoomLabel.Size = new System.Drawing.Size(67, 15);
        	this.zoomLabel.TabIndex = 5;
        	this.zoomLabel.Text = "Zoom: 50%";
        	// 
        	// zoomTrackBar
        	// 
        	this.zoomTrackBar.Location = new System.Drawing.Point(79, 36);
        	this.zoomTrackBar.Maximum = 150;
        	this.zoomTrackBar.Minimum = 5;
        	this.zoomTrackBar.Name = "zoomTrackBar";
        	this.zoomTrackBar.Size = new System.Drawing.Size(164, 45);
        	this.zoomTrackBar.TabIndex = 11;
        	this.zoomTrackBar.TickFrequency = 30;
        	this.zoomTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
        	this.zoomTrackBar.Value = 50;
        	this.zoomTrackBar.ValueChanged += new System.EventHandler(this.zoomTrackBar_ValueChanged);
        	// 
        	// derechaButton
        	// 
        	this.derechaButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.derechaButton.Location = new System.Drawing.Point(50, 49);
        	this.derechaButton.Name = "derechaButton";
        	this.derechaButton.Size = new System.Drawing.Size(23, 23);
        	this.derechaButton.TabIndex = 9;
        	this.derechaButton.Text = "→";
        	this.derechaButton.UseVisualStyleBackColor = true;
        	this.derechaButton.Click += new System.EventHandler(this.derechaButton_Click);
        	// 
        	// izquierdaButton
        	// 
        	this.izquierdaButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.izquierdaButton.Location = new System.Drawing.Point(6, 49);
        	this.izquierdaButton.Name = "izquierdaButton";
        	this.izquierdaButton.Size = new System.Drawing.Size(23, 23);
        	this.izquierdaButton.TabIndex = 7;
        	this.izquierdaButton.Text = "←";
        	this.izquierdaButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        	this.izquierdaButton.UseVisualStyleBackColor = true;
        	this.izquierdaButton.Click += new System.EventHandler(this.izquierdaButton_Click);
        	// 
        	// abajoButton
        	// 
        	this.abajoButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.abajoButton.Location = new System.Drawing.Point(28, 71);
        	this.abajoButton.Name = "abajoButton";
        	this.abajoButton.Size = new System.Drawing.Size(23, 23);
        	this.abajoButton.TabIndex = 8;
        	this.abajoButton.Text = "↓";
        	this.abajoButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        	this.abajoButton.UseVisualStyleBackColor = true;
        	this.abajoButton.Click += new System.EventHandler(this.abajoButton_Click);
        	// 
        	// arribaButton
        	// 
        	this.arribaButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.arribaButton.Location = new System.Drawing.Point(28, 27);
        	this.arribaButton.Name = "arribaButton";
        	this.arribaButton.Size = new System.Drawing.Size(23, 23);
        	this.arribaButton.TabIndex = 6;
        	this.arribaButton.Text = "↑▲";
        	this.arribaButton.UseVisualStyleBackColor = true;
        	this.arribaButton.Click += new System.EventHandler(this.arribaButton_Click);
        	// 
        	// checkBox1
        	// 
        	this.checkBox1.AutoSize = true;
        	this.checkBox1.Checked = true;
        	this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
        	this.checkBox1.Location = new System.Drawing.Point(76, 92);
        	this.checkBox1.Name = "checkBox1";
        	this.checkBox1.Size = new System.Drawing.Size(101, 19);
        	this.checkBox1.TabIndex = 12;
        	this.checkBox1.Text = "Ver cuadricula";
        	this.checkBox1.UseVisualStyleBackColor = true;
        	this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
        	// 
        	// checkBox2
        	// 
        	this.checkBox2.AutoSize = true;
        	this.checkBox2.Checked = true;
        	this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
        	this.checkBox2.Location = new System.Drawing.Point(29, 117);
        	this.checkBox2.Name = "checkBox2";
        	this.checkBox2.Size = new System.Drawing.Size(66, 19);
        	this.checkBox2.TabIndex = 13;
        	this.checkBox2.Text = "Ver ejes";
        	this.checkBox2.UseVisualStyleBackColor = true;
        	this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
        	// 
        	// funcionesCheckedListBox
        	// 
        	this.funcionesCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.funcionesCheckedListBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.funcionesCheckedListBox.FormattingEnabled = true;
        	this.funcionesCheckedListBox.HorizontalScrollbar = true;
        	this.funcionesCheckedListBox.Location = new System.Drawing.Point(6, 47);
        	this.funcionesCheckedListBox.Name = "funcionesCheckedListBox";
        	this.funcionesCheckedListBox.Size = new System.Drawing.Size(237, 94);
        	this.funcionesCheckedListBox.TabIndex = 3;
        	this.funcionesCheckedListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
        	this.funcionesCheckedListBox.SelectedIndexChanged += new System.EventHandler(this.funcionesCheckedListBox_SelectedIndexChanged);
        	// 
        	// groupBox2
        	// 
        	this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.groupBox2.Controls.Add(this.eliminarButton);
        	this.groupBox2.Controls.Add(this.agregarButton);
        	this.groupBox2.Controls.Add(this.modificarButton);
        	this.groupBox2.Controls.Add(this.funcionesCheckedListBox);
        	this.groupBox2.Location = new System.Drawing.Point(8, 3);
        	this.groupBox2.Name = "groupBox2";
        	this.groupBox2.Size = new System.Drawing.Size(249, 148);
        	this.groupBox2.TabIndex = 0;
        	this.groupBox2.TabStop = false;
        	this.groupBox2.Text = "Funciones";
        	// 
        	// eliminarButton
        	// 
        	this.eliminarButton.Image = global::Graficas2D.Aplicacion.Properties.Resources.chart_curve_delete1;
        	this.eliminarButton.Location = new System.Drawing.Point(168, 18);
        	this.eliminarButton.Name = "eliminarButton";
        	this.eliminarButton.Size = new System.Drawing.Size(75, 23);
        	this.eliminarButton.TabIndex = 2;
        	this.eliminarButton.Text = "Eliminar";
        	this.eliminarButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
        	this.eliminarButton.UseVisualStyleBackColor = true;
        	this.eliminarButton.Click += new System.EventHandler(this.eliminarButton_Click);
        	// 
        	// agregarButton
        	// 
        	this.agregarButton.Image = global::Graficas2D.Aplicacion.Properties.Resources.chart_curve_add1;
        	this.agregarButton.Location = new System.Drawing.Point(6, 18);
        	this.agregarButton.Name = "agregarButton";
        	this.agregarButton.Size = new System.Drawing.Size(75, 23);
        	this.agregarButton.TabIndex = 0;
        	this.agregarButton.Text = "Agregar";
        	this.agregarButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
        	this.agregarButton.UseVisualStyleBackColor = true;
        	this.agregarButton.Click += new System.EventHandler(this.button1_Click);
        	// 
        	// modificarButton
        	// 
        	this.modificarButton.Image = global::Graficas2D.Aplicacion.Properties.Resources.chart_curve_edit1;
        	this.modificarButton.Location = new System.Drawing.Point(87, 18);
        	this.modificarButton.Name = "modificarButton";
        	this.modificarButton.Size = new System.Drawing.Size(75, 23);
        	this.modificarButton.TabIndex = 1;
        	this.modificarButton.Text = "Editar";
        	this.modificarButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
        	this.modificarButton.UseVisualStyleBackColor = true;
        	this.modificarButton.Click += new System.EventHandler(this.modificarButton_Click);
        	// 
        	// exportarImagenSaveFileDialog
        	// 
        	this.exportarImagenSaveFileDialog.DefaultExt = "png";
        	this.exportarImagenSaveFileDialog.FileName = "funcion";
        	this.exportarImagenSaveFileDialog.Filter = "Mapa de Bits|*.bmp|Portable Network Graphics|*.png|Graphics Interchange Format|*." +
        	"gif|Joint Photographic Experts Group|*.jpg";
        	this.exportarImagenSaveFileDialog.FilterIndex = 2;
        	this.exportarImagenSaveFileDialog.Title = "Exportar a...";
        	// 
        	// toolStrip1
        	// 
        	this.toolStrip1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
        	this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
        	this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.toolStripLabel1,
        	        	        	this.toolStripTextBox1,
        	        	        	this.toolStripButton1,
        	        	        	this.exportarToolStripButton,
        	        	        	this.abrirToolStripButton});
        	this.toolStrip1.Location = new System.Drawing.Point(0, 0);
        	this.toolStrip1.Name = "toolStrip1";
        	this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
        	this.toolStrip1.Size = new System.Drawing.Size(784, 25);
        	this.toolStrip1.TabIndex = 7;
        	this.toolStrip1.Text = "toolStrip1";
        	// 
        	// toolStripLabel1
        	// 
        	this.toolStripLabel1.Name = "toolStripLabel1";
        	this.toolStripLabel1.Size = new System.Drawing.Size(54, 22);
        	this.toolStripLabel1.Text = "Nombre:";
        	// 
        	// toolStripTextBox1
        	// 
        	this.toolStripTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
        	this.toolStripTextBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.toolStripTextBox1.Name = "toolStripTextBox1";
        	this.toolStripTextBox1.Size = new System.Drawing.Size(150, 25);
        	this.toolStripTextBox1.TextChanged += new System.EventHandler(this.toolStripTextBox1_TextChanged);
        	// 
        	// abrirToolStripButton
        	// 
        	this.abrirToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
        	this.abrirToolStripButton.Image = global::Graficas2D.Aplicacion.Properties.Resources.documentopen;
        	this.abrirToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.abrirToolStripButton.Name = "abrirToolStripButton";
        	this.abrirToolStripButton.Size = new System.Drawing.Size(53, 22);
        	this.abrirToolStripButton.Text = "Abrir";
        	this.abrirToolStripButton.Click += new System.EventHandler(this.abrirToolStripButton_Click);
        	// 
        	// guardarSaveFileDialog
        	// 
        	this.guardarSaveFileDialog.DefaultExt = "fml";
        	this.guardarSaveFileDialog.FileName = "funcion";
        	this.guardarSaveFileDialog.Filter = "Functions Markup Language|*.fml";
        	this.guardarSaveFileDialog.FilterIndex = 0;
        	this.guardarSaveFileDialog.Title = "Guardar funciones...";
        	// 
        	// exportarTextoSaveFileDialog
        	// 
        	this.exportarTextoSaveFileDialog.Filter = "Archivo de texto|*.txt";
        	this.exportarTextoSaveFileDialog.FilterIndex = 0;
        	// 
        	// groupBox3
        	// 
        	this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.groupBox3.Controls.Add(this.panel1);
        	this.groupBox3.Location = new System.Drawing.Point(8, 157);
        	this.groupBox3.Name = "groupBox3";
        	this.groupBox3.Size = new System.Drawing.Size(249, 66);
        	this.groupBox3.TabIndex = 1;
        	this.groupBox3.TabStop = false;
        	this.groupBox3.Text = "Información";
        	// 
        	// panel1
        	// 
        	this.panel1.AutoScroll = true;
        	this.panel1.Controls.Add(this.label3);
        	this.panel1.Controls.Add(this.label5);
        	this.panel1.Controls.Add(this.intervaloIniTextBox);
        	this.panel1.Controls.Add(this.intervaloFinTextBox);
        	this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.panel1.Location = new System.Drawing.Point(3, 19);
        	this.panel1.Name = "panel1";
        	this.panel1.Size = new System.Drawing.Size(243, 44);
        	this.panel1.TabIndex = 9;
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.label3.Location = new System.Drawing.Point(10, 14);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(59, 15);
        	this.label3.TabIndex = 15;
        	this.label3.Text = "Intervalo: ";
        	// 
        	// label5
        	// 
        	this.label5.AutoSize = true;
        	this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.label5.Location = new System.Drawing.Point(132, 14);
        	this.label5.Name = "label5";
        	this.label5.Size = new System.Drawing.Size(34, 15);
        	this.label5.TabIndex = 14;
        	this.label5.Text = "< x <";
        	// 
        	// intervaloIniTextBox
        	// 
        	this.intervaloIniTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.intervaloIniTextBox.Location = new System.Drawing.Point(73, 10);
        	this.intervaloIniTextBox.Name = "intervaloIniTextBox";
        	this.intervaloIniTextBox.ReadOnly = true;
        	this.intervaloIniTextBox.Size = new System.Drawing.Size(52, 23);
        	this.intervaloIniTextBox.TabIndex = 4;
        	this.intervaloIniTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        	// 
        	// intervaloFinTextBox
        	// 
        	this.intervaloFinTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.intervaloFinTextBox.Location = new System.Drawing.Point(173, 10);
        	this.intervaloFinTextBox.Name = "intervaloFinTextBox";
        	this.intervaloFinTextBox.ReadOnly = true;
        	this.intervaloFinTextBox.Size = new System.Drawing.Size(52, 23);
        	this.intervaloFinTextBox.TabIndex = 5;
        	this.intervaloFinTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        	// 
        	// esDerivadaCheckBox
        	// 
        	this.esDerivadaCheckBox.AutoSize = true;
        	this.esDerivadaCheckBox.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
        	this.esDerivadaCheckBox.Enabled = false;
        	this.esDerivadaCheckBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.esDerivadaCheckBox.Location = new System.Drawing.Point(122, 138);
        	this.esDerivadaCheckBox.Name = "esDerivadaCheckBox";
        	this.esDerivadaCheckBox.Size = new System.Drawing.Size(127, 19);
        	this.esDerivadaCheckBox.TabIndex = 17;
        	this.esDerivadaCheckBox.Text = "¿Función derivada?";
        	this.esDerivadaCheckBox.UseVisualStyleBackColor = true;
        	this.esDerivadaCheckBox.Visible = false;
        	// 
        	// label4
        	// 
        	this.label4.AutoSize = true;
        	this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.label4.Location = new System.Drawing.Point(35, 138);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(39, 15);
        	this.label4.TabIndex = 16;
        	this.label4.Text = "Color:";
        	this.label4.Visible = false;
        	// 
        	// colorPanel
        	// 
        	this.colorPanel.BackColor = System.Drawing.Color.Transparent;
        	this.colorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.colorPanel.Location = new System.Drawing.Point(82, 134);
        	this.colorPanel.Name = "colorPanel";
        	this.colorPanel.Size = new System.Drawing.Size(25, 25);
        	this.colorPanel.TabIndex = 13;
        	this.colorPanel.Visible = false;
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.label2.Location = new System.Drawing.Point(33, 79);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(40, 15);
        	this.label2.TabIndex = 4;
        	this.label2.Text = "Y(t)  =";
        	this.label2.Visible = false;
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.label1.Location = new System.Drawing.Point(33, 50);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(40, 15);
        	this.label1.TabIndex = 2;
        	this.label1.Text = "X(t)  =";
        	this.label1.Visible = false;
        	// 
        	// YTextBox
        	// 
        	this.YTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.YTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.YTextBox.Location = new System.Drawing.Point(76, 76);
        	this.YTextBox.Name = "YTextBox";
        	this.YTextBox.ReadOnly = true;
        	this.YTextBox.Size = new System.Drawing.Size(190, 22);
        	this.YTextBox.TabIndex = 3;
        	this.YTextBox.Visible = false;
        	// 
        	// XTextBox
        	// 
        	this.XTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.XTextBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.XTextBox.Location = new System.Drawing.Point(76, 47);
        	this.XTextBox.Name = "XTextBox";
        	this.XTextBox.ReadOnly = true;
        	this.XTextBox.Size = new System.Drawing.Size(190, 22);
        	this.XTextBox.TabIndex = 1;
        	this.XTextBox.Visible = false;
        	// 
        	// splitContainer1
        	// 
        	this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        	this.splitContainer1.Location = new System.Drawing.Point(0, 25);
        	this.splitContainer1.Name = "splitContainer1";
        	// 
        	// splitContainer1.Panel1
        	// 
        	this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
        	this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
        	this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
        	this.splitContainer1.Panel1MinSize = 260;
        	// 
        	// splitContainer1.Panel2
        	// 
        	this.splitContainer1.Panel2.Controls.Add(this.esDerivadaCheckBox);
        	this.splitContainer1.Panel2.Controls.Add(this.papel);
        	this.splitContainer1.Panel2.Controls.Add(this.label4);
        	this.splitContainer1.Panel2.Controls.Add(this.label1);
        	this.splitContainer1.Panel2.Controls.Add(this.XTextBox);
        	this.splitContainer1.Panel2.Controls.Add(this.YTextBox);
        	this.splitContainer1.Panel2.Controls.Add(this.label2);
        	this.splitContainer1.Panel2.Controls.Add(this.colorPanel);
        	this.splitContainer1.Size = new System.Drawing.Size(784, 437);
        	this.splitContainer1.SplitterDistance = 260;
        	this.splitContainer1.TabIndex = 10;
        	// 
        	// papel
        	// 
        	this.papel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        	        	        	| System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.papel.BackColor = System.Drawing.Color.White;
        	this.papel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.papel.Centro = new System.Drawing.Point(257, 215);
        	this.papel.ColorCuadricula = System.Drawing.Color.LightBlue;
        	this.papel.ColorEjes = System.Drawing.Color.Black;
        	this.papel.ColorFondo = System.Drawing.Color.White;
        	this.papel.Funciones = null;
        	this.papel.Location = new System.Drawing.Point(3, 3);
        	this.papel.MostrarCuadricula = true;
        	this.papel.MostrarEjeX = true;
        	this.papel.MostrarEjeY = true;
        	this.papel.MostrarEscala = true;
        	this.papel.MovimientoConRaton = true;
        	this.papel.Name = "papel";
        	this.papel.Size = new System.Drawing.Size(514, 431);
        	this.papel.TabIndex = 3;
        	this.papel.TabStop = false;
        	this.papel.VelocidadDesplazamientoRaton = 1F;
        	this.papel.ZoomConRaton = true;
        	this.papel.ZoomMaximo = ((uint)(150u));
        	this.papel.ZoomMinimo = ((uint)(5u));
        	// 
        	// exportarToolStripButton
        	// 
        	this.exportarToolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
        	this.exportarToolStripButton.Image = global::Graficas2D.Aplicacion.Properties.Resources.applicationsgraphics;
        	this.exportarToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.exportarToolStripButton.Name = "exportarToolStripButton";
        	this.exportarToolStripButton.Size = new System.Drawing.Size(113, 22);
        	this.exportarToolStripButton.Text = "Exportar imagen";
        	// 
        	// toolStripButton1
        	// 
        	this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
        	this.toolStripButton1.Image = global::Graficas2D.Aplicacion.Properties.Resources.documentsave;
        	this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.toolStripButton1.Name = "toolStripButton1";
        	this.toolStripButton1.Size = new System.Drawing.Size(69, 22);
        	this.toolStripButton1.Text = "Guardar";
        	// 
        	// Grafica2Form
        	// 
        	this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(228)))), ((int)(((byte)(248)))));
        	this.ClientSize = new System.Drawing.Size(784, 462);
        	this.Controls.Add(this.splitContainer1);
        	this.Controls.Add(this.toolStrip1);
        	this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.MinimumSize = new System.Drawing.Size(700, 476);
        	this.Name = "Grafica2Form";
        	this.Text = "Gráfica ";
        	this.Activated += new System.EventHandler(this.GraficaMDIForm_Activated);
        	this.Deactivate += new System.EventHandler(this.GraficaMDIForm_Deactivate);
        	this.Load += new System.EventHandler(this.GraficaMDIForm_Load);
        	this.groupBox1.ResumeLayout(false);
        	this.groupBox1.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.zoomTrackBar)).EndInit();
        	this.groupBox2.ResumeLayout(false);
        	this.toolStrip1.ResumeLayout(false);
        	this.toolStrip1.PerformLayout();
        	this.groupBox3.ResumeLayout(false);
        	this.panel1.ResumeLayout(false);
        	this.panel1.PerformLayout();
        	this.splitContainer1.Panel1.ResumeLayout(false);
        	this.splitContainer1.Panel2.ResumeLayout(false);
        	this.splitContainer1.Panel2.PerformLayout();
        	this.splitContainer1.ResumeLayout(false);
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.ToolStripButton exportarToolStripButton;

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button derechaButton;
        private System.Windows.Forms.Button izquierdaButton;
        private System.Windows.Forms.Button abajoButton;
        private System.Windows.Forms.Button arribaButton;
        private System.Windows.Forms.Label zoomLabel;
        private System.Windows.Forms.TrackBar zoomTrackBar;
        private System.Windows.Forms.CheckedListBox funcionesCheckedListBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button modificarButton;
        private System.Windows.Forms.Button eliminarButton;
        private System.Windows.Forms.Button agregarButton;
        private System.Windows.Forms.SaveFileDialog exportarImagenSaveFileDialog;
        private System.Windows.Forms.Button centrarButton;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.SaveFileDialog guardarSaveFileDialog;
        private System.Windows.Forms.SaveFileDialog exportarTextoSaveFileDialog;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox YTextBox;
        private System.Windows.Forms.TextBox XTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.TextBox intervaloIniTextBox;
        internal System.Windows.Forms.TextBox intervaloFinTextBox;
        internal System.Windows.Forms.Panel colorPanel;
        private Graficas2D.Control.Papel2 papel;
        private System.Windows.Forms.CheckBox esDerivadaCheckBox;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.ToolStripButton abrirToolStripButton;
    }
}

