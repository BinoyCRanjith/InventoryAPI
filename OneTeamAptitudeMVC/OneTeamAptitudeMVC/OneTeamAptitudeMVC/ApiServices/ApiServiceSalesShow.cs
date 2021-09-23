using OneTeamAptitudeMVC.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OneTeamAptitudeMVC.ApiServices
{
    public class ApiServiceSalesShow
    {
        public static ApiResponse<T> ExecuteMyApi<T>(ApiRequestDTO dTO) where T : class
        {
            var client = new RestClient("https://localhost:44387/");
            var request = new RestRequest(dTO.RouteUrl, dTO.RequestType);
            request.RequestFormat = DataFormat.Json;

            if (dTO.JsonData != null)
            {
               request.AddParameter("application/json", dTO.JsonData, ParameterType.RequestBody);
                //request.AddBody(dTO.Json);
            }
            IRestResponse<ApiResponse<T>> response = client.Execute<ApiResponse<T>>(request);
            return response.Data;
        }
    }
}