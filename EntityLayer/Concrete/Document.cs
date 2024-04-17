using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Document
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string FileName { get; set; }
        [StringLength(300)]
        public string FilePath { get; set; }
        public int MeetingId { get; set; } // Toplantıya ait belgenin kimliği
        public Meeting Meeting { get; set; } = null!;// Belge ile ilgili toplantı
    }
}
