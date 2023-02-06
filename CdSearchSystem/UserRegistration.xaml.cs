using System;
using System.Collections.Generic;
using System.Data;
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
    /// UserRegistration.xaml の相互作用ロジック
    /// </summary>
    public partial class UserRegistration : Window {

       


        public UserRegistration() {
            InitializeComponent();
        }

        private void registration_Click(object sender, RoutedEventArgs e) {

            if (userId.Text.Length >= 4 && userId.Text.Length <= 12 && userpass.Password.Length == 4) {
                if (userId.Text != "" && userpass.Password != "" && passcheck.Password != "") {
                    //パスワードと再確認用のパスワードの判定
                    if (userpass.Password == passcheck.Password) {
                        StreamWriter sw = new StreamWriter(@"C:\Users\infosys\Documents\UserInfo.txt", true);
                        string s = userId.Text + "," + passcheck.Password;
                        sw.WriteLine(s);
                        sw.Close();

                        Window1 window1 = new Window1();
                        //window1.user(newDrv[0].ToString(), newDrv[1].ToString());
                        window1.Show();
                        this.Close();

                    } else if (!(userpass.Password == passcheck.Password) || (!(userpass.Password.Length == 4 || passcheck.Password.Length == 4))) {
                        check.Content = "パスワードが違う。";
                    }

                } else if (userId.Text == "" || userpass.Password == "" || passcheck.Password == "") {
                    check.Content = "パスワード又はIDが入力されていません。";
                }

            }else if(!(userId.Text.Length >= 4 && userId.Text.Length <= 12 || !(userpass.Password.Length == 4))) {
                check.Content = "桁が多いか少ない";
            }
        }

            private void Button_Click(object sender, RoutedEventArgs e) {
            Window1 window1 = new Window1();
            window1.Show();
            this.Close();

            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
        }

       
    }
}
