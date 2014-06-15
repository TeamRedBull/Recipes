using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeClassLibrary
{
  public class RecipesCollection
  {
    private List<Recipe> _recipes;

    public RecipesCollection()
    {
      _recipes = new List<Recipe>();
    }

    public void AddRecipe(Recipe newRecipe)
    {
      _recipes.Add(newRecipe);
    }

    public List<Recipe> ToList()
    {
      return _recipes.ToList();
    }
  }
}
