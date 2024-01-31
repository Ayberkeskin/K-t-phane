using System.Text;
using System.Xml.Linq;

class Library
{
    private static List<Book> books = new List<Book>();

    public void AddBook()
    {
        string Name, Author, ISBN;
        int numberOfPieces;
        Console.WriteLine("Lütfen Kitabın adını giriniz:\n");
        Name = Console.ReadLine();
        Console.WriteLine("Lütfen Kitabın yazarını giriniz:\n");
        Author = Console.ReadLine();
        Console.WriteLine("Lütfen Kitabın ISBN sini giriniz:\n");
        ISBN = Console.ReadLine();
        Console.WriteLine("Lütfen teslim etmek istediğiniz adeti giriniz giriniz:\n");
        numberOfPieces = int.Parse(Console.ReadLine());

        bool bookExists = false;
        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].Name == Name && books[i].Author == Author)
            {
                books[i].CopyCount += numberOfPieces;
                bookExists = true;
                break;
            }
        }
        if (!bookExists)
        {
            Book book = new Book();
            book.Name = Name;
            book.Author = Author;
            book.ISBN = ISBN;
            books.Add(book);
            Console.WriteLine("Teşekkürler");
        }
        returnToMainMenu();

    }

    public string DisplayAllBooks()
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < books.Count; i++)
        {
            result.Append(BookInfo(i));
        }
        return result.ToString();
    }

    public string SearchBook()
    {
        Console.WriteLine("Aradığınız kitabın adını yada yazarının adını giriniz");
        string value = Console.ReadLine();

        string mesaj = "Maalesef aradağınız kitabı bulamadık";
        for (int i = 0; i < books.Count; i++)
        {
            if (value == books[i].Name || value == books[i].Author)
            {
                return BookInfo(i);
            }
        }
        return mesaj;
    }

    public void BorrowedCopyCount()
    {
        Console.WriteLine("Aradağınz kitabın adı nedir?");
        string bookName = Console.ReadLine();
        for (int i = 0; i < books.Count; i++)
        {
            if (bookName == books[i].Name)
            {
                if (books[i].CopyCount < 0)
                {
                    Console.WriteLine("Maalesef aradığınz kitabın kopyası elimizde yok lütfen daha sonra tekrar deneyin");
                }
                else
                {
                    books[i].BorrowedCopyCount++;
                    books[i].CopyCount--;
                    //Kitabın ödünç alınış tarihini kaydetim çünkü süresi geçmiş kitapları gösterirken bu veriyi kullanacağım. 
                    books[i].BorrowedDate = DateTime.Now;
                    Console.WriteLine("İyi eğlenceler");
                }
            }
        }

    }

    public void ReturnBook()
    {
        Console.WriteLine("İade etmek istediğiniz kitabın adı nedir?");
        string bookName = Console.ReadLine();

        for (int i = 0; i < books.Count; i++)
        {
            if (bookName == books[i].Name)
            {
                if (books[i].BorrowedCopyCount <= 0)
                {
                    Console.WriteLine("Aradığınız kitaba ait herhangi bir bilgi bulunmamaktadır");
                }
                else
                {
                    books[i].CopyCount++;
                    books[i].BorrowedCopyCount--;
                    Console.WriteLine("Teşekkürler");
                }
            }
        }
    }

    public void outOfDateBooks()
    {
        for (int i = 0; i < books.Count; i++)
        {
            if (books[i].BorrowedCopyCount > 0)
            {
                TimeSpan? passingTime = books[i].BorrowedDate - DateTime.Now;
                Console.WriteLine("**************************************");
                Console.WriteLine("Geçen süre=" + passingTime);
                BookInfo(i);
            }
        }
    }
    private void returnToMainMenu()
    {
        Console.WriteLine("Ana menüye dönmek için herhangi bir tuşa basın.");
        Console.ReadKey();
        Console.Clear();
    }

    //Bu kısmı ayrı bir fonksiyonda yazmak ne kadar mantıklıydı bilemedim doğrudan for'un içine de yazılabilirdi
    //Böyle anlaşılması daha kolay geliyor bana
    public string BookInfo(int i)
    {
        StringBuilder bookInfo = new StringBuilder();
        bookInfo.AppendLine("**************************************");
        bookInfo.AppendLine("Kitap Adı:" + books[i].Name);
        bookInfo.AppendLine("Kitap Yazaraı:" + books[i].Author);
        bookInfo.AppendLine("Kitap ISBN:" + books[i].ISBN);
        bookInfo.AppendLine("Kitap Adet Sayısı:" + books[i].CopyCount);
        bookInfo.AppendLine("Ödünç Alınan Kopyalar:" + books[i].BorrowedCopyCount);
        bookInfo.AppendLine("**************************************");

        return bookInfo.ToString();
    }

}
