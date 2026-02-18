using System;

namespace lab22v7
{
    public class User
    {
        protected string username;
        protected string email;

        public User(string username, string email)
        {
            this.username = username;
            this.email = email;
        }

        public virtual void ChangePassword(string newPassword)
        {
            Console.WriteLine($"User {username}: Password changed to '{newPassword}'");
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"User: {username}, Email: {email}");
        }
    }

    public class GuestUser : User
    {
        public GuestUser(string username) : base(username, "guest@example.com")
        {
        }

        public override void ChangePassword(string newPassword)
        {
            throw new InvalidOperationException("Guest users cannot change passwords!");
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Guest User: {username} (temporary account)");
        }
    }

    public class UserManager
    {
        public static void UpdateUserPassword(User user, string newPassword)
        {
            Console.WriteLine($"\nChanging password for user...");
            user.DisplayInfo();
            user.ChangePassword(newPassword);
            Console.WriteLine("Password update successful!");
        }
    }

    public interface IUserInfo
    {
        void DisplayInfo();
        string GetUsername();
    }

    public interface IPasswordChangeable
    {
        void ChangePassword(string newPassword);
    }

    public class RegularUser : IUserInfo, IPasswordChangeable
    {
        private string username;
        private string email;

        public RegularUser(string username, string email)
        {
            this.username = username;
            this.email = email;
        }

        public void ChangePassword(string newPassword)
        {
            Console.WriteLine($"Regular User {username}: Password changed to '{newPassword}'");
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Regular User: {username}, Email: {email}");
        }

        public string GetUsername()
        {
            return username;
        }
    }

    public class GuestAccount : IUserInfo
    {
        private string username;

        public GuestAccount(string username)
        {
            this.username = username;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Guest Account: {username} (read-only)");
        }

        public string GetUsername()
        {
            return username;
        }
    }

    public class NewUserManager
    {
        public static void ProcessUser(IUserInfo user, string newPassword = null)
        {
            Console.WriteLine($"\nProcessing user...");
            user.DisplayInfo();

            if (user is IPasswordChangeable changeableUser && newPassword != null)
            {
                changeableUser.ChangePassword(newPassword);
                Console.WriteLine("Password update successful!");
            }
            else if (newPassword != null)
            {
                Console.WriteLine($"User {user.GetUsername()} cannot change password");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=================================");
            Console.WriteLine("Лабораторна робота №22");
            Console.WriteLine("Варіант 7: User & GuestUser");
            Console.WriteLine("=================================");

            Console.WriteLine("\n=== LSP VIOLATION ===");

            User regular = new User("john", "john@example.com");
            User guest = new GuestUser("guest");

            try
            {
                UserManager.UpdateUserPassword(regular, "pass123");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            try
            {
                UserManager.UpdateUserPassword(guest, "pass456");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("\n=== LSP SOLUTION ===");

            RegularUser regularUser = new RegularUser("alice", "alice@example.com");
            GuestAccount guestAccount = new GuestAccount("temp_guest");

            NewUserManager.ProcessUser(regularUser, "secure789");
            NewUserManager.ProcessUser(guestAccount, "try000");
            NewUserManager.ProcessUser(guestAccount);

            Console.WriteLine("\n=================================");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
