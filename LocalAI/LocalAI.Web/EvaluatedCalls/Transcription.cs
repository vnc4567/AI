using System.Text;

namespace LocalAI.Web.EvaluatedCalls;

public sealed class Transcription
{
    public string ExternalId { get; private set; }

    public string Summary { get; private set; }

    public string FullTranscript { get; private set; }

    public IReadOnlyList<TranscriptionUtterance> Utterances { get; private set; }

    public string AudioUrl { get; private set; }

    public string PrintUtterancesToString()
    {
        if (Utterances is null)
        {
            return string.Empty;
        }

        StringBuilder stringBuilder = new();

        foreach (TranscriptionUtterance utterance in Utterances)
        {
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.AppendLine(utterance.PrintUtterance());
        }

        return stringBuilder.ToString();
    }
}