using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RecipeErrorClass
{
    public static class RecipeErrorClass
    {
        private static string recipeerror;   // the name field
        public static string RecipeError   // the Name property
        {
            get{ return recipeerror;}
            set { recipeerror = value; }
        }

        public static void ErrorLogger()
        {
            throw new System.NotImplementedException();
        }
    }
}
