using CdSearchSystem.infosys202214DataSetIdPassTableAdapters;
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
    /// Window1.xaml の相互作用ロジック
    /// </summary>
    public partial class Window1 : Window {
        string pass;
        string id;

        CdSearchSystem.infosys202214DataSetUserPassID infosys202214DataSetUserPassID;
        CdSearchSystem.infosys202214DataSetUserPassIDTableAdapters.UserIdPassTableTableAdapter UserIdPassTableTableAdapter;
        System.Windows.Data.CollectionViewSource CollectionViewSource;


        public Window1() {

            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e) {

            DataTable dt;
            dt = infosys202214DataSetUserPassID.Tables["UserIdPassTable"];

            foreach (DataRow item in dt.Rows) {
                Console.WriteLine(item["UserId"].ToString(), item["Pass"].ToString());

                if (tbId.Text == item["UserId"].ToString() && tbPass.Password == item["Pass"].ToString()) {
                    Window2 window2 = new Window2();
                    window2.Show();
                    this.Close();
                    return;
                }
                if (item == infosys202214DataSetUserPassID.UserIdPassTable.Last()) {
                    check.Content = "ユーザー名又はパスワードが違います。";
                }
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
            infosys202214DataSetUserPassID = ((CdSearchSystem.infosys202214DataSetUserPassID)(this.FindResource("infosys202214DataSetUserPassID")));
            UserIdPassTableTableAdapter = new CdSearchSystem.infosys202214DataSetUserPassIDTableAdapters.UserIdPassTableTableAdapter();
            UserIdPassTableTableAdapter.Fill(infosys202214DataSetUserPassID.UserIdPassTable);
            CollectionViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("CollectionViewSource")));
            CollectionViewSource.View.MoveCurrentToFirst();
            tbId.Text = "bbbb";
            tbPass.Password = "1111";
        }

        public void user(object passDate, object idDate) {
            pass = (string)passDate;
            id = (string)idDate;
        }
    }
}
