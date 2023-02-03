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
    /// Window1.xaml の相互作用ロジック
    /// </summary>
    public partial class Window1 : Window {
        string pass;
        string id;

        public Window1() {

            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
           
            if(tbId.Text == id && tbPass.Password == pass) {
                Window2 window2 = new Window2();
                window2.Show();
                this.Close();
            } else {
                MessageBox.Show("パスワード又はIDが違います");
                tbPass.Clear();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private void NewRegistration_Click(object sender, RoutedEventArgs e) {
            UserRegistration user = new UserRegistration();
            user.Show();
            this.Close();
        }

        public void user(object passDate,object idDate) {
            pass = (string)passDate;
            id = (string)idDate;
        }

    }
}
