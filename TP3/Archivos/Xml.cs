using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.CompilerServices;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        /// <summary>
        /// Guarda en un archivo los datos pasados por parámetro
        /// </summary>
        /// <param name="archivo">Nombre del archivo</param>
        /// <param name="datos">Datos a escribir</param>
        /// <exception cref="Excepciones.ArchivosException"></exception>
        /// <returns>True on success false on fail</returns>
        public bool Guardar(string archivo, T datos)
        {
            if (datos == null)
            {
                throw new ArchivosException("La fuente de datos no es válida");
            }
            else
            {
                try
                {
                    using (XmlTextWriter fileWriter = new XmlTextWriter(archivo, Encoding.UTF8))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(T));
                        serializer.Serialize(fileWriter, datos);
                    }
                }
                catch (Exception e)
                {
                    throw new ArchivosException(e);
                }
            }
            return true;
        }

        /// <summary>
        /// Lee un archivo y carga los datos en la variable referenciada por parámetro
        /// </summary>
        /// <param name="archivo">Nombre del archivo</param>
        /// <param name="datos">Destino de los datos leidos</param>
        /// <exception cref="Excepciones.ArchivosException"></exception>
        /// <returns>True on success false on fail</returns>
        public bool Leer(string archivo, out T datos)
        {
            if (File.Exists(archivo))
            {
                try
                {
                    using (XmlTextReader fileReader = new XmlTextReader("Universidad.xml"))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(T));
                        datos = (T)serializer.Deserialize(fileReader);
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