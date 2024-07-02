namespace workshop2;

class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Random Password Generator!");

            // Get user preferences
            Console.Write("Enter the length of the password: ");
            int length = Convert.ToInt32(Console.ReadLine());

            Console.Write("Include uppercase letters? (y/n): ");
            bool includeUpper = Console.ReadLine().ToLower() == "y";

            Console.Write("Include lowercase letters? (y/n): ");
            bool includeLower = Console.ReadLine().ToLower() == "y";

            Console.Write("Include numbers? (y/n): ");
            bool includeNumbers = Console.ReadLine().ToLower() == "y";

            Console.Write("Include special characters? (y/n): ");
            bool includeSpecial = Console.ReadLine().ToLower() == "y";

            // Generate the password
            string password = GeneratePassword(length, includeUpper, includeLower, includeNumbers, includeSpecial);

            // Output the password to the user
            Console.WriteLine($"\nYour random password is: {password}");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        static string GeneratePassword(int length, bool includeUpper, bool includeLower, bool includeNumbers, bool includeSpecial)
        {
            const string uppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lowercaseChars = "abcdefghijklmnopqrstuvwxyz";
            const string numberChars = "0123456789";
            const string specialChars = "!@#$%^&*()_+-=[]{}|;:,.<>?";

            string validChars = "";
            if (includeUpper)
                validChars += uppercaseChars;
            if (includeLower)
                validChars += lowercaseChars;
            if (includeNumbers)
                validChars += numberChars;
            if (includeSpecial)
                validChars += specialChars;

            Random random = new Random();
            char[] password = new char[length];

            for (int i = 0; i < length; i++)
            {
                password[i] = validChars[random.Next(0, validChars.Length)];
            }

            return new string(password);
        }
    }
