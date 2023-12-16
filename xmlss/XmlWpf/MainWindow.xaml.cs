using System;
using System.Collections.Generic;
using System.IO;
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
using xmlss;

namespace XmlWpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Valutes> valutes;
        public MainWindow()
        {
            InitializeComponent();
            string xmlText = File.ReadAllText("valutes.xml");
            valutes=Data.ValuteLoader.LoadValutes(xmlText);
            FromComboBox.ItemsSource = valutes;
            FromComboBox.DisplayMemberPath = "Name";
            ToComboBox.ItemsSource = valutes;
            ToComboBox.DisplayMemberPath = "Name";
        }

        private void FilterText(object sender, TextCompositionEventArgs e)
        {
            if (!int.TryParse(e.Text, out int x))
            {
                e.Handled = true;
            }
        }

        private void Calcutale(object sender, TextChangedEventArgs e)
        {
            Valutes inValute=FromComboBox.SelectedItem as Valutes;
            Valutes outValute=ToComboBox.SelectedItem as Valutes;
            if (inValute==null || outValute == null)
            {
                return;
            }
            int value;
            bool succ=int.TryParse(InputBox.Text,out value);
            if (!succ) return;

            double rubles = value * inValute.Value;
            double result=rubles/outValute.Value;
            OutputBox.Text = result.ToString();
        }
    }
}
