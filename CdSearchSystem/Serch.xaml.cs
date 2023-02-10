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
using System.Threading;

namespace CdSearchSystem {
    /// <summary>
    /// Serch.xaml の相互作用ロジック
    /// </summary>
    public partial class Serch : Window {

        WebClient wc = new WebClient() { Encoding = Encoding.UTF8 };
        string cdName;
        string aname;
        


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

            if (!(artistName.Text == "")) {
                check.Content = null;
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

                    });
                    foreach (var item in cdInfo) {
                        list.Items.Add(item);
                    }
                }
            } else if(list.Items.Count == 0){
                check.Content = "キーワードを入力してください。";
            }


        }

        //入力されたデータを消去する処理
        private void Clear() {
            artistName.Clear();
        }

        //入力した内容を検索する処理
        public void NameSearch() {
            aname = artistName.Text;
            string url1 = "https://app.rakuten.co.jp/services/api/BooksCD/Search/20170404?format=json&artistName=" + aname + "&booksGenreId=002&applicationId=1083313806659590350";
            
            cdName = wc.DownloadString(url1);
            
        }

        //選択したデータを表示
        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            //if (list.SelectedItem == null) return;
            //searchContents item = (searchContents)list.SelectedItem;
            //infoname.Text = item.ArtistName;
            //infotitle.Text = item.Title;
            //infolabel.Text = item.Label;
            //infojan.Text = item.Jan;
            //infourl.Text = item.ItemUrl;

            searchContents se = (searchContents)list.SelectedItem;
            cdtitle.Text = se.Title;

        }

        private void Button_Click_3(object sender, RoutedEventArgs e) {

            CdInfo cdinfo = new CdInfo();
            cdinfo.passtitle(cdtitle.Text);
            cdinfo.Show();
        }

       
    }
}
