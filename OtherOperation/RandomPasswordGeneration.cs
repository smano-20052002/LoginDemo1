using System.Text;

namespace LoginDemo1.OtherOperation
{
    public static class RandomPasswordGeneration
    {
        public static string RandomPasswordGenerator()
        {
            Random random = new Random();
            int passwordLength = random.Next(8, 12);
            const string validCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890@#$&!?";
            StringBuilder password = new StringBuilder();
            for (int i = 0; i < passwordLength; i++)
            {
                int randomcode = random.Next(0, validCharacters.Length-1);
                password.Append(validCharacters[randomcode]);
            }

            return password.ToString();
        }
    }
}

