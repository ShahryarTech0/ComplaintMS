using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication.Features.AuthenticationJwt.Dto
{
    public class TokenResponseDto
    {
        public string AccessToken { get; set; } = null!;
        public string RefreshToken { get; set; } = null!;

        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;

    }
}
