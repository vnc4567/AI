namespace LocalAI.Web.EvaluatedCalls;

public sealed record TranscriptionWord
{
    public string Word { get; private set; }

    public decimal StartedOffsetInSeconds { get; private set; }

    public decimal EndedOffsetInSeconds { get; private set; }

    public decimal Confidence { get; private set; }

    public static TranscriptionWord Create(string word,
                                           decimal startedOffsetInSeconds,
                                           decimal endedOffsetInSeconds,
                                           decimal confidence) => new()
    {
        Word = word,
        StartedOffsetInSeconds = Math.Round(startedOffsetInSeconds, 2),
        EndedOffsetInSeconds = Math.Round(endedOffsetInSeconds, 2),
        Confidence = confidence,
    };
}