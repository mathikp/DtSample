using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Journal dc;
        public MainWindow()
        {
            InitializeComponent();
            dc = new Journal
            {
                Narration = "new narration"
            };
            myPanel.DataContext = dc;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dc.Narration = "clicked";

            //(myPanel.DataContext as Journal).Narration = "clicked";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            dc = new Journal();

            //myPanel.DataContext = new Journal();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            dc.Narration = "updated";

            //(myPanel.DataContext as Journal).Narration = "updated";
        }
    }

    public class Journal : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _Narration;

        public string Narration
        {
            get
            {
                return _Narration;
            }
            set
            {
                _Narration = value;
                OnPropertyChanged();
            }
        }
    }
}
