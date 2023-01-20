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
using System.Collections.ObjectModel;
using System.Data;

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

        //一つ前に戻る処理
        private void Button_Click(object sender, RoutedEventArgs e) {
            Window2 window2 = new Window2();
            window2.Show();
            this.Close();
        }


        private void Button_Click_1(object sender, RoutedEventArgs e) {
            Clear();
        }



        private void btSearch_Click(object sender, RoutedEventArgs e) {
            NameSearch();

            var json = JsonConvert.DeserializeObject<Rootobject>(cdName);

            //DataGridにデータを入れる処理
            //datainfo.ItemsSource = new ObservableCollection<searchContents> {
            //    new searchContents {ArtistName = json.Items[0].Item.artistName,
            //                        Title = json.Items[0].Item.title,
            //                        Label = json.Items[0].Item.label,
            //                        Jan = json.Items[0].Item.jan,
            //                        ItemPrice = json.Items[0].Item.itemPrice,
            //    },
            //    new searchContents {ArtistName = json.Items[1].Item.artistName,
            //                        Title = json.Items[1].Item.title,
            //                        Label = json.Items[1].Item.label,
            //                        Jan = json.Items[1].Item.jan,
            //                        ItemPrice = json.Items[1].Item.itemPrice,
            //    },

            //};



            a(json);




        }

        private void a(Rootobject json) {


            //datainfo.ItemsSource = new ObservableCollection<searchContents> {
            //        new searchContents {
            //            ArtistName = json.Items[0].Item.artistName,
            //            Title = json.Items[0].Item.title,
            //            Label = json.Items[0].Item.label,
            //            Jan = json.Items[0].Item.jan,
            //            ItemPrice = json.Items[0].Item.itemPrice
            //        }
            //};

            for (int i = 0; i < json.hits; i++) {

                datainfo.ItemsSource = new ObservableCollection<searchContents> {
                    new searchContents {
                        ArtistName = json.Items[i].Item.artistName,
                        Title = json.Items[i].Item.title,
                        Label = json.Items[i].Item.label,
                        Jan = json.Items[i].Item.jan,
                        ItemPrice = json.Items[i].Item.itemPrice
                    }

            };
                


            }

        }

        //入力されたデータを消去する処理
        private void Clear() {
            artistName.Clear();
            title.Clear();
            label.Clear();
            jan.Clear();
        }

        //入力した名前を検索する処理
        private void NameSearch() {
            string aname = artistName.Text;
            string url = "https://app.rakuten.co.jp/services/api/BooksCD/Search/20170404?format=json&artistName="+aname+"&booksGenreId=002&applicationId=1083313806659590350";
            cdName = wc.DownloadString(url);
        }
    }
}
