using Shop_linq.Dialogs;
using Shop_linq.Helpers;
using Shop_linq.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Shop_linq.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        private ShopDataContext dataContext = new ShopDataContext();
        private ICommand newArticleCommand;
        private ICommand deleteArticleCommand;
        private ICommand rowEndEditCommand;

        public IEnumerable<Article> Articles
        {
            get
            {
                var articles = from a in dataContext.Articles select a;
                return articles;
            }
        }

        public ICommand NewArticleCommand
        {
            get
            {
                return newArticleCommand ?? (newArticleCommand = new RelayCommand(
                    () => 
                    {
                        var vm = new ArticleDialogViewModel();
                        DialogFactory.ShowArticleDialog(vm);
                        if (vm.DialogResult)
                        {
                            dataContext.Articles.InsertOnSubmit(
                                new Article() { articleTitle = vm.ArticleTitle });
                            dataContext.SubmitChanges();
                            RaisePropertyChanged(nameof(Articles));
                        }
                    }));
            }
        }

        public ICommand DeleteArticleCommand
        {
            get
            {
                return deleteArticleCommand ?? (deleteArticleCommand = new RelayCommand<Article>(
                    (a) => 
                    {
                        dataContext.Articles.DeleteOnSubmit(a);
                        dataContext.SubmitChanges();
                        RaisePropertyChanged(nameof(Articles));
                    },
                    (a) => { return a != null; }));
            }
        }

        public ICommand RowEndEditCommand
        {
            get
            {
                return rowEndEditCommand ?? (rowEndEditCommand = new RelayCommand<DataGridRowEditEndingEventArgs>(
                    (e) => {
                        if (e.EditAction != DataGridEditAction.Commit)
                        {
                            return;
                        }

                        var article = e.Row.Item as Article;
                        if (string.IsNullOrWhiteSpace(article.articleTitle))
                        {
                            e.Cancel = true;
                        }
                        else
                        {
                            dataContext.SubmitChanges();
                        }

                        //RaisePropertyChanged(nameof(Articles));
                    }));
            }
        }

        public ICommand DeleteItemCommand
        {
            get
            {
                return new RelayCommand<KeyEventArgs>(
                    (e) => 
                    {
                        if (e.Key != Key.Delete)
                        {
                            return;
                        }

                        dataContext.SubmitChanges();
                    }
                    );
            }
        }
    }
}
