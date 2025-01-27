using System.Text;

namespace LocalAI.Web.EvaluatedCalls;

public sealed class Transcription
{
    public string ExternalId { get;  set; }

    public string Summary { get;  set; }

    public string FullTranscript { get;  set; }

    public IReadOnlyList<TranscriptionUtterance> Utterances { get;  set; }

    public string AudioUrl { get;  set; }

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