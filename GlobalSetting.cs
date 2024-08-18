namespace CalcMaui;

public class GlobalSetting
{
    private const string DefaultEndpoint = "http://192.168.18.130:8080";

    public static GlobalSetting Instance { get; } = new();

    public string BaseCalcEndpoint { get; set; } = DefaultEndpoint;
}