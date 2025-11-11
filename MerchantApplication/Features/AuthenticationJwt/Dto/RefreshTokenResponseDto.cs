using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchantApplication.Features.AuthenticationJwt.Dto
{
    public class RefreshTokenResponseDto
    {
        public int UserId { get; set; }
        public string RefreshToken { get; set; } = null!;
    }
}
