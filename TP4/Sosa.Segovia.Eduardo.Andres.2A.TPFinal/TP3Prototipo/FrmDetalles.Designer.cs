
namespace TP3Prototipo
{
    partial class FrmDetalles
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
            this.txtFactura = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtFactura
            // 
            this.txtFactura.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFactura.Location = new System.Drawing.Point(0, 0);
            this.txtFactura.Name = "txtFactura";
            this.txtFactura.ReadOnly = true;
            this.txtFactura.Size = new System.Drawing.Size(543, 592);
            this.txtFactura.TabIndex = 1;
            this.txtFactura.Text = "";
            // 
            // FrmDetalles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 592);
            this.Controls.Add(this.txtFactura);
            this.ForeColor = System.Drawing.Color.Green;
            this.HelpButton = true;
            this.Name = "FrmDetalles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmDetalles";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox txtFactura;
    }
}