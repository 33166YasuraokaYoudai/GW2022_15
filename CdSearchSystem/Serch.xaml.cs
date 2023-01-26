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
        string aname;
        string cdtitle;



        public Serch() {
            InitializeComponent();
        }

        //一つ前のWindowに戻る処理
        private void Button_Click(object sender, RoutedEventArgs e) {
            Window2 window2 = new Window2();
            window2.Show();
            this.Close();
        }

        //クリアボタン
        private void Button_Click_1(object sender, RoutedEventArgs e) {
            Clear();
        }


        //検索ボタン
        private void btSearch_Click(object sender, RoutedEventArgs e) {
            NameSearch();

            var json = JsonConvert.DeserializeObject<Rootobject>(cdName);

           

            list.Items.Clear();

            //データをリストに入れる
            for (int i = 0; i < json.hits; i++) {
                var cdInfo = new ObservableCollection<searchContents>();
                cdInfo.Add(new searchContents {
                    ArtistName = json.Items[i].Item.artistName,
                    Title = json.Items[i].Item.title,
                    Label = json.Items[i].Item.label,
                    Jan = json.Items[i].Item.jan,
                    
                });

                

                foreach (var item in cdInfo) {
                    list.Items.Add(item);
                }
            }                   

        }

        //入力されたデータを消去する処理
        private void Clear() {
            artistName.Clear();
            title.Clear();
        }

        //入力した名前を検索する処理
        private void NameSearch() {
            aname = artistName.Text;
            cdtitle = title.Text;

            if (artistName.Text != "") {
                string url1 = "https://app.rakuten.co.jp/services/api/BooksCD/Search/20170404?format=json&artistName=" + aname + "&booksGenreId=002&applicationId=1083313806659590350";
                cdName = wc.DownloadString(url1);

            } else if (title.Text != "") {
                string url2 = "https://app.rakuten.co.jp/services/api/BooksCD/Search/20170404?format=json&Title=" + cdtitle + "&booksGenreId=002&applicationId=1083313806659590350";
                cdName = wc.DownloadString(url2);
            }else if (artistName.Text != "" && title.Text != "") {
                string url3 = "https://app.rakuten.co.jp/services/api/BooksCD/Search/20170404?format=json&artistName=" + aname + "&Title=" + cdtitle + "&booksGenreId=002&applicationId=1083313806659590350";
                cdName = wc.DownloadString(url3);
            }

        }



        //ページ変更
        private void Button_Click_2(object sender, RoutedEventArgs e) {
            list.Items.Clear(); 


            var json = JsonConvert.DeserializeObject<Rootobject>(cdName);


            for (int i = 1; i < json.pageCount; i++) {
                string url = "https://app.rakuten.co.jp/services/api/BooksCD/Search/20170404?format=json&artistName=" + aname + "&page=" + i + "&booksGenreId=002&applicationId=1083313806659590350";
                cdName = wc.DownloadString(url);

            }

            for (int i = 0; i < json.hits; i++) {
                var cdInfo = new ObservableCollection<searchContents>();
                cdInfo.Add(new searchContents {
                    ArtistName = json.Items[i].Item.artistName,
                    Title = json.Items[i].Item.title,
                    Label = json.Items[i].Item.label,
                    Jan = json.Items[i].Item.jan,
                });



                foreach (var item in cdInfo) {
                    list.Items.Add(item);
                }
            }
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (list.SelectedItem == null) return ;
            searchContents item = (searchContents)list.SelectedItem;
            infoname.Text = item.ArtistName;
            infotitle.Text = item.Title;
            infolabel.Text = item.Label;
            infojan.Text = item.Jan;


        }
    }
}
