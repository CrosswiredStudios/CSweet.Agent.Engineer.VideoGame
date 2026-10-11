using CSweet.Agent.SDK;
using CSweet.WorkManagement.Contracts;

namespace CSweet.Agent.Engineer.VideoGame;

public sealed partial class SpecialistAgent
{
    protected override Task<AgentWorkResult> ExecuteDeliveryScopeAsync(WorkExecutionAssignmentV2 assignment,
        AgentRuntimeContext context, CancellationToken ct) => assignment.StageKey == "build-readiness"
        ? DeliveryBuildReadiness.ExecuteAsync(assignment, context, ct)
        : base.ExecuteDeliveryScopeAsync(assignment, context, ct);
}
