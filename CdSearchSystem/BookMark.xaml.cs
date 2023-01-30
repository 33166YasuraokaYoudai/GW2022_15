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
    /// BookMark.xaml の相互作用ロジック
    /// </summary>
    public partial class BookMark : Window {
        CdSearchSystem.infosys202214DataSet1 infosys202214DataSet1;
        CdSearchSystem.infosys202214DataSet1TableAdapters.CdsystemTableTableAdapter CdsystemTableTableAdapter;
        System.Windows.Data.CollectionViewSource cdsearchViewSource;

        string title;

        public BookMark() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Window2 window2 = new Window2();
            window2.Show();
            this.Close();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {

        }

        public void passtitle(String Title,String ArtistName,String Label,String Url,String SalseData,String Jan,String ItemPrice) {
            title = Title;
        }


        private void Window_Loaded_1(object sender, RoutedEventArgs e) {

            infosys202214DataSet1 = ((CdSearchSystem.infosys202214DataSet1)(this.FindResource("infosys202214DataSet1")));
            // テーブル CdsystemTable にデータを読み込みます。必要に応じてこのコードを変更できます。
            CdsystemTableTableAdapter = new CdSearchSystem.infosys202214DataSet1TableAdapters.CdsystemTableTableAdapter();
            CdsystemTableTableAdapter.Fill(infosys202214DataSet1.CdsystemTable);
            cdsearchViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("cdsystemTableViewSource")));
            cdsearchViewSource.View.MoveCurrentToFirst();
        }
    }
}
