using System.Collections.Generic;

namespace WebGame.Core.Models.Geography
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<City> Cities { get; set; }

        public Country()
        {
            Cities = new List<City>();
        }
    }
}
