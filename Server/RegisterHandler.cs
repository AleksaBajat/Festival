using System.Threading.Tasks;
using Common.Enums;
using Context;
using Context.Models;
using Contracts;

namespace Server
{
    public class RegisterHandler:IRegisterHandler
    {
        
        private readonly FestivalContext _festivalContext;
            
        public RegisterHandler()
        {
            _festivalContext = new FestivalContext();
        }
        
        public Task<bool> Register(string username, string password, string name, string lastName, bool isAdmin)
        {
            _festivalContext.Users.Add(new User
            {
                Username = username,
                Password = password,
                Name = name,
                LastName = lastName,
                Role = isAdmin == true ? CommonEnumerations.UserRole.Admin : CommonEnumerations.UserRole.User
            });

            _festivalContext.SaveChanges();

            return Task.FromResult(true);
        }
    }
}