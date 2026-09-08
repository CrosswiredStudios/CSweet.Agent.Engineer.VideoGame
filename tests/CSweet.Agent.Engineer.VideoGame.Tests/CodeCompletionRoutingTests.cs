namespace CSweet.Agent.Engineer.VideoGame.Tests;

public sealed class CodeCompletionRoutingTests
{
    [Fact]
    public void CodePublicationUsesReviewRouteWhenPolicyOffersBothRoutes() =>
        Assert.Equal("code-published", GameEngineerExecution.CompletionCode(["completed", "code-published"]));
    [Fact]
    public void LegacyPolicyUsesItsSupportedCompletion() =>
        Assert.Equal("completed", GameEngineerExecution.CompletionCode(["completed"]));
    [Fact]
    public void MissingOrUnsupportedPolicyBlocksBeforeCodeExecution()
    {
        Assert.Throws<InvalidOperationException>(() => GameEngineerExecution.CompletionCode(null));
        Assert.Throws<InvalidOperationException>(() => GameEngineerExecution.CompletionCode([]));
        Assert.Throws<InvalidOperationException>(() => GameEngineerExecution.CompletionCode(["merged"]));
    }
}
