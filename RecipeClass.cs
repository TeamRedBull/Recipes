using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1
{
    class Recipe
    {
        public List <string>  ingredients {get; set;}
        public string RecipeName { get; set; }
        public string RecipeDirections { get; set; }
        public string Comments { get; set; }
        public string RecipeType { get; set; }
        public string Yeild { get; set; }
        public string ServingSize { get; set; } 
    }
    
}
