namespace MeTube.Models
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        public ICollection<Tube> Tubes { get; set; }
    }
}