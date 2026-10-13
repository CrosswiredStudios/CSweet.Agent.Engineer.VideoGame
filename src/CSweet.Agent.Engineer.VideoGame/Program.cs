using CSweet.Agent.SDK;
using CSweet.Agent.Engineer.VideoGame;
using Microsoft.Extensions.Hosting;

if (args.Contains("--self-test", StringComparer.Ordinal))
{
    var manifest = await AgentManifestLoader.LoadAsync("csweet-plugin.json", CancellationToken.None);
    var agent = new GameEngineerAgent();
    var schema = await new AgentTestRuntime().ExecuteCapabilityAsync(
        agent,
        AgentConfigurationCapabilities.Describe,
        new { });

    var succeeded =
        manifest.Id == agent.AgentId &&
        manifest.Version == agent.Version &&
        manifest.Capabilities.Contains(GameEngineerProfile.PrimaryCapability) &&
        schema.Succeeded;

    Console.WriteLine(succeeded
        ? "Video Game Engineer manifest and configuration contract are valid."
        : "Video Game Engineer self-test failed.");
    Environment.ExitCode = succeeded ? 0 : 1;
    return;
}

var builder = Host.CreateApplicationBuilder(args);

var runtimeManifest = await AgentManifestLoader.LoadAsync(
    "csweet-plugin.json",
    CancellationToken.None);
if (runtimeManifest.Id != GameEngineerProfile.AgentId ||
    runtimeManifest.Version != GameEngineerProfile.Version)
{
    throw new InvalidOperationException(
        "The Video Game Engineer implementation identity does not match csweet-plugin.json.");
}

builder.AddCSweetAgent<GameEngineerAgent>();
await builder.Build().RunAsync();
