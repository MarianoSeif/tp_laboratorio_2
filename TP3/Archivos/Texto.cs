using System;
using System.IO;
using System.Text;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Guarda en un archivo los datos pasados por parámetro
        /// </summary>
        /// <param name="archivo">Nombre del archivo</param>
        /// <param name="datos">Datos a guardar</param>
        /// <exception cref="Excepciones.ArchivosException"></exception>
        /// <returns>true on success or false on fail</returns>
        public bool Guardar(string archivo, string datos)
        {
            if(!String.IsNullOrEmpty(archivo) && !String.IsNullOrEmpty(datos))
            {
                try
                {
                    using (StreamWriter fileWriter = new StreamWriter(archivo))
                    {
                        fileWriter.Write(datos);
                    }
                }
                catch (Exception e)
                {
                    throw new ArchivosException(e);
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Lee datos de un archivo y los carga en la variable referenciada en el parámetro
        /// </summary>
        /// <param name="archivo">Nombre del archivo</param>
        /// <param name="datos">Destino de los datos leidos</param>
        ///<exception cref="Excepciones.ArchivosException"></exception>
        /// <returns>true on success fals on fail</returns>
        public bool Leer(string archivo, out string datos)
        {
            if (!String.IsNullOrEmpty(archivo) && File.Exists(archivo))
            {
                try
                {
                    using (StreamReader fileReader = new StreamReader(archivo))
                    {
                        datos = fileReader.ReadToEnd();
                    }
                }
                catch (Exception e)
                {
                    throw new ArchivosException(e);
                }
                return true;
            }
            datos = default;
            return false;
        }
    }
}
