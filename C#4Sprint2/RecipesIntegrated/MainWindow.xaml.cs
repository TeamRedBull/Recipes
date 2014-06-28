using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using RecipeErrorClass;
//using RecipeClassLibrary;
using SearchLibrary;


namespace Recipes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        //private RecipesCollection _recipes = new RecipesCollection();
        bool close = false;
        RecipeOrganizerEntities ro = new RecipeOrganizerEntities();

        public MainWindow()
        {
            InitializeComponent();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{




        //    if (MessageBox.Show("Are you sure you want to exit the application?", "WARNING", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
        //    {
        //        this.Close();
        //    }
        //}

        private void ___No__Checked(object sender, RoutedEventArgs e)
        {
            ___GBexit_.Visibility = Visibility.Hidden;
            ___Errormessagelabel_.Visibility = Visibility.Hidden;
        }

        private void ___Yes__Checked(object sender, RoutedEventArgs e)
        {
            close = true;
            this.Close(); 
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (close != true)
            {
                e.Cancel = true;
                ___Errormessagelabel_.Visibility = Visibility.Visible;

                string message = "Please click the exit button to exit application"; 

                RecipeError EXITERROR = new RecipeError();
                EXITERROR.ErrorMsg = message;

                ___Errormessagelabel_.Content = EXITERROR.ErrorMsg;
            }

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
          //InitializeRecipes();

            var roTitleListBox = LoadRecipes();

          //titleListBox.DataContext = _recipes.ToList();
            TitleListBox.DataContext = roTitleListBox.ToList();
        }

      private IEnumerable<Recipe> LoadRecipes()
      {
        return from recipe in ro.Recipes
               select recipe;
      }

      //private void InitializeRecipes()
        //{
        //  //RecipeItem recipe1 = new RecipeItem { RecipeName = "Test1", RecipeType = "AAA", Yield = "AAA", ServingSize = "111", Comments = "AAA", RecipeDirections = "AAA", Ingredients = "AAA"};
        //  //RecipeItem recipe2 = new RecipeItem { RecipeName = "Test2", RecipeType = "BBB", Yield = "BBB", ServingSize = "222", Comments = "BBB", RecipeDirections = "BBB", Ingredients = "BBB" };
        //  //RecipeItem recipe3 = new RecipeItem { RecipeName = "Test3", RecipeType = "CCC", Yield = "CCC", ServingSize = "333", Comments = "CCC", RecipeDirections = "CCC", Ingredients = "CCC" };

        //  //_recipes.AddRecipe(recipe1);
        //  //_recipes.AddRecipe(recipe2);
        //  //_recipes.AddRecipe(recipe3);
        //}

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            KeywordWindow dialog = new KeywordWindow();
            // To pop the KeywordWindow in the center of parent window
            dialog.Owner = this;
            // If got a return value from dialog window
            if (dialog.ShowDialog() == true)
            {
              // If the string return is not empty
              if (dialog.SearchTerms.Length != 0 && dialog.SearchTerms.Replace("\t", "").Replace(" ","").Length != 0)
              {
                //success....
                // Use StringSplitOptions.RemoveEmptyEntries to remove empty entries
                string[] split = dialog.SearchTerms.Split(new char []{'\t'}, StringSplitOptions.RemoveEmptyEntries);

                List<Recipe> tempRecipes = new List<Recipe>();

                foreach (Recipe r in ro.Recipes)
                {
                  List<string> recipeStrings = new List<string>();
                  recipeStrings.Add(r.Title);
                  recipeStrings.Add(r.RecipeType);
                  recipeStrings.Add(r.ServingSize);
                  recipeStrings.Add(r.Yield);
                  recipeStrings.Add(r.Comment);
                  recipeStrings.Add(r.Directions);
                  recipeStrings.Add(AppendIngredientsToSingleString(SelectIngredients(r.RecipeID)));

                  if (SearchCore.SearchKeywords(split, recipeStrings))
                  {
                    tempRecipes.Add(r);
                  }
                }

                // If found something
                if (tempRecipes.Count != 0)
                {
                  TitleListBox.DataContext = tempRecipes;
                  // Clear selection after each search
                  TitleListBox.SelectedItem = null;
                  ClearDataContexts();
                  ___Errormessagelabel_.Visibility = Visibility.Hidden;
                }
                // If found nothing
                else
                {
                  ___Errormessagelabel_.Visibility = Visibility.Visible;

                  string message = "Item not found";

                  RecipeError SEARCHERROR = new RecipeError();
                  SEARCHERROR.ErrorMsg = message;

                  ___Errormessagelabel_.Content = SEARCHERROR.ErrorMsg;
                }
              }
              else
              {
                ___Errormessagelabel_.Visibility = Visibility.Visible;

                string message = "Input error";

                RecipeError SEARCHERROR = new RecipeError();
                SEARCHERROR.ErrorMsg = message;

                ___Errormessagelabel_.Content = SEARCHERROR.ErrorMsg;
              }
            }
            else
            {
                //message and label for ill forned text or error...
              ___Errormessagelabel_.Visibility = Visibility.Visible;

              string message = "Search canceled";

              RecipeError SEARCHERROR = new RecipeError();
              SEARCHERROR.ErrorMsg = message;

              ___Errormessagelabel_.Content = SEARCHERROR.ErrorMsg;
            }
        }

        private void ClearDataContexts()
        {
          TypeTextBox.DataContext = null;
          YieldTextBox.DataContext = null;
          SizeTextBox.DataContext = null;
          IngredientTextBlock.DataContext = null;
          DirectionsTextBlock.DataContext = null;
          CommentsTextBlock.DataContext = null;
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
          // Deselect an item first so TextBox and TextBlock binded to a recipe object will be cleaned
          TitleListBox.SelectedItem = null;
          // Clear the TextBox and TextBlock modified by the application
          ClearDataContexts();
          // Reload the default from the database
          TitleListBox.DataContext = LoadRecipes().ToList();
          // Hide the message label and exit group box
          ___GBexit_.Visibility = Visibility.Hidden;
          ___Errormessagelabel_.Visibility = Visibility.Hidden;
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            ___GBexit_.Visibility = Visibility.Visible;
        }

        private List<Ingredient> SelectIngredients(int recipeID)
        {
            var ingredients = from ingredient in ro.Ingredients
                              where ingredient.RecipeID == recipeID
                              select ingredient;

            return ingredients.ToList();
        }

        private void TitleListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          // Check if an item is selected
          // (without this check crash happens after search modify the listbox)
          if (RecipeIDLabel.Content != null)
          {
            bool parseOK = false;
            int recipeIDInt;

            string stringRecipeID = RecipeIDLabel.Content.ToString();

            parseOK = int.TryParse(stringRecipeID, out recipeIDInt);
            if (parseOK == false)
            {
              MessageBox.Show("recipe ID of recipe selected is not numeric.");
              return;
            }

            var ingredientsList = SelectIngredients(recipeIDInt);
            string ingredientsString = AppendIngredientsToSingleString(ingredientsList);

            IngredientTextBlock.DataContext = ingredientsString;
            // the following takes out extra space and tabs in the directions (To format better)
            var temp = from recipe in ro.Recipes
                       where recipe.RecipeID == recipeIDInt
                       select recipe.Directions;
            // Only single item in temp, choose the first one.
            string temps = temp.ToArray()[0];

            DirectionsTextBlock.DataContext = temps.Replace("\t", " ").Replace("  ", " ");
            SizeTextBox.ScrollToHome();
            IngredientsScrollViewer.ScrollToTop();
            DirectionsScrollViewer.ScrollToTop();
            CommentsScollViewer.ScrollToTop();

          }
          else
          {
            //Reset the ingredient TextBlock if nothing is selected
            ClearDataContexts();
          }
        }

        private string AppendIngredientsToSingleString(List<Ingredient> ingredients)
        {
          //Use a StringBuilder object to apeend(more efficient than create multiple strings)
          StringBuilder tempSB = new StringBuilder();
          
          foreach (Ingredient s in ingredients)
          {
            tempSB.Append(s.Ingredient1);
            //append a newline char to seperate
            tempSB.Append("\n");
          }

          return tempSB.ToString();
        }
    }
}
