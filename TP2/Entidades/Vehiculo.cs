using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    /// <summary>
    /// La clase Vehiculo no deberá permitir que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Vehiculo
    {
        protected string chasis;
        protected ConsoleColor color;
        protected EMarca marca;
        protected ETamanio tamanio;
        
        public enum EMarca
        {
            Chevrolet, Ford, Renault, Toyota, BMW, Honda, HarleyDavidson
        }
        public enum ETamanio
        {
            Chico, Mediano, Grande
        }
        

        /// <summary>
        /// ReadOnly: Retornará el tamaño
        /// </summary>
        public abstract ETamanio Tamanio { get; }

        public Vehiculo(EMarca marca, string chasis, ConsoleColor color)
        {
            this.chasis = chasis;
            this.marca = marca;
            this.color = color;
        }

        /// <summary>
        /// Publica todos los datos del Vehiculo.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return (string)this;
        }

        /// <summary>
        /// Sobrecarga para hacer casteo explicito de objeto tipo Vehiculo a string
        /// </summary>
        /// <param name="p"></param>
        public static explicit operator string (Vehiculo p)
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine($"CHASIS: {p.chasis}");
            sb.AppendLine($"MARCA : {p.marca.ToString()}");
            sb.AppendLine($"COLOR : {p.color.ToString()}");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos vehiculos son iguales si comparten el mismo chasis
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis == v2.chasis);
        }
        /// <summary>
        /// Dos vehiculos son distintos si su chasis es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vehiculo v1, Vehiculo v2)
        {
            return (v1.chasis != v2.chasis);
        }
    }
}
