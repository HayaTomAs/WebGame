using System.Collections.Generic;

namespace WebGame.Core.Models.Geography
{
    public class Planet
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Country> Countries { get; set; }
    }
}
