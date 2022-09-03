using System;

namespace Server
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            AuthenticationServer authenticationServer = new AuthenticationServer();
            RegistrationServer registrationServer = new RegistrationServer();
            StageServer stageServer = new StageServer();

            authenticationServer.Open();
            registrationServer.Open();
            stageServer.Open();
            Console.WriteLine("Press any key to close");
            Console.ReadKey();
            authenticationServer.Close();
            registrationServer.Close();
            stageServer.Close();
        }
    }
}