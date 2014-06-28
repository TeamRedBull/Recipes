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
using System.Windows.Shapes;

namespace Recipes
{
    /// <summary>
    /// Interaction logic for KeywordWindow.xaml
    /// </summary>
    public partial class KeywordWindow : Window
    {
        public KeywordWindow()
        {
            InitializeComponent();
            SearchTextBox.Focus();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        public String SearchTerms
        {
            get { return SearchTextBox.Text; }
        }
    }
}
