using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Context;
using Context.Models;
using Contracts;
using DTO;

namespace Server
{
    public class LoginHandler:ILoginHandler
    {
        private readonly FestivalContext _festivalContext;
        
        public LoginHandler()
        {
            _festivalContext = new FestivalContext();
        }
        
        public Task<AccountDto> Login(string username, string password)
        {
            var account =
                _festivalContext.Users.FirstOrDefault(acc => acc.Username == username && acc.Password == password);

            AccountDto result = null;

            if (account != null)
            {
                result = new AccountDto
                {
                    Role = account.Role,
                    Username = account.Username
                };
            }

            return Task.FromResult(result);
        }
    }
}