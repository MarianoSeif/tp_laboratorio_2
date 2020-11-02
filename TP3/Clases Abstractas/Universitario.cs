using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ClasesAbstractas
{
    public abstract class Universitario : Persona
    {
        protected int legajo;

        #region Constructores
        public Universitario()
        {
        }
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad): base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los datos del objeto como cadena de caracteres
        /// </summary>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"Legajo Numero: {this.legajo}");
            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Universitario u = (Universitario)obj;
                return (this.dni == u.dni) || (this.legajo == u.legajo);
            }
        }
        #endregion

        #region Operadores
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if(pg1.GetType() == pg2.GetType() && (pg1.legajo == pg2.legajo || pg1.dni == pg2.dni))
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            if (pg1 == pg2)
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
