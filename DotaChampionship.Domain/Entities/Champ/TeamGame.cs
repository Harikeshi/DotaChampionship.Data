namespace DotaChampionship.Domain.Entities.Champ
{
    public class TeamGame
    {
        public int Id { get; set; }

        public string Score { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}
