using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Meeting
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [StringLength(300)]
        public string Description { get; set; }
        public ICollection<Document> Documents { get; set; } // Toplantıya ait belgelerin koleksiyonu

        // Collection of participant IDs
        public ICollection<int> ParticipantIds { get; set; } = new List<int>();
    }
}
