namespace IndependentWork19.Models
{
    public interface IValidator
    {
        bool Validate(string input);
        string GetErrorMessage();
    }
}