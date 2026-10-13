using CSweet.Agent.SDK;
using CSweet.Agent.Engineer.VideoGame.Phases.Onboarding;

namespace CSweet.Agent.Engineer.VideoGame;

public sealed partial class GameEngineerAgent
{
    protected override Task OnOnboardedAsync(
        AgentOnboardedEvent onboarded,
        AgentEventEnvelope message,
        AgentRuntimeContext context,
        CancellationToken cancellationToken) =>
        OnboardingService.HandleAsync(message, context, cancellationToken);
}
