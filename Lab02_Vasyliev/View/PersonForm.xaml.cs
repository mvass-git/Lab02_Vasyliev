using Lab02_Vasyliev.ViewModel;
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
using Lab02_Vasyliev.ViewModel;

namespace Lab02_Vasyliev.View
{
    /// <summary>
    /// Interaction logic for PersonForm.xaml
    /// </summary>
    public partial class PersonForm : Window
    {
        private PersonFormViewModel _viewModel;
        public PersonForm()
        {
            InitializeComponent();
            DataContext = _viewModel = new PersonFormViewModel();
        }

        private void BProceed_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.Proceed();
        }
    }
}
