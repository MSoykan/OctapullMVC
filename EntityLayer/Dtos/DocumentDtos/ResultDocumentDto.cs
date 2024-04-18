﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.DocumentDtos {
    public class ResultDocumentDto {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public int MeetingId { get; set; } 
    }
}
