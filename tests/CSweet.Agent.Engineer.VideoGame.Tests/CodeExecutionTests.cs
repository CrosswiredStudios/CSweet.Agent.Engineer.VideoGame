using CSweet.Agent.SDK;

namespace CSweet.Agent.Engineer.VideoGame.Tests;

public sealed class CodeExecutionTests
{
    [Theory]
    [InlineData(false, 0)]
    [InlineData(true, 1)]
    public void FailedOrInconsistentValidationCannotCompleteCodeWork(bool succeeded, int exitCode)
    {
        var outcome = new GameCodeOutcome("Implemented movement", ["src/game.js"], [new("npm test", succeeded, exitCode, "test output")]);
        Assert.Throws<InvalidOperationException>(() => GameEngineerExecution.RequireValidOutcome(outcome));
    }
    [Fact]
    public void ProseWithoutChangedFilesOrExecutedChecksCannotCompleteCodeWork()
    {
        Assert.Throws<InvalidOperationException>(() => GameEngineerExecution.RequireValidOutcome(new("Report", [], [new("npm test", true, 0, "passed")])));
        Assert.Throws<InvalidOperationException>(() => GameEngineerExecution.RequireValidOutcome(new("Report", ["game.js"], [])));
        GameEngineerExecution.RequireValidOutcome(new("Implemented movement", ["game.js"], [new("npm test", true, 0, "passed")]));
    }
    [Fact]
    public void ExecutionReportAloneIsNotAReviewableImplementation()
    {
        Assert.Throws<InvalidOperationException>(() => SpecialistAgent.RequireImplementationChanges(true, [".csweet/outcome.json"]));
        SpecialistAgent.RequireImplementationChanges(true, [".csweet/outcome.json", "src/game.js"]);
    }
    [Fact]
    public void HostPathsAreNotAcceptedAsCodingWorkspaces()
    {
        Assert.Throws<InvalidOperationException>(() => GameEngineerExecution.RequireWorkspace(Path.GetTempPath()));
    }
}
