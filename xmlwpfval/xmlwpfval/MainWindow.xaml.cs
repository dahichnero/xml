using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using xmlwpfval.Model;
using System.Net.Http;

namespace xmlwpfval
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Valutes> valutes;
        public MainWindow()
        {
            InitializeComponent();
            /*string xmlText = File.ReadAllText("data/valutes.xml");
            valutes = Data.ValuteLoader.LoadValutes(xmlText);
            valutes.Insert(0, new Valutes { Namee = "Российский рубль", Valuee = 1, CharCodee = "RUB" });
            FromComboBox.ItemsSource = valutes;
            ToComboBox.ItemsSource = valutes;*/
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            try
            {
                HttpClient client = new HttpClient();
                var respose = client.GetAsync("https://www.cbr.ru/scripts/XML_daily.asps")
                    .GetAwaiter().GetResult();
                var text = respose.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                valutes = Data.ValuteLoader.LoadValutes(text);
                FromComboBox.ItemsSource = valutes;
                ToComboBox.ItemsSource = valutes;
            }
            catch
            {
                MessageBox.Show("Нет подключения. Загружаем файл...");
                string xmlText = File.ReadAllText("data/valutes.xml");
                valutes = Data.ValuteLoader.LoadValutes(xmlText);
                valutes.Insert(0, new Valutes { Namee = "Российский рубль", Valuee = 1, CharCodee = "RUB" });
                FromComboBox.ItemsSource = valutes;
                ToComboBox.ItemsSource = valutes;
            }
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
            Valutes inValute = FromComboBox.SelectedItem as Valutes;
            Valutes outValute = ToComboBox.SelectedItem as Valutes;
            if (inValute == null || outValute == null)
            {
                return;
            }
            int value;
            bool succ = int.TryParse(InputBox.Text, out value);
            if (!succ) return;

            double rubles = value * inValute.Valuee;
            double result = rubles / outValute.Valuee;
            result = Math.Round(result, 2);
            OutputBox.Text = result.ToString();
        }
    }
}
