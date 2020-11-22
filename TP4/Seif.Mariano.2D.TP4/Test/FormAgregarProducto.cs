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
using System.Threading;

namespace Test
{
    public partial class FormAgregarProducto : Form
    {
        int cantVentas = 0;
        List<Thread> listaHilos;
        public FormAgregarProducto()
        {
            InitializeComponent();
        }

        private void FormAgregarProducto_Load(object sender, EventArgs e)
        {
            this.lblInfo.Text = "Este formulario dispara un hilo nuevo para refrescar el datagrid y otro hilo que genera hasta 20 ventas a intervalos de 5 segundos";
            this.DoubleBuffered = true;
            this.dtgProductos.DataSource = null;
            this.dtgProductos.DataSource = SuperMercado.listadoProductos;

            //Se crean y se inician los hilos
            listaHilos = new List<Thread>();
            listaHilos.Add(new Thread(this.RefrescarDatagrid));
            listaHilos.Add(new Thread(this.GenerarVenta));
            foreach (Thread hilo in listaHilos)
            {
                hilo.Start();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Validaciones de los datos ingresados
            LimpiarErrores();
            string strPrecio = this.txbPrecio.Text.Replace('.', ',');

            if (this.txbDescripcion.Text == String.Empty || this.txbDescripcion.Text.Length < 3)
            {
                this.lblErrorDescripcion.Text = "Ingrese una descripcion(minimo 3 caracteres)";
            }
            
            else if (!double.TryParse(strPrecio, out double precio))
            {
                this.lblErrorPrecio.Text = "Ingrese un numero";
            }
            else if (!int.TryParse(this.txbStock.Text, out int stock))
            {
                this.lblErrorStock.Text = "Ingrese un numero entero";
            }
            else
            {
                //Se inicia el proceso de guardado del producto
                try
                {
                    if (SuperMercado.AgregarProducto(new Producto(this.txbDescripcion.Text, precio, stock)))
                    {
                        this.LimpiarInputs();
                    }
                    else
                        this.DialogResult = DialogResult.Abort;
                }
                catch (ProductoRepetidoException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void LimpiarErrores()
        {
            this.lblErrorDescripcion.Text = String.Empty;
            this.lblErrorPrecio.Text = String.Empty;
            this.lblErrorStock.Text = String.Empty;
        }

        private void LimpiarInputs()
        {
            this.txbDescripcion.Clear();
            this.txbPrecio.Clear();
            this.txbStock.Clear();
        }
        
        private void RefrescarDatagrid()
        {
            if (this.dtgProductos.InvokeRequired)
            {
                this.dtgProductos.BeginInvoke((MethodInvoker)delegate ()
                {
                    this.dtgProductos.DataSource = null;
                    this.dtgProductos.DataSource = SuperMercado.listadoProductos;
                });
            }
            else
            {
                this.dtgProductos.DataSource = null;
                this.dtgProductos.DataSource = SuperMercado.listadoProductos;
            }
            Thread.Sleep(1500);
            RefrescarDatagrid();
        }

        private void GenerarVenta()
        {
            SuperMercado.GenerarVenta();
            cantVentas++;
            Thread.Sleep(5000);
            if (cantVentas < 20)
            {
                this.GenerarVenta();
            }
        }

        private void FormAgregarProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Se cierran todos los hilos que aun esten corriendo
            foreach (Thread hilo in listaHilos)
            {
                if (hilo.IsAlive)
                {
                    hilo.Abort();
                }
            }
        }

        private void btnTestEvent_Click(object sender, EventArgs e)
        {
            SuperMercado.PonerStockEnCero();
        }

        private void btnSerializar_Click(object sender, EventArgs e)
        {
            SuperMercado.SerializarProductos();
        }

        private void btnDeserializar_Click(object sender, EventArgs e)
        {
            this.dtgSerializer.DataSource = null;
            this.dtgSerializer.DataSource = SuperMercado.DeserializarProductos();
        }
    }
}
