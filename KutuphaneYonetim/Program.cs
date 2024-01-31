class Program
{
    static void Main(string[] args)
    {
        Library library = new Library();
        Console.WriteLine("Kütüphanemize hoş geldiniz lütfen yapmak istediğiniz işlemi seçin\n");
        Console.WriteLine("Kitap eklemek için 1'e basınız\n");
        Console.WriteLine("Kütüphanedeki tüm kitapları listelemek için 2'ye basınız\n");
        Console.WriteLine("Kütüphanedeki bir kitabı aramak için 3'e basınız (Yazar adı veya kitap adı giriniz)\n");
        Console.WriteLine("Kitap ödünç almak için 4'e basınız\n");
        Console.WriteLine("Kitap iade etmek için 5'e basınız\n");
        Console.WriteLine("Süresi geçmiş kitapları görmek için 6'ya basınız\n");
        string process = Console.ReadLine();

        switch (process)
        {
            case "1":
                library.AddBook();
                break;
            case "2":
                library.DisplayAllBooks();
                break;
            case "3":
                library.SearchBook();
                break;
            case "4":
                library.BorrowedCopyCount();
                break;
            case "5":
                library.ReturnBook();
                break;
            case "6":
                library.outOfDateBooks();
                break;
             default:
                Console.WriteLine("Geçersiz işlem. Lütfen tekrar deneyin.");
                break;


        }
        Console.ReadLine();
    }
}
