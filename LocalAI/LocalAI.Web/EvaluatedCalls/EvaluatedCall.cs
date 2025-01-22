namespace LocalAI.Web.EvaluatedCalls;

public sealed class EvaluatedCall
{
    public string GridId { get; private set; }

    public string FileName { get; private set; }

    public string UrlFile { get; private set; }

    public Transcription Transcription { get; private set; }

    public CallDetails CallDetails { get; private set; }

    public Evaluation Evaluation { get; private set; }

    public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;

    public string ExternalReferenceId { get; private set; }

    public static EvaluatedCall Initialize(string filename,
                                           CallDetails callDetails,
                                           Transcription transcription,
                                           string gridId,
                                           string urlFile,
                                           string externalReferenceId)
    {
        EvaluatedCall evaluatedCall = new()
        {
            FileName = filename,
            CallDetails = callDetails,
            Transcription = transcription,
            GridId = gridId,
            UrlFile = urlFile,
            UpdatedAt = DateTime.UtcNow,
            ExternalReferenceId = externalReferenceId,
        };

        return evaluatedCall;
    }
}