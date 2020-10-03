using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades
{
    public class Sedan : Vehiculo
    {
        public enum ETipo { CuatroPuertas, CincoPuertas }
        ETipo tipo;

        /// <summary>
        /// Constructor reutilizando codigo del constructor de la clase Padre
        /// Por defecto, TIPO será CuatroPuertas
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color) : base(marca, chasis, color)
        {
            tipo = ETipo.CuatroPuertas;
            tamanio = ETamanio.Mediano;
        }

        /// <summary>
        /// Sobrecarga del Constructor reutilizando codigo del constructor anterior
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="chasis"></param>
        /// <param name="color"></param>
        public Sedan(EMarca marca, string chasis, ConsoleColor color, ETipo tipo) : this(marca, chasis, color)
        {
            this.tipo = tipo;   
        }

        /// <summary>
        /// Los automoviles son medianos
        /// </summary>
        public override ETamanio Tamanio
        {
            get{ return this.tamanio; }
        }

        /// <summary>
        /// Devuelve una cadena con información del objeto
        /// </summary>
        /// <returns></returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("SEDAN");
            sb.AppendLine((string)this);
            sb.AppendLine($"TAMAÑO : {this.Tamanio}");
            sb.AppendLine("TIPO : " + this.tipo);
            sb.AppendLine("");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
