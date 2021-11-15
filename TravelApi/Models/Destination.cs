using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace TravelApi.Models
{
  public class Destination
  {
        public int DestinationId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public int Review  { get; set; }

    public static List<Destination> GetDestinations()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Destination> destinationsList = JsonConvert.DeserializeObject<List<Destination>>(jsonResponse.ToString());

      return destinationsList;
    }
    public static Destination GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Destination Destination = JsonConvert.DeserializeObject<Destination>(jsonResponse.ToString());

      return Destination;
    }
    public static void Post(Destination destination)
    {
      string jsonDestination = JsonConvert.SerializeObject(destination);
      var apiCallTask = ApiHelper.Post(jsonDestination);
    }
  }
}