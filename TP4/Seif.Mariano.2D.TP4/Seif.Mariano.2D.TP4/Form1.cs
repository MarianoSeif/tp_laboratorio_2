using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace Seif.Mariano._2D.TP4
{
    public delegate void msaje(string mensaje); //este delegado acepta metodos string con un parametro string
    public partial class Form1 : Form
    {
        
        public event msaje enviarMens;
        public Form1()
        {
            InitializeComponent();
            if (this.button1.InvokeRequired)
            {
                this.button1.BeginInvoke((MethodInvoker)delegate ()
                {
                    MessageBox.Show("test");
                });
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = null;
            this.dataGridView1.DataSource = DB.TraerProductos();
            this.dataGridView1.Refresh();
        }
    }
    
}
