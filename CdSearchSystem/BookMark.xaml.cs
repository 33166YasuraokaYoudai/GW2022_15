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
    /// BookMark.xaml の相互作用ロジック
    /// </summary>
    public partial class BookMark : Window {
        CdSearchSystem.infosys202214DataSet infosys202214DataSet;
        CdSearchSystem.infosys202214DataSetTableAdapters.CdsystemTableTableAdapter CdsystemTableTableAdapter;
        System.Windows.Data.CollectionViewSource cdsearchViewSource;

        string title;
        string artistname;
        string label;
        string url;
        string salsedata;
        string jan;
        string itemprice;


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
            artistname = ArtistName;
            label = Label;
            url = Url;
            jan = Jan;
            salsedata = SalseData;
            itemprice = ItemPrice;

        }


        private void Window_Loaded_1(object sender, RoutedEventArgs e) {

            this.infosys202214DataSet = ((CdSearchSystem.infosys202214DataSet)(this.FindResource("infosys202214DataSet")));
            // テーブル CdsystemTable にデータを読み込みます。必要に応じてこのコードを変更できます。
            CdsystemTableTableAdapter = new CdSearchSystem.infosys202214DataSetTableAdapters.CdsystemTableTableAdapter();
            CdsystemTableTableAdapter.Fill(this.infosys202214DataSet.CdsystemTable);
            cdsearchViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("cdsystemTableViewSource")));
            cdsearchViewSource.View.MoveCurrentToFirst();

            //新規レコードの追加
            DataRow newDrv = (DataRow)this.infosys202214DataSet.CdsystemTable.NewRow();
            newDrv[1] = artistname;
            newDrv[2] = title;
            newDrv[3] = label;
            newDrv[4] = salsedata;
            newDrv[5] = itemprice;
            newDrv[6] = url;
            newDrv[7] = jan;

            //データセットに新しいレコードを追加
            this.infosys202214DataSet.CdsystemTable.Rows.Add(newDrv);
            //データベース更新
            CdsystemTableTableAdapter.Update(this.infosys202214DataSet.CdsystemTable);

        }

        private void Delete_Click(object sender, RoutedEventArgs e) {
            //選択行の取り出し
            DataRowView drv = (DataRowView)cdsearchViewSource.View.CurrentItem;
            //選択されたレコードの削除
            drv.Delete();
            //データベース更新
            CdsystemTableTableAdapter.Update(this.infosys202214DataSet.CdsystemTable);

        }
    }
}
