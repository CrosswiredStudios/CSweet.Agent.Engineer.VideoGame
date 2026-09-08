# Video Game Engineer

Implements tested gameplay and runtime code, integrations, source-control delivery, and build fixes.

## Contract

- Package ID: `com.csweet.video-game-engineer`
- Version: `1.0.0`
- Provides: `work.execution.run.v1`
- Activation: manual
- Requested platform/provider capabilities: none
- Event subscriptions: none
- Network access: none

## Develop

```powershell
dotnet test
dotnet run --project src/CSweet.Agent.Engineer.VideoGame -- --self-test
```

The tests run entirely in memory and require no C-Sweet instance or credentials.

## Install

Keep `csweet-plugin.json` at the repository root. Import a reviewed GitHub commit in C-Sweet, or
clone this repository as an immediate child of C-Sweet's configured local agent catalog. Review
the exact manifest, grants, activation mode, and source before approving installation.

Built with `CSweet.Agent.SDK` 3.27.0 and the bundled video-game extension source.


## Extension ownership and isolated builds

Game-specific payload helpers and decision logic live in the bundled `extensions/video-game` source snapshot under the publisher-owned `CrosswiredStudios.VideoGame` namespace. They are compiled into this agent, not published as C-Sweet platform contracts. The snapshot has versioned SHA-256 provenance and needs no sibling checkout or domain NuGet feed. C-Sweet handles generic coordination envelopes and profile metadata; agent permissions and existing wire type IDs remain unchanged.

## Brokered code delivery (2.3.0)

Game engineering execution now uses the platform-provided ticket workspace and coding harness to edit files and run validation. The ticket must already have an authoritative development brief and repository binding. Execution requests the software-development-polyglot-v1 environment, read/write workspace access, and work-item-scoped Git prepare, inspect, publish and cleanup capabilities. The one-hour execution budget replaces the documentation-only timeout. The SDK pin is 3.31.1; no shared SDK changes are required.

Successful execution requires changed files, successful validation results, actual reviewable workspace changes, and platform publication evidence. Pull-request delivery requires a returned PR URL. The published outcome is persisted per stage, attempt and assignment revision for duplicate-delivery recovery. Missing configuration or failed execution returns Blocked rather than completing with a Markdown artifact. Coding remains limited to game-engineer assignments and platform-granted repositories; no merge authority is requested. Lead review, independent QA and local preview are separate downstream requirements and are not proven by the implementation stage alone.

The assignment validator accepts the host camel-case wire format while retaining exact role, assignment-selection and accepted-package checks. Regression coverage includes both host wire casing and prior Pascal-case payloads, plus rejection for another specialist role.

### Policy-aware source completion (2.3.0)
The canonical assignment supplies allowed outcomes from its immutable policy. The Engineer prefers code-published to enter technical review, retaining completed only when that is the supported legacy route. Missing or unsupported outcome metadata blocks before workspace preparation. Requires host support for Work Management Contracts 3.17.0; no extra capabilities are requested.
