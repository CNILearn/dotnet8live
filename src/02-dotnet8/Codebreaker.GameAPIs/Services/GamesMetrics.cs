using System.Diagnostics.Metrics;

namespace Codebreaker.GameAPIs.Services;

internal sealed class GamesMetrics
{
    public const string MeterName = "Codebreaker.Games";
    private readonly Meter _meter;
    private readonly Counter<long> _gamesStartedCounter;
    private readonly Counter<long> _gamesEndedCounter;

    public GamesMetrics(IMeterFactory meterFactory)
    {
        _meter = meterFactory.Create(MeterName);
        _gamesStartedCounter = _meter.CreateCounter<long>(
            "codebreaker.games.started",
            unit: "{started}",
            description: "Number of games started.");

        _gamesEndedCounter = _meter.CreateCounter<long>(
            "codebreaker.games.ended",
            unit: "{ended}",
            description: "Number of games ended.");
    }

    public void GameStarted()
    {
        _gamesStartedCounter.Add(1);
    }

    public void GameEnded()
    {
        _gamesEndedCounter.Add(1);
    }

}
