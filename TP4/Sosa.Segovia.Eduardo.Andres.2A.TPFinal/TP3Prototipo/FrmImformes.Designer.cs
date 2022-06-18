
namespace TP3Prototipo
{
    partial class FrmImformes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtgvFacturas = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnDetalles = new System.Windows.Forms.Button();
            this.lblIngresoFactura = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDescargarFactura = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvFacturas)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgvFacturas
            // 
            this.dtgvFacturas.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dtgvFacturas.AllowUserToAddRows = false;
            this.dtgvFacturas.AllowUserToDeleteRows = false;
            this.dtgvFacturas.AllowUserToResizeColumns = false;
            this.dtgvFacturas.AllowUserToResizeRows = false;
            this.dtgvFacturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvFacturas.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            this.dtgvFacturas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvFacturas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dtgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvFacturas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtgvFacturas.Location = new System.Drawing.Point(24, 36);
            this.dtgvFacturas.MultiSelect = false;
            this.dtgvFacturas.Name = "dtgvFacturas";
            this.dtgvFacturas.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvFacturas.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvFacturas.RowHeadersVisible = false;
            this.dtgvFacturas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtgvFacturas.RowTemplate.Height = 25;
            this.dtgvFacturas.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtgvFacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvFacturas.ShowCellToolTips = false;
            this.dtgvFacturas.ShowEditingIcon = false;
            this.dtgvFacturas.Size = new System.Drawing.Size(552, 487);
            this.dtgvFacturas.TabIndex = 27;
            this.dtgvFacturas.SelectionChanged += new System.EventHandler(this.dtgvFacturas_SelectionChanged);
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSalir.ForeColor = System.Drawing.Color.Maroon;
            this.btnSalir.Location = new System.Drawing.Point(598, 406);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(180, 44);
            this.btnSalir.TabIndex = 28;
            this.btnSalir.Text = "VOLVER";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnDetalles
            // 
            this.btnDetalles.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDetalles.Location = new System.Drawing.Point(610, 178);
            this.btnDetalles.Name = "btnDetalles";
            this.btnDetalles.Size = new System.Drawing.Size(149, 44);
            this.btnDetalles.TabIndex = 30;
            this.btnDetalles.Text = "VER DETALLES";
            this.btnDetalles.UseVisualStyleBackColor = true;
            this.btnDetalles.Click += new System.EventHandler(this.btnDetalles_Click);
            // 
            // lblIngresoFactura
            // 
            this.lblIngresoFactura.AutoSize = true;
            this.lblIngresoFactura.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblIngresoFactura.ForeColor = System.Drawing.Color.White;
            this.lblIngresoFactura.Location = new System.Drawing.Point(610, 130);
            this.lblIngresoFactura.Name = "lblIngresoFactura";
            this.lblIngresoFactura.Size = new System.Drawing.Size(167, 21);
            this.lblIngresoFactura.TabIndex = 31;
            this.lblIngresoFactura.Text = "Factura Selecionada ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(614, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 21);
            this.label1.TabIndex = 32;
            // 
            // btnDescargarFactura
            // 
            this.btnDescargarFactura.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDescargarFactura.Location = new System.Drawing.Point(610, 228);
            this.btnDescargarFactura.Name = "btnDescargarFactura";
            this.btnDescargarFactura.Size = new System.Drawing.Size(149, 44);
            this.btnDescargarFactura.TabIndex = 33;
            this.btnDescargarFactura.Text = "DESCARGAR";
            this.btnDescargarFactura.UseVisualStyleBackColor = true;
            this.btnDescargarFactura.Click += new System.EventHandler(this.btnDescargarFactura_Click);
            // 
            // FrmImformes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.btnDescargarFactura);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblIngresoFactura);
            this.Controls.Add(this.btnDetalles);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dtgvFacturas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmImformes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmImformes";
            ((System.ComponentModel.ISupportInitialize)(this.dtgvFacturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvFacturas;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnDetalles;
        private System.Windows.Forms.Label lblIngresoFactura;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDescargarFactura;
    }
}