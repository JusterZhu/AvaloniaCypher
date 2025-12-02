using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AvaloniaMVVM.Shell.Models;
using AvaloniaMVVM.Shell.Mvvm;

namespace AvaloniaMVVM.Shell.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public User User
        {
            get => _user;
            set
            {
                if (Equals(value, _user)) return;
                _user = value;
                OnPropertyChanged();
            }
        }

        private string _name = "张三";
        private User _user;

        public String Name
        {
            get => _name;
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Sex { get; set; } = "男";

        public void OK(object parameter)
        {
            User = new User();
            User.Name = $"{parameter}";
        }

        private ICommand? _cancelCommand;

        public ICommand CancelCommand
        {
            get
            {
                if (_cancelCommand == null) _cancelCommand = new DelegateCommand<string>(Cancel);
                return _cancelCommand;
            }
        }

        private void Cancel(string parameter)
        {
            User = new User();
            User.Name = $"{parameter}";
        }
    }
}