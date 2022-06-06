using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TP3Prototipo
{
    public partial class FrmNotificacion : Form
    {
        public FrmNotificacion(string mensaje, int segundos)
        {
            InitializeComponent();
            lblAdvertencia.Text = mensaje;
            this.ticks = 0;
            this.segundos = segundos;
            timer1.Start();
        }
        private int ticks;
        private int segundos;     

        private void timer1_Tick(object sender, EventArgs e)
        {
            ticks++;
            if (ticks >= segundos)
            {
                timer1.Stop();
                this.Close();
            }
        }
    }
}
