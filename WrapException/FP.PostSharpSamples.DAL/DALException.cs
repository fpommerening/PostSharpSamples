﻿using System;

namespace FP.PostSharpSamples.DAL
{
    public class DALException : Exception
    {
        public DALException(string message, object[] arguments)
            : base(message)
        {
            Arguments = arguments;
        }

        public DALException(string message, Exception innerException, object[] arguments) : base(message, innerException)
        {
            Arguments = arguments;
        }

        public object[] Arguments { get; private set; }
    }
}
