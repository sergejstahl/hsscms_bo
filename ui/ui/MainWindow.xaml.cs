using System;
using System.Collections.Generic;
using System.Configuration;
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
using dal.Tools;

namespace ui
{
    

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Import json Organisation?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                StarterImportJson starterImportJson = new StarterImportJson();
                string timeSec = starterImportJson.ImportFileJson(ConfigurationManager.AppSettings["pathImportJsonPredpr"]);

                MessageBox.Show($"Import complited, {timeSec}", "Result");
            }
        }

        private void Button_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Erase Organisation?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                StarterImportJson starterImportJson = new StarterImportJson();
                string timeSec = starterImportJson.EraseOrganisations();

                MessageBox.Show($"Erase Organisation, {timeSec}", "Result");
            }
        }
    }
}
