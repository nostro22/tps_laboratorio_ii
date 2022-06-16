
namespace TP3Prototipo
{
    partial class FrmClienteAlta
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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.lblDni = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblNacimiento = new System.Windows.Forms.Label();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.dateTimeNacimiento = new System.Windows.Forms.DateTimePicker();
            this.toolTipAlta = new System.Windows.Forms.ToolTip(this.components);
            this.errorProviderAlta = new System.Windows.Forms.ErrorProvider(this.components);
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.lblEtipo = new System.Windows.Forms.Label();
            this.lblAccion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderAlta)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Location = new System.Drawing.Point(51, 347);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(136, 48);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnConfirmar.ForeColor = System.Drawing.Color.Black;
            this.btnConfirmar.Location = new System.Drawing.Point(320, 347);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(136, 48);
            this.btnConfirmar.TabIndex = 1;
            this.btnConfirmar.Text = "CONFIRMAR";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDni.ForeColor = System.Drawing.Color.White;
            this.lblDni.Location = new System.Drawing.Point(235, 61);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(47, 25);
            this.lblDni.TabIndex = 2;
            this.lblDni.Text = "DNI";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNombre.ForeColor = System.Drawing.Color.White;
            this.lblNombre.Location = new System.Drawing.Point(213, 122);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(93, 25);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "NOMBRE";
            // 
            // lblNacimiento
            // 
            this.lblNacimiento.AutoSize = true;
            this.lblNacimiento.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNacimiento.ForeColor = System.Drawing.Color.White;
            this.lblNacimiento.Location = new System.Drawing.Point(140, 194);
            this.lblNacimiento.Name = "lblNacimiento";
            this.lblNacimiento.Size = new System.Drawing.Size(225, 25);
            this.lblNacimiento.TabIndex = 4;
            this.lblNacimiento.Text = "FECHA DE NACIMIENTO";
            // 
            // TxtNombre
            // 
            this.TxtNombre.Location = new System.Drawing.Point(131, 150);
            this.TxtNombre.MaxLength = 30;
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(248, 23);
            this.TxtNombre.TabIndex = 5;
            this.toolTipAlta.SetToolTip(this.TxtNombre, "Ingrese el nombre maximo 30 caracteres permitidos");
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(131, 89);
            this.txtDNI.MaxLength = 12;
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(248, 23);
            this.txtDNI.TabIndex = 6;
            this.toolTipAlta.SetToolTip(this.txtDNI, "El DNI debe contener solo numeros y no ser mayor a 12 digitos");
            // 
            // dateTimeNacimiento
            // 
            this.dateTimeNacimiento.Location = new System.Drawing.Point(131, 222);
            this.dateTimeNacimiento.MaxDate = new System.DateTime(2022, 6, 4, 0, 0, 0, 0);
            this.dateTimeNacimiento.MinDate = new System.DateTime(1950, 1, 1, 0, 0, 0, 0);
            this.dateTimeNacimiento.Name = "dateTimeNacimiento";
            this.dateTimeNacimiento.Size = new System.Drawing.Size(248, 23);
            this.dateTimeNacimiento.TabIndex = 11;
            this.toolTipAlta.SetToolTip(this.dateTimeNacimiento, "Ingrese su fecha de nacimiento");
            this.dateTimeNacimiento.Value = new System.DateTime(2022, 6, 4, 0, 0, 0, 0);
            // 
            // errorProviderAlta
            // 
            this.errorProviderAlta.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderAlta.ContainerControl = this;
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(129, 294);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(248, 23);
            this.cmbTipo.TabIndex = 12;
            // 
            // lblEtipo
            // 
            this.lblEtipo.AutoSize = true;
            this.lblEtipo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEtipo.ForeColor = System.Drawing.Color.White;
            this.lblEtipo.Location = new System.Drawing.Point(181, 266);
            this.lblEtipo.Name = "lblEtipo";
            this.lblEtipo.Size = new System.Drawing.Size(143, 25);
            this.lblEtipo.TabIndex = 13;
            this.lblEtipo.Text = "FACTURACION";
            // 
            // lblAccion
            // 
            this.lblAccion.AutoSize = true;
            this.lblAccion.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAccion.ForeColor = System.Drawing.Color.White;
            this.lblAccion.Location = new System.Drawing.Point(213, -1);
            this.lblAccion.Name = "lblAccion";
            this.lblAccion.Size = new System.Drawing.Size(97, 45);
            this.lblAccion.TabIndex = 14;
            this.lblAccion.Text = "ALTA";
            // 
            // FrmClienteAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(536, 416);
            this.Controls.Add(this.lblAccion);
            this.Controls.Add(this.lblEtipo);
            this.Controls.Add(this.cmbTipo);
            this.Controls.Add(this.dateTimeNacimiento);
            this.Controls.Add(this.txtDNI);
            this.Controls.Add(this.TxtNombre);
            this.Controls.Add(this.lblNacimiento);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.lblDni);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnCancelar);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmClienteAlta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCliente";
            this.Load += new System.EventHandler(this.FrmCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderAlta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblNacimiento;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.DateTimePicker dateTimeNacimiento;
        private System.Windows.Forms.ToolTip toolTipAlta;
        private System.Windows.Forms.ErrorProvider errorProviderAlta;
        private System.Windows.Forms.Label lblEtipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Label lblAccion;
    }
}