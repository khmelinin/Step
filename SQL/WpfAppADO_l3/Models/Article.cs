using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppADO_l3.Models
{
    public class Article
    {
        DataRow row;

        public Article(DataRow dataRow)
        {
            row = dataRow;
        }

        public int ArticleId
        {
            get
            {
                return row.Field<int>("articleId");
            }
            set
            {
                row.SetField("articleId", value);
            }
        }

        public string ArticleTitle
        {
            get
            {
                return row.Field<string>("articleTitle");
            }
            set
            {
                row.SetField("articleTitle", value);
            }
        }
    }
}
