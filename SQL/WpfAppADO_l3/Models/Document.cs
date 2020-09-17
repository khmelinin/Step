using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppADO_l3.Models
{
    class Document
    {
        DataRow row;

        public Document(DataRow dataRow)
        {
            row = dataRow;
        }

        public int DocumentId
        {
            get
            {
                return row.Field<int>("documentId");
            }
            set
            {
                row.SetField("documentId", value);
            }
        }

        public string DocumentType
        {
            get
            {
                return row.Field<string>("documentType");
            }
            set
            {
                row.SetField("documentType", value);
            }
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

        public int CustomerId
        {
            get
            {
                return row.Field<int>("customerId");
            }
            set
            {
                row.SetField("customerId", value);
            }
        }

        public DateTime DocumentDate
        {
            get
            {
                return row.Field<DateTime>("documentDate");
            }
            set
            {
                row.SetField("documentDate", value);
            }
        }

        public decimal Price
        {
            get
            {
                return row.Field<decimal>("price");
            }
            set
            {
                row.SetField("price", value);
            }
        }

        public int Amount
        {
            get
            {
                return row.Field<int>("amount");
            }
            set
            {
                row.SetField("amount", value);
            }
        }

    }
}
