using AvaloniaMVVM.Shell.Mvvm;

namespace AvaloniaMVVM.Shell.Models;

public class User:ViewModelBase
{
    private string _name;
    private string _sex;

    public string Name
    {
        get => _name;
        set
        {
            if (value == _name) return;
            _name = value;
            OnPropertyChanged();
        }
    }

    public string Sex
    {
        get => _sex;
        set
        {
            if (value == _sex) return;
            _sex = value;
            OnPropertyChanged();
        }
    }
}