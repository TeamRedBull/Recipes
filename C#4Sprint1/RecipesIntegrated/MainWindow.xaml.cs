using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RecipeErrorClass;
using RecipeClassLibrary;


namespace Recipes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private RecipesCollection _recipes = new RecipesCollection();
        bool close = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            ___GBexit_.Visibility = Visibility.Visible;
            

            //if (MessageBox.Show("Are you sure you want to exit the application?", "WARNING", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            //{
            //    this.Close();
            //}
        }

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
          InitializeRecipes();

          titleListBox.DataContext = _recipes.ToList();
        }

        private void InitializeRecipes()
        {
          Recipe recipe1 = new Recipe { RecipeName = "Test1", RecipeType = "AAA", Yield = "AAA", ServingSize = "111", Comments = "AAA", RecipeDirections = "AAA", Ingredients = "AAA"};
          Recipe recipe2 = new Recipe { RecipeName = "Test2", RecipeType = "BBB", Yield = "BBB", ServingSize = "222", Comments = "BBB", RecipeDirections = "BBB", Ingredients = "BBB" };
          Recipe recipe3 = new Recipe { RecipeName = "Test3", RecipeType = "CCC", Yield = "CCC", ServingSize = "333", Comments = "CCC", RecipeDirections = "CCC", Ingredients = "CCC" };

          _recipes.AddRecipe(recipe1);
          _recipes.AddRecipe(recipe2);
          _recipes.AddRecipe(recipe3);
        }
    }
}
