using ApplicationCMCM.CustomConstants;
using ApplicationCMCM.MVVM.Models;
using Newtonsoft.Json;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ApplicationCMCM.Services;

public class ApiServices
{
    public async Task<bool> RegisterUser(RegisterModel registerModel)
    {
        var httpclient = new HttpClient();
        var json = JsonConvert.SerializeObject(registerModel);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpclient.PostAsync(CustomConst.BaseUrl + "/Users/Register", content);

        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
    }

    public async Task<bool> Login (LoginModel loginModel)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var httpClient = new HttpClient();
        var json = JsonConvert.SerializeObject(loginModel);
        var content = new StringContent (json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(CustomConst.BaseUrl + "/Users/Login", content);

        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        var jsonResult = await response.Content.ReadAsStringAsync();
        var token = tokenHandler.ReadJwtToken(jsonResult);
        var userId = token.Claims.FirstOrDefault(c=>c.Type == ClaimTypes.NameIdentifier)?.Value;
        var userEmail = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        Preferences.Set("accesstoken", jsonResult);
        Preferences.Set("userid", userId);
        Preferences.Set("useremail", userEmail);
        return true;
    }
}
