using System;
using System.Collections.Generic;
using System.Data;
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
        CdSearchSystem.infosys202214DataSetIdPass infosys202214DataSetIdPass;
        CdSearchSystem.infosys202214DataSetIdPassTableAdapters.UserIdPassTableTableAdapter idPassTableTableAdapter;
        System.Windows.Data.CollectionViewSource CollectionViewSource;

        public UserRegistration() {
            InitializeComponent();
        }

        private void registration_Click(object sender, RoutedEventArgs e) {
            
            //テキストボックスの空白判定
            if (userId.Text != "" && userpass.Text != "" && passcheck.Text != "") {
                //パスワードと再確認用のパスワードの判定
                if (userpass.Text == passcheck.Text) {
                    DataRow newDrv = (DataRow)infosys202214DataSetIdPass.UserIdPassTable.NewRow();
                    newDrv[0] = userId.Text;
                    newDrv[1] = userpass.Text;
                    //データセットに新しいレコードを追加
                    infosys202214DataSetIdPass.UserIdPassTable.Rows.Add(newDrv);
                    //データベース更新
                    idPassTableTableAdapter.Update(infosys202214DataSetIdPass.UserIdPassTable);

                    Window1 window1 = new Window1();
                    window1.user(newDrv[0].ToString(),newDrv[1].ToString());
                    window1.Show();
                    this.Close();

                } else if (userpass.Text != passcheck.Text) {
                    MessageBox.Show("パスワードが違う");
                }
            } else if (userpass.Text == "" || userpass.Text == "" || passcheck.Text == "") {
                MessageBox.Show("パスワード又はIDが入力されていません");
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Window1 window1 = new Window1();
            window1.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            infosys202214DataSetIdPass = ((CdSearchSystem.infosys202214DataSetIdPass)(this.FindResource("infosys202214DataSetIdPass")));
            idPassTableTableAdapter = new CdSearchSystem.infosys202214DataSetIdPassTableAdapters.UserIdPassTableTableAdapter();
            idPassTableTableAdapter.Fill(infosys202214DataSetIdPass.UserIdPassTable);
            CollectionViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("CollectionViewSource")));
            CollectionViewSource.View.MoveCurrentToFirst();
        }
    }
}
