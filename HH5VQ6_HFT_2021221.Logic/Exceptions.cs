﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HH5VQ6_HFT_2021221.Logic
{
    class InvalidPlaceException : Exception
    {
        public InvalidPlaceException()
        {
        }

        public InvalidPlaceException(string message) : base(message)
        {
        }
    }
}
