
namespace TP3Prototipo
{
    partial class FrmSolicitudDni
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblDniAccion = new System.Windows.Forms.Label();
            this.lblTituloSolicitud = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.errorProviderDni = new System.Windows.Forms.ErrorProvider(this.components);
            this.dtgvCliente = new System.Windows.Forms.DataGridView();
            this.Dni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtDniModificar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDniAccion
            // 
            this.lblDniAccion.AutoSize = true;
            this.lblDniAccion.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDniAccion.ForeColor = System.Drawing.Color.White;
            this.lblDniAccion.Location = new System.Drawing.Point(45, 117);
            this.lblDniAccion.Name = "lblDniAccion";
            this.lblDniAccion.Size = new System.Drawing.Size(486, 30);
            this.lblDniAccion.TabIndex = 0;
            this.lblDniAccion.Text = "Selecione el DNI del cliente que desea Modificar";
            // 
            // lblTituloSolicitud
            // 
            this.lblTituloSolicitud.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTituloSolicitud.AutoSize = true;
            this.lblTituloSolicitud.Font = new System.Drawing.Font("Segoe UI", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTituloSolicitud.ForeColor = System.Drawing.Color.White;
            this.lblTituloSolicitud.Location = new System.Drawing.Point(152, 9);
            this.lblTituloSolicitud.Name = "lblTituloSolicitud";
            this.lblTituloSolicitud.Size = new System.Drawing.Size(213, 50);
            this.lblTituloSolicitud.TabIndex = 2;
            this.lblTituloSolicitud.Text = "SOLICITUD";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(91, 238);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(118, 42);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(295, 238);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(118, 42);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "MODIFICAR";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // errorProviderDni
            // 
            this.errorProviderDni.ContainerControl = this;
            // 
            // dtgvCliente
            // 
            this.dtgvCliente.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dtgvCliente.AllowUserToDeleteRows = false;
            this.dtgvCliente.AllowUserToOrderColumns = true;
            this.dtgvCliente.AllowUserToResizeColumns = false;
            this.dtgvCliente.AllowUserToResizeRows = false;
            this.dtgvCliente.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvCliente.BackgroundColor = System.Drawing.Color.DarkSlateGray;
            this.dtgvCliente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgvCliente.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical;
            this.dtgvCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvCliente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Dni,
            this.Nombre,
            this.Estado});
            this.dtgvCliente.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtgvCliente.Location = new System.Drawing.Point(596, 12);
            this.dtgvCliente.MultiSelect = false;
            this.dtgvCliente.Name = "dtgvCliente";
            this.dtgvCliente.ReadOnly = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgvCliente.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgvCliente.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dtgvCliente.RowTemplate.Height = 25;
            this.dtgvCliente.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dtgvCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgvCliente.ShowCellToolTips = false;
            this.dtgvCliente.ShowEditingIcon = false;
            this.dtgvCliente.Size = new System.Drawing.Size(391, 325);
            this.dtgvCliente.TabIndex = 27;
            this.dtgvCliente.SelectionChanged += new System.EventHandler(this.dtgvCliente_SelectionChanged);
            // 
            // Dni
            // 
            this.Dni.HeaderText = "DNI";
            this.Dni.Name = "Dni";
            this.Dni.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "NOMBRE";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Estado
            // 
            this.Estado.HeaderText = "ESTADO";
            this.Estado.Name = "Estado";
            this.Estado.ReadOnly = true;
            // 
            // txtDniModificar
            // 
            this.txtDniModificar.Location = new System.Drawing.Point(139, 167);
            this.txtDniModificar.Name = "txtDniModificar";
            this.txtDniModificar.Size = new System.Drawing.Size(226, 23);
            this.txtDniModificar.TabIndex = 28;
            // 
            // FrmSolicitudDni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(999, 371);
            this.Controls.Add(this.txtDniModificar);
            this.Controls.Add(this.dtgvCliente);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblTituloSolicitud);
            this.Controls.Add(this.lblDniAccion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmSolicitudDni";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSolicitudDni";
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderDni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDniAccion;
        private System.Windows.Forms.Label lblTituloSolicitud;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.ErrorProvider errorProviderDni;
        private System.Windows.Forms.DataGridView dtgvCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dni;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Estado;
        private System.Windows.Forms.TextBox txtDniModificar;
    }
}