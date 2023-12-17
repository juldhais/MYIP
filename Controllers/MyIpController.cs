using Microsoft.AspNetCore.Mvc;
using MYIP.Client;

namespace MYIP.Controllers;

[ApiController]
[Route("api/myip")]
public class MyIpController(IpApiClient ipApiClient) : ControllerBase
{
    private readonly IpApiClient _ipApiClient = ipApiClient;

    [HttpGet]
    public async Task<ActionResult> Get(CancellationToken ct)
    {
        try
        {
            var ipAddress = HttpContext.GetServerVariable("HTTP_X_FORWARDED_FOR") ?? HttpContext.Connection.RemoteIpAddress?.ToString();
            var ipAddressWithoutPort = ipAddress?.Split(':')[0];

            var ipApiResponse = await _ipApiClient.Get(ipAddressWithoutPort, ct);

            var response = new
            {
                IpAddress = ipAddressWithoutPort,
                Country = ipApiResponse?.country,
                Region = ipApiResponse?.regionName,
                City = ipApiResponse?.city,
                District = ipApiResponse?.district,
                PostCode = ipApiResponse?.zip,
                Longitude = ipApiResponse?.lon.GetValueOrDefault(),
                Latitude = ipApiResponse?.lat.GetValueOrDefault(),
            };

            return Ok(response);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}