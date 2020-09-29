using Shop_linq.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Shop_linq.ViewModels
{
    class ArticleDialogViewModel : BaseViewModel
    {
        private string articleTitle;
        private bool closeDialog;
        private ICommand saveCommand;
        private ICommand cancelCommand;

        public ICommand SaveCommand
        {
            get
            {
                return saveCommand ?? (saveCommand = new RelayCommand(
                    () =>
                    {
                        DialogResult = true;
                        CloseDialog = true;
                    },
                    () => { return !string.IsNullOrWhiteSpace(articleTitle); }
                    ));
            }
        }

        public ICommand CancelCommand
        {
            get
            {
                return cancelCommand ?? (cancelCommand = new RelayCommand(
                    () =>
                    {
                        DialogResult = false;
                        CloseDialog = true;
                    }));
            }
        }

        public bool DialogResult { get; set; }

        public bool CloseDialog
        {
            get => closeDialog;
            set
            {
                if (closeDialog != value)
                {
                    closeDialog = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string ArticleTitle
        {
            get { return articleTitle; }
            set
            {
                if (articleTitle != value)
                {
                    articleTitle = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
