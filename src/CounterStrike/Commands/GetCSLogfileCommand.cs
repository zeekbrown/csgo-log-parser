using System.IO;
using System.Management.Automation;
using CounterStrike.GameEvents;

namespace CounterStrike.Commands;

[Cmdlet(VerbsCommon.Get, "CSLogfile")]
[OutputType(typeof(ClientCvarEvent.Data))]
[OutputType(typeof(ClientCvarStartEndEvent.Data))]
[OutputType(typeof(FreezePeriodStartingEvent.Data))]
[OutputType(typeof(GameObjectSpawnedEvent.Data))]
[OutputType(typeof(GameOverEvent.Data))]
[OutputType(typeof(LoadingMapEvent.Data))]
[OutputType(typeof(LogfileClosedEvent.Data))]
[OutputType(typeof(LogfileStartedEvent.Data))]
[OutputType(typeof(MapStartedEvent.Data))]
[OutputType(typeof(MatchStatusScoreEvent.Data))]
[OutputType(typeof(MatchStatusTeamEvent.Data))]
[OutputType(typeof(PlayerAssistedPlayerEvent.Data))]
[OutputType(typeof(PlayerAttackedPlayerEvent.Data))]
[OutputType(typeof(PlayerAwardEvent.Data))]
[OutputType(typeof(PlayerBlindedPlayerEvent.Data))]
[OutputType(typeof(PlayerConnectedEvent.Data))]
[OutputType(typeof(PlayerDisconnectedEvent.Data))]
[OutputType(typeof(PlayerEnteredEvent.Data))]
[OutputType(typeof(PlayerKilledByBombEvent.Data))]
[OutputType(typeof(PlayerKilledOtherEvent.Data))]
[OutputType(typeof(PlayerKilledPlayerEvent.Data))]
[OutputType(typeof(PlayerLeftBuyzoneEvent.Data))]
[OutputType(typeof(PlayerPickedUpHostageEvent.Data))]
[OutputType(typeof(PlayerPurchasedEvent.Data))]
[OutputType(typeof(PlayerDroppedOffHostageEvent.Data))]
[OutputType(typeof(PlayerSuicideEvent.Data))]
[OutputType(typeof(PlayerSwitchedTeamEvent.Data))]
[OutputType(typeof(PlayerThrewWeaponEvent.Data))]
[OutputType(typeof(PlayerTriggeredEvent.Data))]
[OutputType(typeof(PlayerValidatedEvent.Data))]
[OutputType(typeof(PlayerValidationFailedEvent.Data))]
[OutputType(typeof(ServerCvarEvent.Data))]
[OutputType(typeof(ServerMessageEvent.Data))]
[OutputType(typeof(TeamScoredEvent.Data))]
[OutputType(typeof(TeamTriggeredEvent.Data))]
[OutputType(typeof(WorldTriggeredEvent.Data))]
public class GetCSLogfileCommand : PSCmdlet
{
    [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ValueFromPipelineByPropertyName = true)]
    public string Path { get; set; }

    protected override void ProcessRecord()
    {
        using var reader = new StreamReader(Path);

        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();

            switch (line)
            {
                case var s when PlayerAttackedPlayerEvent.IsMatch(s):
                    WriteObject(PlayerAttackedPlayerEvent.GetData(s));
                    WriteInformation(s, new string[] { nameof(PlayerAttackedPlayerEvent) });
                    break;

                case var s when PlayerKilledPlayerEvent.IsMatch(s):
                    WriteObject(PlayerKilledPlayerEvent.GetData(s));
                    WriteInformation(s, new string[] { nameof(PlayerKilledPlayerEvent) });
                    break;

                case var s when PlayerKilledOtherEvent.IsMatch(s):
                    WriteObject(PlayerKilledOtherEvent.GetData(s));
                    WriteInformation(s, new string[] { nameof(PlayerKilledOtherEvent) });
                    break;

                case var s when PlayerAssistedPlayerEvent.IsMatch(s):
                    WriteObject(PlayerAssistedPlayerEvent.GetData(s));
                    WriteInformation(s, new string[] { nameof(PlayerAssistedPlayerEvent) });
                    break;

                case var s when PlayerLeftBuyzoneEvent.IsMatch(s):
                    WriteObject(PlayerLeftBuyzoneEvent.GetData(s));
                    WriteInformation(s, new string[] { nameof(PlayerLeftBuyzoneEvent) });
                    break;

                case var s when PlayerDroppedOffHostageEvent.IsMatch(s):
                    WriteObject(PlayerDroppedOffHostageEvent.GetData(s));
                    WriteInformation(s, new string[] { nameof(PlayerDroppedOffHostageEvent) });
                    break;

                case var s when PlayerPickedUpHostageEvent.IsMatch(s):
                    WriteObject(PlayerPickedUpHostageEvent.GetData(s));
                    WriteInformation(s, new string[] { nameof(PlayerPickedUpHostageEvent) });
                    break;

                case var s when ServerCvarEvent.IsMatch(s):
                    WriteObject(ServerCvarEvent.GetData(s));
                    WriteInformation(s, new string[] { nameof(ServerCvarEvent) });
                    break;

                case var s when ClientCvarEvent.IsMatch(s):
                    WriteObject(ClientCvarEvent.GetData(s));
                    WriteInformation(s, new string[] { nameof(ClientCvarEvent) });
                    break;

                case var s when PlayerEnteredEvent.IsMatch(s):
                    WriteObject(PlayerEnteredEvent.GetData(s));
                    WriteInformation(s, new string[] { nameof(PlayerEnteredEvent) });
                    break;

                case var s when PlayerDisconnectedEvent.IsMatch(s):
                    WriteObject(PlayerDisconnectedEvent.GetData(s));
                    WriteInformation(s, new string[] { nameof(PlayerDisconnectedEvent) });
                    break;

                case var s when PlayerConnectedEvent.IsMatch(s):
                    WriteObject(PlayerConnectedEvent.GetData(s));
                    WriteInformation(s, new string[] { nameof(PlayerConnectedEvent) });
                    break;

                case var s when PlayerSwitchedTeamEvent.IsMatch(s):
                    WriteObject(PlayerSwitchedTeamEvent.GetData(s));
                    WriteInformation(s, new string[] { nameof(PlayerSwitchedTeamEvent) });
                    break;

                case var s when PlayerPurchasedEvent.IsMatch(s):
                    WriteObject(PlayerPurchasedEvent.GetData(s));
                    WriteInformation(s, new string[] { nameof(PlayerPurchasedEvent) });
                    break;

                case var s when PlayerBlindedPlayerEvent.IsMatch(s):
                    WriteObject(PlayerBlindedPlayerEvent.GetData(s));
                    WriteInformation(s, new string[] { nameof(PlayerBlindedPlayerEvent) });
                    break;

                case var s when PlayerTriggeredEvent.IsMatch(s):
                    WriteObject(PlayerTriggeredEvent.GetData(s));
                    WriteInformation(s, new string[] { nameof(PlayerTriggeredEvent) });
                    break;

                case var s when PlayerKilledByBombEvent.IsMatch(s):
                    WriteObject(PlayerKilledByBombEvent.GetData(s));
                    WriteInformation(s, new string[] { nameof(PlayerKilledByBombEvent) });
                    break;

                case var s when PlayerSuicideEvent.IsMatch(s):
                    WriteObject(PlayerSuicideEvent.GetData(s));
                    WriteInformation(s, new string[] { nameof(PlayerSuicideEvent) });
                    break;

                case var s when PlayerThrewWeaponEvent.IsMatch(s):
                    WriteObject(PlayerThrewWeaponEvent.GetData(s));
                    WriteInformation(s, new string[] { nameof(PlayerThrewWeaponEvent) });
                    break;

                case var s when WorldTriggeredEvent.IsMatch(s):
                    WriteObject(WorldTriggeredEvent.GetData(s));
                    WriteInformation(s, new string[] { nameof(WorldTriggeredEvent) });
                    break;

                case var s when TeamTriggeredEvent.IsMatch(s):
                    WriteObject(TeamTriggeredEvent.GetData(s));
                    WriteInformation(s, new string[] { nameof(TeamTriggeredEvent) });
                    break;

                case var s when PlayerValidatedEvent.IsMatch(s):
                    WriteObject(PlayerValidatedEvent.GetData(s));
                    WriteInformation(s, new string[] { nameof(PlayerValidatedEvent) });
                    break;

                case var s when PlayerValidationFailedEvent.IsMatch(s):
                    WriteObject(PlayerValidationFailedEvent.GetData(s));
                    WriteInformation(s, new string[] { nameof(PlayerValidationFailedEvent) });
                    break;

                case var s when TeamScoredEvent.IsMatch(s):
                    WriteObject(TeamScoredEvent.GetData(s));
                    WriteInformation(s, new string[] { nameof(TeamScoredEvent) });
                    break;

                case var s when FreezePeriodStartingEvent.IsMatch(s):
                    WriteObject(FreezePeriodStartingEvent.GetData(s));
                    WriteInformation(s, new string[] { nameof(FreezePeriodStartingEvent) });
                    break;

                case var s when MatchStatusScoreEvent.IsMatch(s):
                    WriteObject(MatchStatusScoreEvent.GetData(s));
                    WriteInformation(s, new string[] { nameof(MatchStatusScoreEvent) });
                    break;

                case var s when MatchStatusTeamEvent.IsMatch(s):
                    WriteObject(MatchStatusTeamEvent.GetData(s));
                    WriteInformation(s, new string[] { nameof(MatchStatusTeamEvent) });
                    break;

                case var s when PlayerAwardEvent.IsMatch(s):
                    WriteObject(PlayerAwardEvent.GetData(s));
                    WriteInformation(s, new string[] { nameof(PlayerAwardEvent) });
                    break;

                case var s when LogfileStartedEvent.IsMatch(s):
                    WriteObject(LogfileStartedEvent.GetData(s));
                    WriteInformation(s, new string[] { nameof(LogfileStartedEvent) });
                    break;

                case var s when LogfileClosedEvent.IsMatch(s):
                    WriteObject(LogfileClosedEvent.GetData(s));
                    WriteInformation(s, new string[] { nameof(LogfileClosedEvent) });
                    break;

                case var s when LoadingMapEvent.IsMatch(s):
                    WriteObject(LoadingMapEvent.GetData(s));
                    WriteInformation(s, new string[] { nameof(LoadingMapEvent) });
                    break;

                case var s when ClientCvarStartEndEvent.IsMatch(s):
                    WriteObject(ClientCvarStartEndEvent.GetData(s));
                    WriteInformation(s, new string[] { nameof(ClientCvarStartEndEvent) });
                    break;

                case var s when GameObjectSpawnedEvent.IsMatch(s):
                    WriteObject(GameObjectSpawnedEvent.GetData(s));
                    WriteInformation(s, new string[] { nameof(GameObjectSpawnedEvent) });
                    break;

                case var s when GameOverEvent.IsMatch(s):
                    WriteObject(GameOverEvent.GetData(s));
                    WriteInformation(s, new string[] { nameof(GameOverEvent) });
                    break;

                case var s when MapStartedEvent.IsMatch(s):
                    WriteObject(MapStartedEvent.GetData(s));
                    WriteInformation(s, new string[] { nameof(MapStartedEvent) });
                    break;

                case var s when ServerMessageEvent.IsMatch(s):
                    WriteObject(ServerMessageEvent.GetData(s));
                    WriteInformation(s, new string[] { nameof(ServerMessageEvent) });
                    break;

                default:
                    WriteError(new ErrorRecord(new InvalidDataException(line), null, ErrorCategory.InvalidData, line));
                    WriteInformation(line, new string[] { "UnmatchedEvents" });
                    break;
            }
        }
    }
}