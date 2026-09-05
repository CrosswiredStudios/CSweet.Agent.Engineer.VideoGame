using CrosswiredStudios.VideoGame.AgentKit;

namespace CSweet.Agent.Engineer.VideoGame;

public sealed class SpecialistAgent : VideoGameSpecialistAgentBase
{
    public override string AgentId => "com.csweet.video-game-engineer";
    public override string Version => "2.1.1";
    protected override string RoleKey => "game-engineer";
    protected override string ArtifactTypeKey => "video-game.engineering-delivery.v1";
    protected override string RolePrompt => "Own tested gameplay and runtime implementation, integrations, source-control delivery, and build fixes. Specify exact code changes, tests, source revision, and remaining technical risks.";
    protected override IReadOnlyList<string> RequiredSections => ["Implementation", "Interfaces", "Tests", "Source Revision", "Build Evidence", "Remaining Risks"];
}
