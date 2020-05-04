using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotaChampionship.Domain
{
    public class Personal
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        [StringLength(10)]
        public string Sex { get; set; }


        public int PlayerId { get; set; }
        public Player Player { get; set; }
    }
}
