using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

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

    public double Price { get; set; } = 10.25;
    
    public DateTime Current { get; set; } = DateTime.Now;

    public bool IsEnabled { get; set; } = true;

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
    }
}