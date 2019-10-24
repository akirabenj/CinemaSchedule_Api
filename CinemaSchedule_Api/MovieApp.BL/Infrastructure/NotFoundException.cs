using System;
using System.Collections.Generic;
using System.Text;

namespace MovieApp.BL.Infrastructure
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name) : base
            ($"Items (or item) '{name}' was not found.")
        { 
        }
    }
}
