namespace LocalAI.Web.EvaluatedCalls;

public sealed record TranscriptionUtterance
{
    public string Text { get; private set; }

    public IReadOnlyList<TranscriptionWord> Words { get; private set; }

    public decimal StartedOffsetInSeconds { get; private set; }

    public decimal EndedOffsetInSeconds { get; private set; }

    public int Speaker { get; private set; }

    public int Channel { get; private set; }
    
    public void ConcatUtterance(TranscriptionUtterance transcriptionUtterance)
    {
        if (transcriptionUtterance is null)
        {
            return;
        }

        EndedOffsetInSeconds = transcriptionUtterance.EndedOffsetInSeconds;

        if (transcriptionUtterance.Words?.Count > 0)
        {
            Words = new List<TranscriptionWord>().Concat(Words).Concat(transcriptionUtterance.Words).ToList();
        }

        Text += $" {transcriptionUtterance.Text?.Trim()}";
    }

    public string PrintUtterance() => $"{Speaker} | {StartedOffsetInSeconds} : {Text}";
}