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


namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        private bool resultadoEnBinario = false;
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            cmbOperador.SelectedItem = "+";
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblErrorOp1.Text = "";
            lblErrorOp2.Text = "";

            string operador = cmbOperador.Text;
            string numero1 = tbNumero1.Text;
            string numero2 = tbNumero2.Text;
            double operando1 = 0;
            double operando2 = 0;

            bool parseoOperando1 = double.TryParse(numero1, out operando1);
            bool parseoOperando2 = double.TryParse(numero2, out operando2);
            
            if (parseoOperando1 && parseoOperando2)
            {
                lblResultado.Text = Operar(numero1, numero2, operador).ToString();
                resultadoEnBinario = false;
                btnConvertirABinario.Enabled = true;
                btnConvertirADecimal.Enabled = false;
            } else {
                if (!parseoOperando1) lblErrorOp1.Text = "Por favor ingrese un numero";
                if (!parseoOperando2) lblErrorOp2.Text = "Por favor ingrese un numero";
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        /// <summary>
        /// Genera los objetos de tipo Numero y llama al método Operar de la clase Calculadora
        /// </summary>
        /// <param name="strNumero1"></param>
        /// <param name="strNumero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        private static double Operar(string strNumero1, string strNumero2, string operador)
        {
            Numero num1 = new Numero(strNumero1);
            Numero num2 = new Numero(strNumero2);

            return Calculadora.Operar(num1, num2, operador);
        }

        /// <summary>
        /// Limpia los datos del formulario
        /// </summary>
        private void Limpiar()
        {
            tbNumero1.Clear();
            tbNumero2.Clear();
            lblErrorOp1.Text = "";
            lblErrorOp2.Text = "";
            lblResultado.Text = "";
            cmbOperador.SelectedItem = "+";
            btnConvertirABinario.Enabled = false;
            btnConvertirADecimal.Enabled = false;
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblResultado.Text) && !resultadoEnBinario)
            {
                lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
                resultadoEnBinario = true;
                btnConvertirABinario.Enabled = false;
                btnConvertirADecimal.Enabled = true;
            }            
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblResultado.Text) && resultadoEnBinario)
            {
                lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
                resultadoEnBinario = false;
                btnConvertirABinario.Enabled = true;
                btnConvertirADecimal.Enabled = false;
            }
        }

        private void tbNumero1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                lblErrorOp1.Text = "Para decimales utilice la coma";
                e.Handled = true;
            }
        }

        private void tbNumero2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '.')
            {
                lblErrorOp2.Text = "Para decimales utilice la coma";
                e.Handled = true;
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
