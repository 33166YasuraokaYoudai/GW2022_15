using CdSearchSystem.infosys202214DataSetIdPassTableAdapters;
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
using System.Windows.Shapes;

namespace CdSearchSystem {
    /// <summary>
    /// Window1.xaml の相互作用ロジック
    /// </summary>
    public partial class Window1 : Window {

        public Window1() {

            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e) {

            if (tbId.Text == "" || tbPass.Password == "") {
                check.Content = "ID又は、パスワードが違います。";
            } else {
                StreamReader sr = new StreamReader(@"C:\Users\infosys\Documents\UserInfo.txt");
                while (sr.Peek() > -1) {
                    string s = sr.ReadLine();
                    string[] s_array = s.Split(',');

                    if (s_array[0] == tbId.Text && s_array[1] == tbPass.Password) {
                        
                        Window2 window2 = new Window2();
                        window2.Show();
                        this.Close();
                    } else {
                        check.Content = "パスワード又はIDが違います。";
                        tbPass.Clear();                    
                    }
                }
                sr.Close();
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
        private void Window_Loaded(object sender, RoutedEventArgs e) {
        }
    }
}
