using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using ClasesAbstractas;
using Archivos;

namespace ClasesInstanciables
{
    public class Jornada
    {
        #region Atributos
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;
        #endregion

        #region Propiedades
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }
        public Universidad.EClases Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }
        public Profesor Instructor
        {
            get { return this.instructor; }
            set { this.instructor = value; }
        }
        #endregion

        #region Constructores
        private Jornada()
        {
            alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor): this()
        {
            Clase = clase;
            Instructor = instructor;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Guarda la jornada referenciada por parametro
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>True on success false on fail</returns>
        public static bool Guardar(Jornada jornada)
        {
            if(!(jornada is null))
            {
                Texto txtManager = new Texto();
                return txtManager.Guardar("Jornada.txt", jornada.ToString());
            }            
            return false;
        }

        /// <summary>
        /// Lee un archivo de jornadas y devuelve los datos como una cadena de caracteres
        /// </summary>
        /// <param name="jornada"></param>
        /// <returns>True on success false on fail</returns>
        public static string Leer()
        {
            string datos;
            Texto txtManager = new Texto();
            if (txtManager.Leer("Jornada.txt", out datos))
            {
                return datos;
            }
            return String.Empty;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Clase de {this.clase} por {this.instructor}");
            sb.AppendLine("ALUMNOS:");
            foreach (Alumno alumno in this.alumnos)
            {
                sb.AppendLine(alumno.ToString());
            }
            sb.AppendLine("<------------------------------------------------------------->");
            return sb.ToString();
        }
        #endregion

        #region Operadores
        public static bool operator !=(Jornada j, Alumno a)
        {
            if (!(j is null) && !(a is null))
            {
                if (j == a)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool operator ==(Jornada j, Alumno a)
        {
            if(!(j is null) && !(a is null))
            {
                if (j.alumnos.Contains(a))
                {
                    return true;
                }
            }
            return false;
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            if (!(j is null) && !(a is null))
            {
                if (!j.alumnos.Contains(a))
                {
                    j.alumnos.Add(a);
                }
            }
            return j;
        }
        #endregion
    }
}
