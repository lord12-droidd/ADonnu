using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
    public class AuthenticationResponseDTO
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
