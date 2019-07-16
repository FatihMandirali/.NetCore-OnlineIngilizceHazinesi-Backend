using System;
using System.Collections.Generic;
using System.Text;

namespace Application.WordService.DTO
{
   public class WordRequest
    {
        public string kelime { get; set; }
        public string anlami { get; set; }
        public string kullanici { get; set; }
    }
}
