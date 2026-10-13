using CSweet.Agent.SDK;
using Microsoft.Extensions.AI;

namespace CSweet.Agent.Engineer.VideoGame;

public sealed partial class GameEngineerAgent
{
    private ProjectIntakeService ProjectIntake() =>
        new(new DevelopmentChatClientProvider(Settings, _llmClientFactory));

    private Task ResumeProjectIntakeAsync(ProjectIntakeSummary intake, AgentRuntimeContext context,
        CancellationToken ct) =>
        ProjectIntake().ResumeProjectIntakeAsync(intake, context, ct);
}