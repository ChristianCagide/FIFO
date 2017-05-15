using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FIFO
{
    public partial class Form1 : Form
    {
        Proceso proceso;
        Procesador procesador;

        public Form1()
        {
            InitializeComponent();
            procesador = new Procesador();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            proceso = new Proceso();
            procesador.agregar(proceso);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            txtMostrar.Text = procesador.mostrar();
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            procesador.procesar();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            txtMostrar.Text = procesador.ToString();
        }
    }
}
