using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using ClasesAbstractas;


namespace ClasesInstanciables
{
    public sealed class Alumno : Universitario
    {
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        public enum EEstadoCuenta {AlDia, Deudor, Becado}

        #region Constructores
        public Alumno()
        {
        }

        public Alumno(
            int id,
            string nombre,
            string apellido,
            string dni,
            ENacionalidad nacionalidad,
            Universidad.EClases claseQueToma): base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }

        public Alumno(
            int id,
            string nombre,
            string apellido,
            string dni,
            ENacionalidad nacionalidad,
            Universidad.EClases claseQueToma,
            EEstadoCuenta estadoCuenta): this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Devuelve los datos del objeto como cadena de caracteres
        /// </summary>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine($"Estado de cuenta: {this.estadoCuenta}");
            sb.AppendLine(ParticiparEnClase());
            return sb.ToString();
        }
        
        /// <summary>
        /// Informa la clase que toma el alumno en formato cadena de caracteres
        /// </summary>
        protected override string ParticiparEnClase()
        {
            return $"Toma clases de: {this.claseQueToma}";
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if (!(a is null) && a.claseQueToma == clase)
            {
                if (a.estadoCuenta != EEstadoCuenta.Deudor)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            if (a == clase)
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
