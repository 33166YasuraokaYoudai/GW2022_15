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

        CdSearchSystem.infosys202214DataSetUserPassID infosys202214DataSetUserPassID;
        CdSearchSystem.infosys202214DataSetUserPassIDTableAdapters.UserIdPassTableTableAdapter UserIdPassTableTableAdapter;
        System.Windows.Data.CollectionViewSource CollectionViewSource;


        public UserRegistration() {
            InitializeComponent();
        }

        private void registration_Click(object sender, RoutedEventArgs e) {
            DataRow dr = (DataRow)infosys202214DataSetUserPassID.UserIdPassTable.NewRow();

            DataTable dt;
            dt = infosys202214DataSetUserPassID.Tables["UserIdPassTable"];
            

            //ちゃんと入力されているか
            if (!(userId.Text == "" || userpass.Password == "" || passcheck.Password == "")) {
                //ユーザーIDは4文字以上12文字以内、パスワードは4文字
                if (userId.Text.Length >= 4 && userId.Text.Length < 12 && userpass.Password.Length >= 4 && userpass.Password.Length < 12) {
                    //入力したパスワードと確認用のパスワードが一致しているか
                    if (userpass.Password == passcheck.Password) {
                       
                        try {
                            foreach (DataRow row in dt.Rows) {
                                Console.WriteLine(row["UserId"].ToString());

                                if (userId.Text == row["UserId"].ToString()) {
                                    check.Content = null;
                                    check.Content = "既に存在しています。";
                                    return;
                                }
                                if (row == infosys202214DataSetUserPassID.UserIdPassTable.Last()) {
                                    dr[1] = userId.Text;
                                    dr[2] = userpass.Password;
                                    infosys202214DataSetUserPassID.UserIdPassTable.Rows.Add(dr);
                                    UserIdPassTableTableAdapter.Update(infosys202214DataSetUserPassID.UserIdPassTable);
                                    Window1 window1 = new Window1();
                                    window1.Show();
                                    this.Close();

                                }

                            }

                        }
                        catch (Exception) {

                     
                        }

                    } else {
                        check.Content = "再確認用のパスワードが一致しません";
                    }
                } else {
                    check.Content = "４桁以上12桁未満にしてください。";
                }

            } else {
                check.Content = "パスワード又はIDが入力されていません。";
            }


        }

            private void Button_Click(object sender, RoutedEventArgs e) {
            Window1 window1 = new Window1();
            window1.Show();
            this.Close();

            
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {

            infosys202214DataSetUserPassID = ((CdSearchSystem.infosys202214DataSetUserPassID)(this.FindResource("infosys202214DataSetUserPassID")));
            UserIdPassTableTableAdapter = new CdSearchSystem.infosys202214DataSetUserPassIDTableAdapters.UserIdPassTableTableAdapter();
            UserIdPassTableTableAdapter.Fill(infosys202214DataSetUserPassID.UserIdPassTable);
            CollectionViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("CollectionViewSource")));
            CollectionViewSource.View.MoveCurrentToFirst();
        }

       
    }
}
