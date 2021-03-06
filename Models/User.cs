using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace caja.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public ICollection<Tally> Tallies { get; set; }
        public User()
        {
            Tallies = new Collection<Tally>();
        }

    }
}