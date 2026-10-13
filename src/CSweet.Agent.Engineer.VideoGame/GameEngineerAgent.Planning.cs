using CSweet.Agent.SDK;
using CSweet.WorkManagement.Contracts;

namespace CSweet.Agent.Engineer.VideoGame;

public sealed partial class GameEngineerAgent
{
    internal Task<PersonalWorkPlan> PrepareDevelopmentPlanAsync(
        PersonalTodoItem item, AgentRuntimeContext context, CancellationToken cancellationToken) =>
        new PersonalDevelopmentService(
            Settings,
            new DevelopmentChatClientProvider(Settings, _llmClientFactory))
            .PrepareDevelopmentPlanAsync(item, context, cancellationToken);
}
