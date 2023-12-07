using Codebreaker.GameAPIs.Contracts;

namespace Codebreaker.GameAPIs.Models;

public class Game : IGame
{
    public Game(
        Guid gameId,
        string gameType,
        string playerName,
        DateTime startTime,
        int numberCodes,
        int maxMoves
    )
    {
        GameId = gameId;
        GameType = gameType;
        PlayerName = playerName;
        StartTime = startTime;
        NumberCodes = numberCodes;
        MaxMoves = maxMoves;
    }

    public Guid GameId { get; }
    public string GameType { get; }
    public string PlayerName { get; }
    public DateTime StartTime { get; }
    public DateTime? EndTime { get; set; }
    public TimeSpan? Duration { get; set; }
    public int LastMoveNumber { get; set; } = 0;
    public int NumberCodes { get; private set; }
    public int MaxMoves { get; private set; }
    public bool IsVictory { get; set; } = false;

    public required IDictionary<string, IEnumerable<string>> FieldValues { get; init; }

    public required string[] Codes { get; init; }
    public ICollection<Move> Moves { get; } = new List<Move>();

    public override string ToString() => $"{GameId}:{GameType} - {StartTime}";
}
