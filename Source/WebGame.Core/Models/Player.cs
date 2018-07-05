using WebGame.Core.Models.Geography;

namespace WebGame.Core.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Pseudo { get; set; }

        public City City { get; set; }
    }
}
