//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Recipes
{
    using System;
    using System.Collections.Generic;
    
    public partial class Recipe
    {
        public Recipe()
        {
            this.Ingredients = new HashSet<Ingredient>();
        }
    
        public int RecipeID { get; set; }
        public string Title { get; set; }
        public string Yield { get; set; }
        public string ServingSize { get; set; }
        public string Directions { get; set; }
        public string Comment { get; set; }
        public string RecipeType { get; set; }
    
        public virtual ICollection<Ingredient> Ingredients { get; set; }
    }
}
