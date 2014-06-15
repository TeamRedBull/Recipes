using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeErrorClass
{
    public class RecipeError
    {
        public string ErrorMsg { get; set; }

        public void WriteError()
        {
            throw new System.NotImplementedException();
        }
    }
}
