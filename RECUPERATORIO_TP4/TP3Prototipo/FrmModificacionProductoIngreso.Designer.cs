
namespace TP3Prototipo
{
    partial class FrmModificacionProductoIngreso
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
            this.errorProviderProducto = new System.Windows.Forms.ErrorProvider(this.components);
            this.dtgProducto = new System.Windows.Forms.DataGridView();
            this.lblModificacionTitulo = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.lblRareza = new System.Windows.Forms.Label();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.cmbRareza = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProviderProducto
            // 
            this.errorProviderProducto.ContainerControl = this;
            // 
            // dtgProducto
            // 
            this.dtgProducto.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dtgProducto.AllowUserToAddRows = false;
            this.dtgProducto.AllowUserToDeleteRows = false;
            this.dtgProducto.AllowUserToResizeColumns = false;
            this.dtgProducto.AllowUserToResizeRows = false;
            this.dtgProducto.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgProducto.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtgProducto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgProducto.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dtgProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgProducto.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtgProducto.Enabled = false;
            this.dtgProducto.Location = new System.Drawing.Point(29, 49);
            this.dtgProducto.MultiSelect = false;
            this.dtgProducto.Name = "dtgProducto";
            this.dtgProducto.ReadOnly = true;
            this.dtgProducto.RowHeadersVisible = false;
            this.dtgProducto.RowTemplate.Height = 25;
            this.dtgProducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgProducto.ShowCellErrors = false;
            this.dtgProducto.ShowCellToolTips = false;
            this.dtgProducto.ShowEditingIcon = false;
            this.dtgProducto.ShowRowErrors = false;
            this.dtgProducto.Size = new System.Drawing.Size(891, 70);
            this.dtgProducto.TabIndex = 0;
            // 
            // lblModificacionTitulo
            // 
            this.lblModificacionTitulo.AutoSize = true;
            this.lblModificacionTitulo.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblModificacionTitulo.Location = new System.Drawing.Point(310, 9);
            this.lblModificacionTitulo.Name = "lblModificacionTitulo";
            this.lblModificacionTitulo.Size = new System.Drawing.Size(372, 37);
            this.lblModificacionTitulo.TabIndex = 1;
            this.lblModificacionTitulo.Text = "MODIFICACION PRODUCTO";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNombre.Location = new System.Drawing.Point(90, 122);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(86, 25);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCantidad.Location = new System.Drawing.Point(551, 122);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(92, 25);
            this.lblCantidad.TabIndex = 3;
            this.lblCantidad.Text = "Cantidad";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPrecio.Location = new System.Drawing.Point(786, 122);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(68, 25);
            this.lblPrecio.TabIndex = 4;
            this.lblPrecio.Text = "Precio";
            // 
            // lblRareza
            // 
            this.lblRareza.AutoSize = true;
            this.lblRareza.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRareza.Location = new System.Drawing.Point(329, 122);
            this.lblRareza.Name = "lblRareza";
            this.lblRareza.Size = new System.Drawing.Size(71, 25);
            this.lblRareza.TabIndex = 5;
            this.lblRareza.Text = "Rareza";
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(803, 285);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(160, 47);
            this.btnConfirmar.TabIndex = 10;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(627, 285);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(160, 47);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(722, 150);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(199, 23);
            this.txtPrecio.TabIndex = 9;
            this.txtPrecio.TextChanged += new System.EventHandler(this.txtPrecio_TextChanged);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(489, 150);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(199, 23);
            this.txtCantidad.TabIndex = 8;
            this.txtCantidad.TextChanged += new System.EventHandler(this.txtCantidad_TextChanged);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(37, 150);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(199, 23);
            this.txtNombre.TabIndex = 6;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // cmbRareza
            // 
            this.cmbRareza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRareza.FormattingEnabled = true;
            this.cmbRareza.Location = new System.Drawing.Point(265, 150);
            this.cmbRareza.Name = "cmbRareza";
            this.cmbRareza.Size = new System.Drawing.Size(199, 23);
            this.cmbRareza.TabIndex = 12;
            // 
            // FrmModificacionProductoIngreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(975, 344);
            this.Controls.Add(this.cmbRareza);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblRareza);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblModificacionTitulo);
            this.Controls.Add(this.dtgProducto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmModificacionProductoIngreso";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmModificacionProductoIngreso";           
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgProducto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProviderProducto;
        private System.Windows.Forms.Label lblRareza;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblModificacionTitulo;
        private System.Windows.Forms.DataGridView dtgProducto;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.ComboBox cmbRareza;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtNombre;
    }
}