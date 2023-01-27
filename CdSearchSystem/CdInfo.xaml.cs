using Newtonsoft.Json;
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

namespace CdSearchSystem {
    /// <summary>
    /// CdInfo.xaml の相互作用ロジック
    /// </summary>
    public partial class CdInfo : Window {
        WebClient wc = new WebClient() { Encoding = Encoding.UTF8 };
        string cdName;
        string pass;
        string Url;
        BitmapImage m_bitmap = null;

        public CdInfo() {
            InitializeComponent();
    
            
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            Serch serch = new Serch();
            serch.Show();
            this.Close();
        }

        public void passtitle(string strData) {
            pass = strData;
        }

        

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            Url = "https://app.rakuten.co.jp/services/api/BooksCD/Search/20170404?format=json&booksGenreId=002&title=" + pass + "&applicationId=1083313806659590350";

            cdName = wc.DownloadString(Url);
            var json = JsonConvert.DeserializeObject<Rootobject>(cdName);

            artistname.Text = json.Items[0].Item.artistName;
            titol.Text = json.Items[0].Item.title;
            salesdate.Text = json.Items[0].Item.salesDate;
            url.Text = json.Items[0].Item.itemUrl;
            jan.Text = json.Items[0].Item.jan;
            label.Text = json.Items[0].Item.label;
            price.Text = json.Items[0].Item.itemPrice.ToString() + "円";

            //画像の表示
            var path = json.Items[0].Item.largeImageUrl;

            m_bitmap = new BitmapImage();
            m_bitmap.BeginInit();
            m_bitmap.UriSource = new Uri(path);
            m_bitmap.EndInit();
            cdImage.Source = m_bitmap;

        }
    }
}
