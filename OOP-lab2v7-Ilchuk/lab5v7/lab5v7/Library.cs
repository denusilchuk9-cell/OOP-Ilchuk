using System;
using System.Collections.Generic;
using System.Linq;

public class Library
{
    private readonly IRepository<Loan> _loanRepository;

    public Library(IRepository<Loan> loanRepository)
    {
        _loanRepository = loanRepository ?? throw new ArgumentNullException(nameof(loanRepository));
    }

    public void AddLoan(Loan loan)
    {
        _loanRepository.Add(loan);
    }

    public bool RemoveLoanByBook(string bookTitle)
    {
        return _loanRepository.Remove(l => l.BookTitle == bookTitle);
    }

    public IEnumerable<Loan> GetLoansByReader(string readerName)
    {
        return _loanRepository.Where(l => l.ReaderName == readerName);
    }

    public IEnumerable<Loan> GetLoansByBook(string bookTitle)
    {
        return _loanRepository.Where(l => l.BookTitle == bookTitle);
    }

    public IReadOnlyList<Loan> GetAllLoans()
    {
        return _loanRepository.All();
    }

    public decimal TotalFines()
    {
        return _loanRepository.All().Sum(l => l.CalculateFine());
    }

    public double AverageOverdueDays()
    {
        var returnedLoans = _loanRepository.All().Where(l => l.ActualReturnDate.HasValue);
        if (!returnedLoans.Any()) return 0;
        return returnedLoans.Average(l => l.CalculateOverdueDays());
    }

    public decimal MaxFine()
    {
        return _loanRepository.All().Max(l => l.CalculateFine());
    }

    public double OverduePercentage()
    {
        var totalLoans = _loanRepository.All().Count;
        if (totalLoans == 0) return 0;
        var overdue = _loanRepository.All().Count(l => l.CalculateOverdueDays() > 0);
        return (double)overdue / totalLoans * 100;
    }
}