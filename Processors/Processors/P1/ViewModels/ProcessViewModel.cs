using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace P1.ViewModels
{
    class ProcessViewModel:BindableBase
    {
        private Process p;

        public ProcessViewModel(Process p)
        {
            this.p = p;
        }

        public string Name
        {
            get { return p?.ProcessName; }
        }

        public int? ProcessId
        {
            get { return p?.Id; }
        }

        public DateTime? StartTime
        {
            get {
                try
                {
                    return p?.StartTime;
                }
                catch
                {
                    return null;
                }
            }

        }

        public int? BasePriority
        {
            get => p?.BasePriority;
        }

    }
}
