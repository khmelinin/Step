using Shop_linq.ViewModels;
using Shop_linq.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop_linq.Dialogs
{
    static class DialogFactory
    {
        public static void ShowArticleDialog(ArticleDialogViewModel vm)
        {
            var v = new ArticleDialog() { DataContext = vm };
            v.ShowDialog();
        }
    }
}
