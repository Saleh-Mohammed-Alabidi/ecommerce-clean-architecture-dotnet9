namespace ecommerce.Common.Configuration.Constrain;

public class RateLimitConstrain
{
    public int PermitLimit { get; set; }

    public int TimeSpan { get; set; }

    public int QueueLimit { get; set; }
}