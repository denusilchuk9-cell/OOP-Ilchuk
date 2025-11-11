using System;

public class InvalidReturnDateException : Exception
{
    public InvalidReturnDateException(string message) : base(message) { }
}