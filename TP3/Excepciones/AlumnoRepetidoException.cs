﻿using System;

namespace Excepciones
{
    public class AlumnoRepetidoException : Exception
    {
        public AlumnoRepetidoException():base("Alumno repetido")
        {
        }

        public AlumnoRepetidoException(string message) : base(message)
        {

        }
    }
}
