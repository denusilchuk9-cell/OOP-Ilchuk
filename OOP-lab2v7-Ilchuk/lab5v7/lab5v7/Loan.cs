using System;

public class Loan
{
    public string BookTitle { get; set; }
    public string ReaderName { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ActualReturnDate { get; set; }
    private readonly decimal fineRate = 0.5m;

    public Loan(string bookTitle, string readerName, DateTime issueDate, DateTime dueDate)
    {
        BookTitle = bookTitle ?? throw new ArgumentNullException(nameof(bookTitle));
        ReaderName = readerName ?? throw new ArgumentNullException(nameof(readerName));
        if (issueDate > dueDate) throw new InvalidReturnDateException("Due date must be after issue date.");
        IssueDate = issueDate;
        DueDate = dueDate;
    }

    public void ReturnBook(DateTime returnDate)
    {
        if (returnDate < IssueDate) throw new InvalidReturnDateException("Return date cannot be before issue date.");
        ActualReturnDate = returnDate;
    }

    public decimal CalculateFine()
    {
        if (!ActualReturnDate.HasValue) return 0m;
        var overdueDays = Math.Max(0, (ActualReturnDate.Value - DueDate).TotalDays);
        return (decimal)overdueDays * fineRate;
    }

    public int CalculateOverdueDays()
    {
        if (!ActualReturnDate.HasValue) return 0;
        return (int)Math.Max(0, (ActualReturnDate.Value - DueDate).TotalDays);
    }
}