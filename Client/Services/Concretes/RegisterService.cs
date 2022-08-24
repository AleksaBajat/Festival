using System;
using System.Configuration;
using Client.Services.Abstractions;
using DTO;

namespace Client.Services.Concretes
{
    public class RegisterService:IRegisterService
    {
        private readonly string _endpointAddress = ConfigurationManager.AppSettings["authenticationServerAddress"];
        
        public RegisterService() {}
        
        public AccountDto Register(string username, string password, string name, string lastName, bool isAdmin)
        {
            Console.WriteLine("radi");
            throw new System.NotImplementedException();
        }
    }
}