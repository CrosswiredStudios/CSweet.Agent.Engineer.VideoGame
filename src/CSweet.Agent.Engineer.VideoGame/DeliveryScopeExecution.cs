using CSweet.Agent.SDK;
using CSweet.WorkManagement.Contracts;

namespace CSweet.Agent.Engineer.VideoGame;

public sealed partial class GameEngineerAgent
{
    protected override Task<AgentWorkResult> ExecuteDeliveryScopeAsync(WorkExecutionAssignment assignment,
        AgentRuntimeContext context, CancellationToken ct) => assignment.StageKey == "build-readiness"
        ? DeliveryBuildReadiness.ExecuteAsync(assignment, context, ct)
        : base.ExecuteDeliveryScopeAsync(assignment, context, ct);
}
