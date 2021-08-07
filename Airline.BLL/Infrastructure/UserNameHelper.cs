using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline.BLL.Infrastructure
{
    public static class UserNameHelper
    {
        public static string CreateUserName(string email)
        {
            List<char> chars = new List<char>(); 

            for (int i = 0; i < email.Length; i++)
            {
                if (email[i] != '@')
                {
                    chars.Add(email[i]);
                }
                else
                {
                    break;
                }
            }
            var result = new string(chars.ToArray());
            return result;
        }
    }
}
