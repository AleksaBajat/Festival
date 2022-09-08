using System;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Server
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            AuthenticationServer authenticationServer = new AuthenticationServer();
            RegistrationServer registrationServer = new RegistrationServer();
            StageServer stageServer = new StageServer();
            TimeSlotServer timeSlotServer = new TimeSlotServer();
            ArtistServer artistServer = new ArtistServer();

            authenticationServer.Open();
            registrationServer.Open();
            stageServer.Open();
            timeSlotServer.Open();
            artistServer.Open();
            Console.WriteLine(@"Press any key to close.");
            Console.ReadKey();
            authenticationServer.Close();
            registrationServer.Close();
            stageServer.Close();
            timeSlotServer.Close();
            artistServer.Close();
        }
    }
}