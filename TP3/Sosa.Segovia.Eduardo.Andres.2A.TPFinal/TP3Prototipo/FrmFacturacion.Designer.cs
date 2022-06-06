
namespace TP3Prototipo
{
    partial class FrmFacturacion
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
            this.btnCredito = new System.Windows.Forms.Button();
            this.btnDebito = new System.Windows.Forms.Button();
            this.txtFacturaCredito = new System.Windows.Forms.RichTextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btneFECTIVO = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtFactura
            // 
            this.txtFactura.Location = new System.Drawing.Point(47, 72);
            this.txtFactura.Name = "txtFactura";
            this.txtFactura.Size = new System.Drawing.Size(457, 462);
            this.txtFactura.TabIndex = 0;
            this.txtFactura.Text = "";
            // 
            // btnCredito
            // 
            this.btnCredito.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnCredito.Location = new System.Drawing.Point(722, 559);
            this.btnCredito.Name = "btnCredito";
            this.btnCredito.Size = new System.Drawing.Size(169, 46);
            this.btnCredito.TabIndex = 2;
            this.btnCredito.Text = "CREDITO";
            this.btnCredito.UseVisualStyleBackColor = true;
            this.btnCredito.Click += new System.EventHandler(this.btnCredito_Click);
            // 
            // btnDebito
            // 
            this.btnDebito.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDebito.Location = new System.Drawing.Point(89, 559);
            this.btnDebito.Name = "btnDebito";
            this.btnDebito.Size = new System.Drawing.Size(169, 46);
            this.btnDebito.TabIndex = 3;
            this.btnDebito.Text = "DEBITO";
            this.btnDebito.UseVisualStyleBackColor = true;
            this.btnDebito.Click += new System.EventHandler(this.btnDebito_Click);
            // 
            // txtFacturaCredito
            // 
            this.txtFacturaCredito.Location = new System.Drawing.Point(564, 72);
            this.txtFacturaCredito.Name = "txtFacturaCredito";
            this.txtFacturaCredito.Size = new System.Drawing.Size(457, 462);
            this.txtFacturaCredito.TabIndex = 4;
            this.txtFacturaCredito.Text = "";
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnClose.ForeColor = System.Drawing.Color.Maroon;
            this.btnClose.Location = new System.Drawing.Point(897, 626);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(169, 46);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "CANCELAR";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btneFECTIVO
            // 
            this.btneFECTIVO.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btneFECTIVO.Location = new System.Drawing.Point(288, 559);
            this.btneFECTIVO.Name = "btneFECTIVO";
            this.btneFECTIVO.Size = new System.Drawing.Size(169, 46);
            this.btneFECTIVO.TabIndex = 6;
            this.btneFECTIVO.Text = "EFECTIVO";
            this.btneFECTIVO.UseVisualStyleBackColor = true;
            this.btneFECTIVO.Click += new System.EventHandler(this.btnEfectivo);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(288, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(489, 25);
            this.label1.TabIndex = 7;
            this.label1.Text = "VISTAS PREVIAS DEPENDIENDO DEL MEDIO DE PAGO";
            // 
            // FrmFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(1078, 684);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btneFECTIVO);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtFacturaCredito);
            this.Controls.Add(this.btnDebito);
            this.Controls.Add(this.btnCredito);
            this.Controls.Add(this.txtFactura);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmFacturacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBilling";
            this.Load += new System.EventHandler(this.FrmBilling_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtFactura;
        private System.Windows.Forms.Button btnCredito;
        private System.Windows.Forms.Button btnDebito;
        private System.Windows.Forms.RichTextBox txtFacturaCredito;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btneFECTIVO;
        private System.Windows.Forms.Label label1;
    }
}