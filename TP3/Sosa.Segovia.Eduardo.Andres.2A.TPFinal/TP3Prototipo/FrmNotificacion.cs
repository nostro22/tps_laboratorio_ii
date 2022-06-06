using System;
using System.Windows.Forms;


namespace TP3Prototipo
{
    /// <summary>
    /// Una especie de popup que hice no me gusto mucho asi que solo la aplique cuando el carrito esta vacio y se le da a vaciar carrito
    /// </summary>
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
