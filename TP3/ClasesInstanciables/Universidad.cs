using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using Archivos;
using Excepciones;


namespace ClasesInstanciables
{
    [Serializable]
    public class Universidad
    {
        #region Atributos
        List<Alumno> alumnos;
        List<Jornada> jornada;
        List<Profesor> profesores;
        #endregion

        public enum EClases { Programacion, Laboratorio, Legislacion, SPD }

        #region Properties&Indexers
        public List<Alumno> Alumnos
        {
            get { return this.alumnos; }
            set { this.alumnos = value; }
        }

        public List<Profesor> Instructores
        {
            get { return this.profesores; }
            set { this.profesores = value; }
        }

        public List<Jornada> Jornadas
        {
            get { return this.jornada; }
            set { this.jornada = value; }
        }

        public Jornada this[int i]
        {
            get 
            { 
                if( i >= 0 && i < this.jornada.Count)
                {
                    return this.jornada[i];
                }
                return null;
                
            }
            set
            {
                if (i >= 0 && i < this.jornada.Count)
                {
                    this.jornada[i] = value;
                }
            }
        }
        #endregion

        #region Constructor
        public Universidad()
        {
            alumnos = new List<Alumno>();
            jornada = new List<Jornada>();
            profesores = new List<Profesor>();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Guarda el objeto como un arvhivo Xml
        /// </summary>
        /// <param name="uni"></param>
        /// <returns>True on success false on fail</returns>
        public static bool Guardar(Universidad uni)
        {
            Xml<Universidad> xmlManager = new Xml<Universidad>();
            return xmlManager.Guardar("Universidad.xml", uni);
        }

        /// <summary>
        /// Crea un objeto a partir de los datos leidos de un archivo Xml
        /// </summary>
        /// <param name="uni"></param>
        public static Universidad Leer()
        {
            Xml<Universidad> xmlManager = new Xml<Universidad>();
            Universidad uni = new Universidad();
            if (xmlManager.Leer("Universidad.xml", out uni))
            {
                return uni;
            }
            return null;
        }

        /// <summary>
        /// Devuelve los datos del objeto como una cadena de caracteres
        /// </summary>
        /// <param name="uni"></param>
        private static string MostrarDatos(Universidad uni)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA:");
            foreach (Jornada jornada in uni.Jornadas)
            {
                sb.AppendLine(jornada.ToString());
            }
            return sb.ToString();
        }

        public override string ToString()
        {
            return MostrarDatos(this);
        }

        #endregion

        #region Operadores
        public static bool operator !=(Universidad g, Alumno a)
        {
            if (g == a)
            {
                return false;
            }            
            return true;
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            if (g == i)
            {
                return false;
            }
            return true;
        }

        public static Profesor operator !=(Universidad u, EClases clase)
        {
            if (!(u is null))
            {
                foreach (Profesor profesor in u.profesores)
                {
                    if (profesor != clase)
                    {
                        return profesor;
                    }
                }
            }
            throw new SinProfesorException();
        }

        public static Universidad operator +(Universidad g, EClases clase)
        {
            if (!(g is null))
            {
                Profesor unProfesor = (g == clase);
                Jornada nuevaJornada = new Jornada(clase, unProfesor);
                foreach (Alumno alumno in g.Alumnos)
                {
                    if (alumno == clase)
                    {
                        nuevaJornada += alumno;
                    }
                }
                g.Jornadas.Add(nuevaJornada);
            }
            return g;
        }

        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (!(u is null) && !(a is null))
            {
                if (u.Alumnos.Contains(a))
                {
                    throw new AlumnoRepetidoException();
                }
                else
                {
                    u.Alumnos.Add(a);
                }
            }
            return u;
        }

        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (!(u is null) && !(i is null))
            {
                if (!(u.Instructores.Contains(i)))
                {
                    u.Instructores.Add(i);
                }
            }
            return u;
        }

        public static bool operator ==(Universidad g, Alumno a)
        {
            if (!(g is null) && !(a is null))
            {
                if (g.Alumnos.Contains(a))
                {
                    return true;
                }
            }
            return false;
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            if (!(g is null) && !(i is null))
            {
                if (g.Instructores.Contains(i))
                {
                    return true;
                }
            }
            return false;
        }

        public static Profesor operator ==(Universidad u, EClases clase)
        {
            if(!(u is null))
            {
                foreach (Profesor profesor in u.profesores)
                {
                    if (profesor == clase)
                    {
                        return profesor;
                    }
                }
            }
            throw new SinProfesorException();
        }
        #endregion
    }
}

