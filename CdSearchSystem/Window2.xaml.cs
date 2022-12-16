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

namespace CdSearchSystem {
    /// <summary>
    /// Window2.xaml の相互作用ロジック
    /// </summary>
    public partial class Window2 : Window {
        public Window2() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Serch serch = new Serch();
            serch.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            BookMark book = new BookMark();
            book.Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) {
            Window1 window1 = new Window1();
            window1.Show();
            this.Close();
        }
    }
}
