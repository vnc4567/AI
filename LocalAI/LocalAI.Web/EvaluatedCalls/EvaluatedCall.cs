namespace LocalAI.Web.EvaluatedCalls;

public class EvaluatedCall
{
    public EvaluatedCall()
    {
        
    }
    public string GridId { get;  set; }

    public string FileName { get;  set; }

    public string UrlFile { get;  set; }

    public Transcription Transcription { get;  set; }

    public CallDetails CallDetails { get;  set; }

    public Evaluation Evaluation { get;  set; }

    public DateTime UpdatedAt { get;  set; } = DateTime.UtcNow;

    public string ExternalReferenceId { get;  set; }

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