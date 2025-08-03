public class jwtOption
{

    public static string sectionName { get; set; } = "JWT";
    public string Key { get; set; } = string.Empty;

    public string Issuer { get; set; } = string.Empty;

    public string Audience { get; set; } = string.Empty;

    public int ExpireHours { get; set; } = 24;
}