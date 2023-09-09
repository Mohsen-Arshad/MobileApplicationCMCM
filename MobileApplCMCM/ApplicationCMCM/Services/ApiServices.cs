using ApplicationCMCM.CustomConstants;
using ApplicationCMCM.MVVM.Models;
using Newtonsoft.Json;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Net.Http.Headers;
using System.Net.Http;

namespace ApplicationCMCM.Services;

public class ApiServices
{
    RequestModel rqstModel = new();
    List<RequestModel> listRequestModel = new();
    HttpClient httpClient;

    public ApiServices()
    {
        httpClient = new HttpClient();
    }

    #region USER WITH EXCEPTION HANDLING
    //public async Task<bool> RegisterUser(RegisterModel registerModel)
    //{
    //    try
    //    {
    //        var httpclient = new HttpClient();
    //        var json = JsonConvert.SerializeObject(registerModel);
    //        var content = new StringContent(json, Encoding.UTF8, "application/json");
    //        var response = await httpclient.PostAsync(CustomConst.BaseUrl + "/Users/Register", content);

    //        if (!response.IsSuccessStatusCode)
    //        {
    //            return false;
    //        }
    //        return true;
    //    }
    //    catch (HttpRequestException ex)
    //    {
    //        // Handle the exception (e.g., log it, show an error message)
    //        return false; // You might want to return false in case of an exception
    //    }
    //}

    //public async Task<bool> Login(LoginModel loginModel)
    //{
    //    try
    //    {
    //        var tokenHandler = new JwtSecurityTokenHandler();
    //        var httpClient = new HttpClient();
    //        var json = JsonConvert.SerializeObject(loginModel);
    //        var content = new StringContent(json, Encoding.UTF8, "application/json");
    //        var response = await httpClient.PostAsync(CustomConst.BaseUrl + "/Users/Login", content);

    //        if (!response.IsSuccessStatusCode)
    //        {
    //            return false;
    //        }
    //        var jsonResult = await response.Content.ReadAsStringAsync();
    //        var token = tokenHandler.ReadJwtToken(jsonResult);
    //        var userId = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
    //        var userEmail = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
    //        await SecureStorage.SetAsync("AccessToken", jsonResult);
    //        Preferences.Set("userid", userId);
    //        Preferences.Set("useremail", userEmail);
    //        return true;
    //    }
    //    catch (HttpRequestException ex)
    //    {
    //        // Handle the exception (e.g., log it, show an error message)
    //        return false; // You might want to return false in case of an exception
    //    }
    //}

    //public async Task<bool> UpdateUser(UserModel userModel)
    //{
    //    try
    //    {
    //        var httpClient = new HttpClient();
    //        httpClient = await UserValidation(httpClient);
    //        var json = JsonConvert.SerializeObject(userModel);
    //        var content = new StringContent(json, Encoding.UTF8, "application/json");
    //        var response = await httpClient.PutAsync(CustomConst.BaseUrl + "/Users", content);
    //        if (!response.IsSuccessStatusCode)
    //        {
    //            return false;
    //        }
    //        return true;
    //    }
    //    catch (HttpRequestException ex)
    //    {
    //        // Handle the exception (e.g., log it, show an error message)
    //        return false; // You might want to return false in case of an exception
    //    }
    //}

    //public async Task<bool> DeleteUser(int userId)
    //{
    //    try
    //    {
    //        var httpClient = new HttpClient();
    //        httpClient = await UserValidation(httpClient);
    //        var result = await httpClient.DeleteAsync(CustomConst.BaseUrl + "/Users/" + userId);
    //        if (!result.IsSuccessStatusCode)
    //        {
    //            return false;
    //        }
    //        return true;
    //    }
    //    catch (HttpRequestException ex)
    //    {
    //        // Handle the exception (e.g., log it, show an error message)
    //        return false; // You might want to return false in case of an exception
    //    }
    //}
    #endregion

    #region USER
    public async Task<bool> RegisterUser(RegisterModel registerModel)
    {
        var json = JsonConvert.SerializeObject(registerModel);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(CustomConst.BaseUrl + "/Users/Register", content);

        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
    }

    public async Task<bool> Login(LoginModel loginModel)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var json = JsonConvert.SerializeObject(loginModel);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(CustomConst.BaseUrl + "/Users/Login", content);

        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        var jsonResult = await response.Content.ReadAsStringAsync();
        var token = tokenHandler.ReadJwtToken(jsonResult);
        var userId = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        var userEmail = token.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
        await SecureStorage.SetAsync("AccessToken", jsonResult);
        Preferences.Set("userid", userId);
        Preferences.Set("useremail", userEmail);
        return true;
    }

    public async Task<bool> UpdateUser(UserModel userModel)
    {
        httpClient = await UserValidation(httpClient);
        var json = JsonConvert.SerializeObject(userModel);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        //var content = CustomSerializeObject(userModel);
        var response = await httpClient.PutAsync(CustomConst.BaseUrl + "/Users", content);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
    }

    public async Task<bool> DeleteUser(int userId)
    {
        httpClient = await UserValidation(httpClient);
        var result = await httpClient.DeleteAsync(CustomConst.BaseUrl + "/Users/" + userId);
        if (!result.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
    }
    #endregion

    #region REQUESTS
    public async Task<RequestModel> GetRequest(int requestId)
    {
        httpClient = await UserValidation(httpClient);
        var response = await httpClient.GetStringAsync(CustomConst.BaseUrl + "/Requests/" + requestId);
        var request = JsonConvert.DeserializeObject<RequestModel>(response);

        if (request is null)
        {
            return null;
        }

        return request;
    }

    public async Task<List<RequestModel>> GetAllRequests()
    {
        if (listRequestModel?.Count > 0)
        {
            return listRequestModel;
        }

        httpClient = await UserValidation(httpClient);
        var response = await httpClient.GetStringAsync(CustomConst.BaseUrl + "/Requests");
        var categories = JsonConvert.DeserializeObject<List<RequestModel>>(response);

        if (categories is null)
        {
            return null;
        }

        return categories;
    }

    public async Task<bool> CreateRequest(RequestModel requestModel)
    {
        httpClient = await UserValidation(httpClient);
        var json = JsonConvert.SerializeObject(requestModel);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var response = await httpClient.PostAsync(CustomConst.BaseUrl + "/Requests", content);

        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
    }


    public async Task<bool> UpdateRequest(RequestModel requestModel)
    {
        httpClient = await UserValidation(httpClient);
        var json = JsonConvert.SerializeObject(requestModel);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        //var content = CustomSerializeObject(userModel);
        var response = await httpClient.PutAsync(CustomConst.BaseUrl + "/Requests", content);
        if (!response.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
    }

    public async Task<bool> DeleteRequest(int requestId)
    {
        httpClient = await UserValidation(httpClient);
        var result = await httpClient.DeleteAsync(CustomConst.BaseUrl + "/Requests/" + requestId);
        if (!result.IsSuccessStatusCode)
        {
            return false;
        }
        return true;
    }
    #endregion

    #region CATEGORIES
    public async Task<List<CategoryModel>> GetCategories()
    {
        httpClient = await UserValidation(httpClient);
        var response = await httpClient.GetStringAsync(CustomConst.BaseUrl + "/Categories");
        var categories = JsonConvert.DeserializeObject<List<CategoryModel>>(response);

        if (categories is null)
        {
            return null;
        }

        return categories;
    }
    #endregion

    #region FUNCTIONS
    private async Task<HttpClient> UserValidation(HttpClient httpClient)
    {
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", await SecureStorage.GetAsync("AccessToken"));
        return httpClient;
    }

    private StringContent CustomSerializeObject(object model)
    {
        var json = JsonConvert.SerializeObject(model);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        return content;
    }
    #endregion

}
