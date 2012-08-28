namespace Graficas2D.Control
{
    partial class Papel2
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Papel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.DoubleBuffered = true;
            this.Name = "Papel";
            this.Size = new System.Drawing.Size(640, 480);
            this.Load += new System.EventHandler(this.Papel_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Papel_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Papel_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Papel_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Papel_MouseUp);
            this.Resize += new System.EventHandler(this.Papel_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
