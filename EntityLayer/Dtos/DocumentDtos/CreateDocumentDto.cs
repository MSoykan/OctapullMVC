using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.DocumentDtos {
    public class CreateDocumentDto {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int MeetingId { get; set; } // Toplantıya ait belgenin kimliği
    }
}
