namespace MYIP.Client;

public sealed class IpApiResponse
{
    public string? status { get; set; }
    public string? continent { get; set; }
    public string? country { get; set; }
    public string? regionName { get; set; }
    public string? city { get; set; }
    public string? district { get; set; }
    public string? zip { get; set; }
    public double? lat { get; set; }
    public double? lon { get; set; }
    public string? isp { get; set; }
    public string? query { get; set; }
}