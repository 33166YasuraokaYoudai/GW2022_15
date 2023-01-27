using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CdSearchSystem {
    public class searchContents {

        //アーティスト名
        public string ArtistName { get; set; }

        //タイトル
        public string Title { get; set; }

        //発売元
        public string Label { get; set; }

        //JANコード
        public string Jan { get; set; }

        //URL
        public string ItemUrl { get; set; }

        //発売日
        public string SalesDate { get; set; }

        //価格
        public string ItemPrice { get; set; }

        //画像
        public Image Picture { get; set; }


    }
}
