using NUnit.Framework;
using workshop2;

namespace Workshop2Test
{
    [TestFixture]
    public class Tests
    {
        [TestCase(8, true, true, true, true)]
        [TestCase(12, true, false, true, true)]
        [TestCase(10, false, true, false, true)]
        [TestCase(15, true, true, false, false)]
        public void GeneratePassword_ValidInputs_ReturnsPassword(int length, bool includeUpper, bool includeLower, bool includeNumbers, bool includeSpecial)
        {
            // Arrange
            //Program program = new Program();

            // Act
            string password = Program.GeneratePassword(length, includeUpper, includeLower, includeNumbers, includeSpecial);

            // Assert
            Assert.AreEqual(length, password.Length, "Generated password length does not match specified length");

            bool hasUpper = false;
            bool hasLower = false;
            bool hasNumber = false;
            bool hasSpecial = false;

            foreach (char c in password)
            {
                if (char.IsUpper(c))
                    hasUpper = true;
                else if (char.IsLower(c))
                    hasLower = true;
                else if (char.IsDigit(c))
                    hasNumber = true;
                else
                    hasSpecial = true;
            }

            Assert.AreEqual(includeUpper, hasUpper, "Generated password does not include uppercase letters as expected");
            Assert.AreEqual(includeLower, hasLower, "Generated password does not include lowercase letters as expected");
            Assert.AreEqual(includeNumbers, hasNumber, "Generated password does not include numbers as expected");
            Assert.AreEqual(includeSpecial, hasSpecial, "Generated password does not include special characters as expected");
        }
    }
}