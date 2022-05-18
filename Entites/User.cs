using Core.Abstract;
using Microsoft.AspNetCore.Identity;

namespace Entites
{
    public class User:IdentityUser
    {
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; }= null!;
    }

}