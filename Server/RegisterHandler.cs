using System.Threading.Tasks;
using Contracts;

namespace Server
{
    public class RegisterHandler:IRegisterHandler
    {
        public Task<bool> Register(string username, string password, string name, string lastName, bool isAdmin)
        {
            throw new System.NotImplementedException();
        }
    }
}