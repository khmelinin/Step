using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppADO_l3.Models
{
    class Warehouse
    {
        SqlConnection sqlConnection;
        DataSet warehouse;
        SqlDataAdapter articlesAdapter;
        SqlDataAdapter customerAdapter;
        SqlDataAdapter documentsAdapter;

        public Warehouse(SqlConnection connection)
        {
            sqlConnection = connection;
            warehouse = new DataSet("Warehouse");
            warehouse.BeginInit();
            var articles = CreateArticles();
            var customers = CreateCustomers();
            var documents = CreateDocuments();
            DataRelation relation = new DataRelation("articles_documents",
                articles.Columns["articleId"],
                documents.Columns["articleId"]);
            warehouse.Relations.Add(relation);
            relation = new DataRelation("customers_documents",
                customers.Columns["customerId"],
                documents.Columns["customerId"]);
            warehouse.Relations.Add(relation);
            warehouse.EndInit();
            CreateAdapters();
        }

        public void LoadData()
        {
            articlesAdapter.Fill(warehouse.Tables["Articles"]);
            customerAdapter.Fill(warehouse.Tables["Customers"]);
            documentsAdapter.Fill(warehouse.Tables["Documents"]);
        }

        public ObservableCollection<Article> Articles
        {
            get
            {
                var result = new ObservableCollection<Article>();
                foreach (DataRowView item in warehouse.Tables["Articles"].DefaultView)
                {
                    result.Add(new Article(item.Row));
                }

                return result;
            }
        }

        public ObservableCollection<Customer> Customers
        {
            get
            {
                var result = new ObservableCollection<Customer>();
                foreach (DataRowView item in warehouse.Tables["Customers"].DefaultView)
                {
                    result.Add(new Customer(item.Row));
                }

                return result;
            }
        }

        public ObservableCollection<Document> Documents
        {
            get
            {
                var result = new ObservableCollection<Document>();
                foreach (DataRowView item in warehouse.Tables["Documents"].DefaultView)
                {
                    result.Add(new Document(item.Row));
                }

                return result;
            }
        }

        private DataTable CreateArticles()
        {
            DataTable tblArticles = new DataTable("Articles");
            tblArticles.BeginInit();
            DataColumn column = new DataColumn("articleId", typeof(int));
            column.AutoIncrement = true;
            column.AutoIncrementSeed = -1;
            column.AutoIncrementStep = -1;
            column.ReadOnly = true;
            column.Unique = true;
            column.AllowDBNull = false;
            tblArticles.Columns.Add(column);
            column = new DataColumn("articleTitle", typeof(string));
            column.MaxLength = 20;
            column.AllowDBNull = false;
            tblArticles.Columns.Add(column);
            tblArticles.EndInit();
            warehouse.Tables.Add(tblArticles);
            return tblArticles;
        }

        private DataTable CreateCustomers()
        {
            DataTable tblCustomers = new DataTable("Customers");
            tblCustomers.BeginInit();
            DataColumn column = new DataColumn("customerId", typeof(int));
            column.AutoIncrement = true;
            column.AutoIncrementSeed = -1;
            column.AutoIncrementStep = -1;
            column.ReadOnly = true;
            column.Unique = true;
            column.AllowDBNull = false;
            tblCustomers.Columns.Add(column);
            column = new DataColumn("customerTitle", typeof(string));
            column.MaxLength = 20;
            column.AllowDBNull = false;
            tblCustomers.Columns.Add(column);
            tblCustomers.EndInit();
            warehouse.Tables.Add(tblCustomers);
            return tblCustomers;
        }

        private DataTable CreateDocuments()
        {
            DataTable table = new DataTable("Documents");
            table.BeginInit();
            DataColumn column = new DataColumn("documentId", typeof(byte[]));
            
            column.ReadOnly = true;
            column.Unique = true;
            column.AllowDBNull = false;
            table.Columns.Add(column);
            column = new DataColumn("documentType", typeof(string));
            column.MaxLength = 20;
            column.AllowDBNull = false;
            table.Columns.Add(column);
            column = new DataColumn("articleId", typeof(int));
            column.AllowDBNull = false;
            table.Columns.Add(column);
            column = new DataColumn("customerId", typeof(int));
            column.AllowDBNull = false;
            table.Columns.Add(column);
            column = new DataColumn("documentDate", typeof(DateTime));
            column.AllowDBNull = false;
            table.Columns.Add(column);
            column = new DataColumn("price", typeof(decimal));
            column.AllowDBNull = false;
            table.Columns.Add(column);
            column = new DataColumn("amount", typeof(int));
            column.AllowDBNull = false;
            table.Columns.Add(column);
            table.EndInit();
            warehouse.Tables.Add(table);
            return table;
        }

        private void CreateAdapters()
        {
            articlesAdapter = new SqlDataAdapter(
                "select articleId, articleTitle from Articles",
                sqlConnection);

            customerAdapter = new SqlDataAdapter(
                "select customerId, customerTitle from Customers",
                sqlConnection);

            documentsAdapter = new SqlDataAdapter(
                "select documentId, documentType, articleId, customerId, documentDate, price, amount from Documents",
                sqlConnection);
        }
    }
}
