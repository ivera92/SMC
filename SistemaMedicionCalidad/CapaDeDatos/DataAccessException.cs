﻿using System;

namespace Project.CapaDeDatos
{
    public class DataAccessException : ApplicationException
    {
        public DataAccessException(string msg1, Exception msg2)
            : base(msg1, msg2) //herencia de base
        {
        }
        public DataAccessException(string msg)
            : base(msg)
        {
        }
    }
}
