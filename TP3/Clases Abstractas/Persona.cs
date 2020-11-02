using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Excepciones;

namespace ClasesAbstractas
{
    public abstract class Persona
    {
        #region Atributos
        protected string apellido;
        protected int dni;
        protected ENacionalidad nacionalidad;
        protected string nombre;
        public enum ENacionalidad { Argentino, Extranjero };
        #endregion

        #region Propiedades
        public string Apellido
        {
            get { return this.apellido; }
            set {
                string apellido = ValidarNombreApellido(value);
                if(apellido != String.Empty)
                {
                    this.apellido = apellido;
                }
            }
        }

        public int DNI
        {
            get { return this.dni; }
            set {
                    this.dni = ValidarDni(this.nacionalidad, value);
            }
        }

        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }
            set { this.nacionalidad = value; }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { this.nombre = value; }
        }

        public string StringToDNI
        {
            set {
                    this.dni = ValidarDni(this.nacionalidad, value);
            }
        }
        #endregion

        #region Constructores
        public Persona()
        {
        }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Devuelve los datos del objeto en formato cadena de caracteres
        /// </summary>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"NOMBRE COMPLETO: {this.apellido}, {this.nombre} ");
            sb.AppendLine($"NACIONALIDAD: {this.nacionalidad}");
            return sb.ToString();
        }

        /// <summary>
        /// Corrobora que el dato pasado por parámetro se encuentre en los rangos correspondientes en base a la nacionalidad
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato">El dni a validar</param>
        /// <returns>El dato validado</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if(nacionalidad == ENacionalidad.Argentino && dato>1 && dato< 89999999 ||
                nacionalidad == ENacionalidad.Extranjero && dato > 90000000 && dato < 99999999)
            {
                return dato;
            }
            else
            {
                throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI");
            }
        }

        /// <summary>
        /// Corrobora que el formato del dato pasado sea correcto
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato">El dni a validar</param>
        /// <returns>El dato validado</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            if (String.IsNullOrEmpty(dato) || !int.TryParse(dato, out int intDni) || dato.Length > 8)
            {
                throw new DniInvalidoException("El formato del dni ingresado no es correcto");
            }
            else
            {
                return ValidarDni(nacionalidad, intDni);
            }
        }

        /// <summary>
        /// Valida que la cadena de caracteres pasada por parámetro sea válida para un nombre o apellido
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private string ValidarNombreApellido(string dato)
        {
            string retorno = String.Empty;
            if (!String.IsNullOrEmpty(dato) && dato.Length >= 3)
            {
                retorno = dato;
                for (int i = 0 ; i< dato.Length ; i++)
                {
                    if (Char.IsDigit(dato[i]))
                    {
                        retorno = String.Empty;
                        break;
                    }
                }
            }
            return retorno;
        }
        #endregion
    }
}
