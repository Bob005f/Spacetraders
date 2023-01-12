using System.Net.Http.Json;
using SpaceTraders.Loans;
using SpaceTraders.Userdata;
using SpaceTraders.LoanedLoans;
using System.Net.NetworkInformation;
using SpaceTraders.AvailableShips;
using SpaceTraders.ErrorDto;
using SpaceTraders.ShipsOwned;

namespace SpaceTraders
{
  public static class Api 
  { 

    private static HttpClient _httpClient = new HttpClient 
    { 
      BaseAddress = new Uri("https://api.spacetraders.io") 
    }; 
    private readonly static string Token = "token=0ce8d217-4160-4623-af86-b2d7432e8897"; 
    
    public static async Task<MyAccountDto> GetMyAccount() 
    { 
      HttpResponseMessage response = await
        _httpClient.GetAsync($"my/account?{Token}");
      return await response.Content.ReadFromJsonAsync<MyAccountDto>(); 
    }

    public static async Task<AvaibleLoansDTO> GetAvaibleLoans()
    {
      HttpResponseMessage response = await
        _httpClient.GetAsync($"types/loans?{Token}");
      return await response.Content.ReadFromJsonAsync<AvaibleLoansDTO>();
    }

    public static async void TakeLoan(string type)
    {
      await _httpClient.PostAsync($"my/loans?{Token}&type={type}", null);
    }

    public static async Task<LoanedLoansDTO> GetLoanedLoans()
    {
      HttpResponseMessage response = await
        _httpClient.GetAsync($"my/loans?{Token}");
      return await response.Content.ReadFromJsonAsync<LoanedLoansDTO>();
    }

    public static async void LoanPayBack(string id)
    {
       await _httpClient.PutAsync($"my/loans/{id}?{Token}", null);
    }

    public static async Task<AvailableShipsDTO> GetAvailableShips()
    {
      HttpResponseMessage response = await
        _httpClient.GetAsync($"Systems/OE/ship-listings?{Token}");
      return await response.Content.ReadFromJsonAsync<AvailableShipsDTO>();
    }

        public static async Task<MyShipsDTO> GetMyShips()
        {
            HttpResponseMessage response = await
              _httpClient.GetAsync($"my/ships?{Token}");
            return await response.Content.ReadFromJsonAsync<MyShipsDTO>();
        }


        public static async Task<MessageDto> BuyShip(string location, string type)
    {

      HttpResponseMessage response = await
        _httpClient.PostAsync($"my/ships?{Token}&location={location}&type={type}", null);

      if (response.IsSuccessStatusCode)
      {
        return new MessageDto
        {
          Code = 200,
          Message = "Ship bought successfully"
        };
      }
      else
      {
        ErrorDTO error = await response.Content.ReadFromJsonAsync<ErrorDTO>();
        return error.Error;
      }
    }
  }
} 
