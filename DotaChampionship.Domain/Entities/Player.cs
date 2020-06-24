using System.ComponentModel.DataAnnotations;

namespace DotaChampionship.Domain
{
    public class Player
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public string NickName { get; set; }        
        public byte[] Logo { get; set; }


        public string Role { get; set; }

        public Personal PersonalInformation { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
