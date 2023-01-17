using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

public static class Token
{
    public static string CreateToken(string username, string role)
    {
        List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, role)
            };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("lorem ipsum dolar si amet lorem ipsum dolar si amet lorem ipsum dolar si amet"));

        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

        var token = new JwtSecurityToken(
            //claims: claims,
            expires: DateTime.Now.AddDays(1),
            signingCredentials: creds,
            claims:claims
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}
