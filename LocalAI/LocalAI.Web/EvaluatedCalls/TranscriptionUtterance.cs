namespace LocalAI.Web.EvaluatedCalls;

public sealed record TranscriptionUtterance
{
    public string Text { get;  set; }

    public IReadOnlyList<TranscriptionWord> Words { get;  set; }

    public decimal StartedOffsetInSeconds { get;  set; }

    public decimal EndedOffsetInSeconds { get;  set; }

    public int Speaker { get;  set; }

    public int Channel { get;  set; }
    
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