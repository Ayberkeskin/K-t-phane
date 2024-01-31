class Book
{
    public string Name { get; set; }
    public string Author { get; set; }
    public string ISBN { get; set; }
    public int CopyCount { get; set; }
    public int BorrowedCopyCount { get; set; }

    public DateTime? BorrowedDate { get; set;}
}
