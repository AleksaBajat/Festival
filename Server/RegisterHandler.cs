using System.Linq;
using System.Threading.Tasks;
using Common.Enums;
using Context;
using Context.Models;
using Contracts;
using log4net;

namespace Server
{
    public class RegisterHandler:IRegisterHandler
    {

        private readonly ILog _log = LogManager.GetLogger(nameof(RegisterHandler));

        public RegisterHandler()
        {
            
        }
        
        public Task<bool> Register(string username, string password, string name, string lastName, bool isAdmin)
        {
            using (FestivalContext context = new FestivalContext())
            {
                context.Users.Add(new User
                {
                    Username = username,
                    Password = password,
                    Name = name,
                    LastName = lastName,
                    Role = isAdmin == true ? CommonEnumerations.UserRole.Admin : CommonEnumerations.UserRole.User
                });

                context.SaveChanges();

                _log.Info("Registered User");

                return Task.FromResult(true);
            }
        }

        public Task ChangePassword(string username, string password)
        {
            using (FestivalContext context = new FestivalContext())
            {
                var user = context.Users.FirstOrDefault(u => u.Username == username);

                user.Password = password;

                context.SaveChanges();
                

                return Task.CompletedTask;
            }
        }
    }
}