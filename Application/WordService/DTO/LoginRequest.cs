using System;
using System.Collections.Generic;
using System.Text;

namespace Application.WordService.DTO
{
  public class LoginRequest
    {
        public string username { get; set; }
        public string password { get; set; }
        public string page { get; set; }
    }
}
