using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using static CdSearchSystem.RakutenAPI;
using Newtonsoft.Json;



namespace CdSearchSystem {
    /// <summary>
    /// Serch.xaml の相互作用ロジック
    /// </summary>
    public partial class Serch : Window {

        WebClient wc = new WebClient() { Encoding = Encoding.UTF8 };
        string cdName;

        public Serch() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Window2 window2 = new Window2();
            window2.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            artistName.Clear();
            title.Clear();
            label.Clear();
            jan.Clear();
        }

        private void btSearch_Click(object sender, RoutedEventArgs e) {
            CheckName();
            var json = JsonConvert.DeserializeObject<Rootobject>(cdName);


            ex.Text = json.Items[0].Item.jan;

        }
        private void CheckName() {
            string aname = artistName.Text;
            string url = "https://app.rakuten.co.jp/services/api/BooksCD/Search/20170404?format=json&artistName="+aname+"&booksGenreId=002&applicationId=1083313806659590350";
            cdName = wc.DownloadString(url);


        }
    }
}
