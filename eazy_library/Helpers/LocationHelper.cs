using System;
using System.Linq;
using System.Threading.Tasks;
using eazy_library.Models;
using FreeGeoIPCore;
using FreeGeoIPCore.AppCode;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;

namespace eazy_library.Helpers
{
    public class LocationHelper
    {
        public static async Task<LocationGeoIPModel> LongitudeLatitude(IHttpContextAccessor httpContextAccessor)
        {
            FreeGeoIPClient ipClient = new FreeGeoIPClient();

            string ipAddress = GetRequestIP(httpContextAccessor);

            if (!string.IsNullOrWhiteSpace(ipAddress))
            {
                FreeGeoIPCore.Models.Location location = await ipClient.GetLocation(ipAddress);

                var coordinate = new LocationGeoIPModel()
                {
                    Latitude = location.Latitude,
                    Longitude = location.Longitude
                };

                return coordinate;
            }

            return new LocationGeoIPModel();
        }

        private static string GetRequestIP(IHttpContextAccessor httpContextAccessor, bool tryUseXForwardHeader = true)
        {
            string ip = null;

            if (tryUseXForwardHeader)
                ip = GetHeaderValueAs<string>(httpContextAccessor, "X-Forwarded-For").SplitCsv().FirstOrDefault();

            // RemoteIpAddress is always null in DNX RC1 Update1 (bug).
            if (ip.IsNullOrWhitespace() && httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress != null)
                ip = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

            if (ip.IsNullOrWhitespace())
                ip = GetHeaderValueAs<string>(httpContextAccessor, "REMOTE_ADDR");

            // _httpContextAccessor.HttpContext?.Request?.Host this is the local host.

            if (ip.IsNullOrWhitespace())
                throw new Exception("Unable to determine caller's IP.");

            // Remove port if on IP address
            ip = ip.Substring(0, ip.IndexOf(":"));

            return ip;
        }

        private static T GetHeaderValueAs<T>(IHttpContextAccessor httpContextAccessor, string headerName)
        {
            StringValues values;

            if (httpContextAccessor.HttpContext?.Request?.Headers?.TryGetValue(headerName, out values) ?? false)
            {
                string rawValues = values.ToString();   // writes out as Csv when there are multiple.

                if (!rawValues.IsNullOrWhitespace())
                    return (T)Convert.ChangeType(values.ToString(), typeof(T));
            }
            return default(T);
        }
    }
}