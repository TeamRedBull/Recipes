using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeClassLibrary
{
  public class RecipesCollection
  {
    private List<RecipeItem> _recipes;

    public RecipesCollection()
    {
      _recipes = new List<RecipeItem>();
    }

    public void AddRecipe(RecipeItem newRecipe)
    {
      _recipes.Add(newRecipe);
    }

    public List<RecipeItem> ToList()
    {
      return _recipes.ToList();
    }
  }
}
