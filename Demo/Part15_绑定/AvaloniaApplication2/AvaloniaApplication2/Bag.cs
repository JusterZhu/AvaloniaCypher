using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace AvaloniaApplication2;

public class Book
{
    public string Title{ get; set; }
    
    public string Author { get; set; }

    public ObservableCollection<Book> Children { get; set; } = [];
    
    public Book(string title, string author)
    {
        Title = title;
        Author = author;
    }

    public override string ToString()
    {
        return $"{Title} - {Author}";
    }
}

public class Bag : ObservableObject
{
    //public ObservableCollection<string> Books { get; set; } = new ObservableCollection<string>();

    public Task<string> MyText => GetTextAsync();

    public async Task<string> GetTextAsync()
    {
        await Task.Delay(3000);
        return "加载完成！显示最终结果！";
    }

    private Task<Bitmap> _myBitmap;
    
    public Task<Bitmap> MyBitmap
    {
        get => _myBitmap;
        set => SetProperty(ref _myBitmap, value);
    }
    
    public double Price { get; set; } = 12.12;
    
    public DateTime CurrentDate { get; set; } = DateTime.Now;
    
    public RelayCommand<object> GetBookCommand { get; set; }
    
    public AsyncRelayCommand ShowImageCommand { get; set; }
    
    public ObservableCollection<Book> Books { get; set; } = new ObservableCollection<Book>();

    private Book _selectedBook;

    public Book SelectedBook
    {
        get => _selectedBook;
        set
        {
            SetProperty(ref _selectedBook, value);
        }
    }

    private string? _firstName;
    private string? _lastName;

    // 名
    public string? FirstName
    {
        get => _firstName;
        set => SetProperty(ref _firstName, value);  // SetProperty 自动触发 PropertyChanged
    }

    // 姓
    public string? LastName
    {
        get => _lastName;
        set => SetProperty(ref _lastName, value);
    }
    
    // 用于Default模式的属性
    private string _userName = "初始用户名";
    public string UserName
    {
        get => _userName;
        set
        {
            _userName = value; 
            OnPropertyChanged();
        }
    }

    // 用于OneWay模式的属性
    private int _count = 0;
    public int Count
    {
        get => _count;
        set { _count = value; OnPropertyChanged(); }
    }

    // 用于TwoWay模式的属性
    private bool _isSelected = false;
    public bool IsSelected
    {
        get => _isSelected;
        set { _isSelected = value; OnPropertyChanged(); }
    }

    // 用于OneTime模式的属性
    private string _initialMessage = "程序启动时的消息";
    public string InitialMessage
    {
        get => _initialMessage;
        set { _initialMessage = value; OnPropertyChanged(); }
    }

    // 用于OneWayToSource模式的属性
    private string _inputValue = "787878";
    public string InputValue
    {
        get => _inputValue;
        set { _inputValue = value; OnPropertyChanged(); }
    }
    
    public Bag()
    {
        /*Books.Add("语文书");
        Books.Add("数学书");
        Books.Add("英语书");*/
        Books.Add(new Book("语文书", "张三")
        {
            Children = new ObservableCollection<Book>(){ new Book("唐诗三百首", "王五") }
        });
        Books.Add(new Book("数学书", "李四"));
        Books.Add(new Book("英语书", "李雷"));
        GetBookCommand = new RelayCommand<object>(GetBook);
        ShowImageCommand = new AsyncRelayCommand(ShowImageAction);
        //MyBitmap = new Bitmap(new MemoryStream(File.ReadAllBytes(@"C:\51a9f3ce-66e4-4525-867c-7e8f12a70d6f.png")));
    }

    private Task<Bitmap> ShowImageAction()
    {
        return MyBitmap = ImageHelper.LoadFromWeb(new Uri(@"https://th.bing.com/th/id/R.987f582c510be58755c4933cda68d525?rik=C0D21hJDYvXosw&riu=http%3a%2f%2fimg.pconline.com.cn%2fimages%2fupload%2fupc%2ftx%2fwallpaper%2f1305%2f16%2fc4%2f20990657_1368686545122.jpg&ehk=netN2qzcCVS4ALUQfDOwxAwFcy41oxC%2b0xTFvOYy5ds%3d&risl=&pid=ImgRaw&r=0"));
    }


    private void GetBook(object? obj)
    {
        
    }
}