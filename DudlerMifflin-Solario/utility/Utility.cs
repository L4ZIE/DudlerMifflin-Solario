using Npgsql;

namespace DudlerMifflin_Solario.utility;

public class Utility
{
    public static readonly Uri Uri;
    public static readonly string ProperlyFormattedConnectionString;

    static Utility()
    {
        string rawConnectionString;
        string envVarKeyName = "pgconn";

        rawConnectionString = Environment.GetEnvironmentVariable(envVarKeyName);
        Console.WriteLine($"Raw Connection String: {rawConnectionString}");

        if (rawConnectionString == null)
        {
            throw new Exception($"Missing environment variable '{envVarKeyName}', please add your connection string!");
        }

        try
        {
            Uri = new Uri(rawConnectionString);
            ProperlyFormattedConnectionString = string.Format(
                "Host={0};Database={1};Username={2};Password={3};Port={4};Pooling=true;MaxPoolSize=3;SSL Mode=Require",
                Uri.Host,
                Uri.AbsolutePath.Trim('/'),
                Uri.UserInfo.Split(':')[0],
                Uri.UserInfo.Split(':')[1],
                Uri.Port > 0 ? Uri.Port : 5432
            );

            using var connection = new NpgsqlConnection(ProperlyFormattedConnectionString);
            connection.Open();
            connection.Close();
        }
        catch (Exception e)
        {
            throw new Exception("Connection string is found but cannot be used.", e);
        }
    }
}