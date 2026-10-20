using System.Reflection;
using DbUp;
using Microsoft.Extensions.Configuration;

// Load the nearest .env (searching up from the working directory) without
// overriding variables already set in the real environment.
DotNetEnv.Env.NoClobber().TraversePath().Load();

var config = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .Build();

var connectionString = config.GetConnectionString("DefaultConnection");
if (string.IsNullOrWhiteSpace(connectionString))
{
    Console.Error.WriteLine("ConnectionStrings:DefaultConnection is not set (ConnectionStrings__DefaultConnection in .env or the environment).");
    return 1;
}

EnsureDatabase.For.MySqlDatabase(connectionString);

var upgrader = DeployChanges.To
    .MySqlDatabase(connectionString)
    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
    .LogToConsole()
    .Build();

if (args.Contains("--dry-run"))
{
    foreach (var script in upgrader.GetScriptsToExecute())
        Console.WriteLine($"Pending: {script.Name}");
    return 0;
}

var result = upgrader.PerformUpgrade();
if (!result.Successful)
{
    Console.Error.WriteLine(result.Error);
    return 1;
}

return 0;
