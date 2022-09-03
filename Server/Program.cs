using System;

namespace Server
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            AuthenticationServer authenticationServer = new AuthenticationServer();
            RegistrationServer registrationServer = new RegistrationServer();
            
            authenticationServer.Open();
            registrationServer.Open();
            Console.WriteLine("Authentication server opened!");
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
            authenticationServer.Close();
            registrationServer.Close();
            Console.WriteLine("Authentication server closed!");
            
            
        }
    }
}