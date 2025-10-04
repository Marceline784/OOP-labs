using System;
using System.Text;
public class Book
{
    private string title;
    private string author;
    private decimal price;
    public Book(string author, string title, decimal price)
    {
        Author = author;
        Title = title;
        Price = price;
    }
    public string Title
    {
        get { return title; }
        set
        {
            if (value.Length < 3)
            {
                throw new ArgumentException("Title not valid!");
            }
            title = value;
        }
    }

    public string Author
    {
        get { return author; }
        set
        {
            string[] parts = value.Split(' ');
            if (parts.Length > 1 && char.IsDigit(parts[1][0]))
            {
                throw new ArgumentException("Author not valid!");
            }
            author = value;
        }
    }

    public virtual decimal Price
    {
        get { return price; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }
            price = value;
        }
    }
    public override string ToString()
    {
        var resultBuilder = new StringBuilder();
        resultBuilder.AppendLine($"Type: {this.GetType().Name}")
        .AppendLine($"Title: {this.Title}")
        .AppendLine($"Author: {this.Author}")
        .AppendLine($"Price: {this.Price:f2}");
        string result = resultBuilder.ToString().TrimEnd();
        return result;
    }

}
public class GoldenEditionBook : Book
{
    public GoldenEditionBook(string author, string title, decimal price)
        : base(author, title, price)
    {
    }
    public override decimal Price
    {
        get { return base.Price * 1.3m; }
    }
}

class Program
    {
        static void Main()
        {
        try
        {
            string author = Console.ReadLine();
            string title = Console.ReadLine();
            decimal price = decimal.Parse(Console.ReadLine());
            Book book = new Book(author, title, price);
            GoldenEditionBook goldenEditionBook = new GoldenEditionBook(author, title, price);
            Console.WriteLine(book + Environment.NewLine);
            Console.WriteLine(goldenEditionBook);
        }
        catch (ArgumentException ae)
        {
            Console.WriteLine(ae.Message);
        }
    }
    }