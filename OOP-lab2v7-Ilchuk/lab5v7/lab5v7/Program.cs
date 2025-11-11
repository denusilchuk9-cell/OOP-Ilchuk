using System;
using Spectre.Console;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var loanRepo = new Repository<Loan>();
        var library = new Library(loanRepo);

        library.AddLoan(new Loan("The Great Gatsby", "John Doe", new DateTime(2023, 10, 1), new DateTime(2023, 10, 15)));
        library.AddLoan(new Loan("1984", "Jane Smith", new DateTime(2023, 10, 5), new DateTime(2023, 10, 20)));
        library.AddLoan(new Loan("To Kill a Mockingbird", "John Doe", new DateTime(2023, 10, 10), new DateTime(2023, 10, 25)));

        var loan1 = loanRepo.FirstOrDefault(l => l.BookTitle == "The Great Gatsby");
        loan1?.ReturnBook(new DateTime(2023, 10, 18));

        var loan2 = loanRepo.FirstOrDefault(l => l.BookTitle == "1984");
        loan2?.ReturnBook(new DateTime(2023, 10, 20));

        var loan3 = loanRepo.FirstOrDefault(l => l.BookTitle == "To Kill a Mockingbird");
        loan3?.ReturnBook(new DateTime(2023, 11, 1));

        try
        {
            var invalidLoan = new Loan("Invalid Book", "Test User", new DateTime(2023, 10, 1), new DateTime(2023, 10, 15));
            library.AddLoan(invalidLoan);
            invalidLoan.ReturnBook(new DateTime(2023, 9, 30));
        }
        catch (InvalidReturnDateException ex)
        {
            AnsiConsole.MarkupLine($"[red]Помилка: {ex.Message}[/]");
        }

        AnsiConsole.MarkupLine("[bold green]Обчислення:[/]");
        Console.WriteLine($"Загальний штраф: {library.TotalFines():C}");
        Console.WriteLine($"Середні прострочені дні: {library.AverageOverdueDays():F2}");
        Console.WriteLine($"Максимальний штраф: {library.MaxFine():C}");
        Console.WriteLine($"Відсоток прострочених позик: {library.OverduePercentage():F2}%");

        var table = new Table().Border(TableBorder.Rounded);
        table.AddColumn("Книга");
        table.AddColumn("Читач");
        table.AddColumn("Дата видачі");
        table.AddColumn("Дата повернення");
        table.AddColumn("Штраф");
        foreach (var loan in library.GetAllLoans())
        {
            table.AddRow(
                loan.BookTitle,
                loan.ReaderName,
                loan.IssueDate.ToShortDateString(),
                loan.ActualReturnDate?.ToShortDateString() ?? "Не повернено",
                $"{loan.CalculateFine():C}"
            );
        }
        AnsiConsole.Write(table);
    }
}