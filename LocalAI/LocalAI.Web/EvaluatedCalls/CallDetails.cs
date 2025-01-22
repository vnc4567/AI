namespace LocalAI.Web.EvaluatedCalls;

public sealed record CallDetails
{
    public string AgentId { get; private set; }

    public DateTime FileIntegratedAt { get; private set; }

    public decimal DurationInSeconds { get; private set; }

    public string TeamName { get; private set; }

    public string CallCenterName { get; private set; }

    public static CallDetails Create(DateTime fileIntegratedAt, decimal durationInSeconds) => new()
    {
        FileIntegratedAt = fileIntegratedAt,
        DurationInSeconds = durationInSeconds,
    };

    public static CallDetails Create(string agentId,
                                     DateTime fileIntegratedAt,
                                     decimal durationInSeconds,
                                     string callCenterName,
                                     string teamName) => new()
    {
        AgentId = agentId,
        FileIntegratedAt = fileIntegratedAt,
        DurationInSeconds = durationInSeconds,
        CallCenterName = callCenterName,
        TeamName = teamName,
    };
}