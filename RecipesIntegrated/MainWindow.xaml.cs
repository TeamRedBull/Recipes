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


namespace Recipes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
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
            }

        }
    }
}
