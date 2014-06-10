using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ErrorClass
{
    public class ErrorClass
    {
        private string recipeerror;   // the name field
        public string RecipeError   // the Name property
        {
            get{ return recipeerror;}
            set { recipeerror = value; }
        }


        void LogError(string errormsg, object UIControl)
        {
            //method to log error
            //UIControl.Text = errormsg;
        }
    }
}
