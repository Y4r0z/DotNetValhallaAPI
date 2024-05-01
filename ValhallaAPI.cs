using System.Diagnostics;
using System.Net;
using System.Text.Json;
using ValhallaAPI.Tools;
using ValhallaAPI.Types;

namespace ValhallaAPI
{
    public class ValhallaAPI
    {
        public HttpClient HttpClient { get; }
        private JsonSerializerOptions serializerOptions;

        public ValhallaAPI(HttpClient httpClient)
        {
            HttpClient = httpClient;
            serializerOptions = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
            };

        }
        public ValhallaAPI(Uri baseAddress) 
        : this(
            new HttpClient()
            {
                BaseAddress = baseAddress,
                DefaultRequestHeaders =
                {
                    {"Accept", "application/json"},
                }
            }
        )
        { }

        public async Task<RouteTrip?> GetRoute(RouteRequest routeRequest)
        {
            string json = JsonSerializer.Serialize(routeRequest, serializerOptions);
            string url = $"/route?json={json}";
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            string? jsonResponse = "";
            try
            {
                var response = await HttpClient.SendAsync(request).ConfigureAwait(false);
                jsonResponse = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
            }
            catch (WebException ex)
            {
                Debug.WriteLine(ex.ToString());
                return null;
            }
            catch(HttpRequestException ex)
            {
                Debug.WriteLine(ex.ToString());
                return null;
            }
            RouteTripWrapper? trip = JsonSerializer.Deserialize<RouteTripWrapper>(jsonResponse, serializerOptions);
            if (trip is null) Debug.WriteLine(jsonResponse);
            return trip?.Trip;
        }

        public async Task<List<CoordinateEntity>> GetRouteCoordinates(RouteRequest routeRequest)
        {
            var trip = await GetRoute(routeRequest);
            var res = new List<CoordinateEntity>();
            var shape = trip?.Legs.First()?.Shape;
            if (shape is null) return res;
            foreach (var item in GooglePoints.Decode(shape))
            {
                res.Add(item);
            }
            return res;
        }

    }
}
