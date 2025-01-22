namespace LocalAI.Web.EvaluatedCalls;

public sealed class Evaluation
{
    public DateTime StartedAt { get; private set; }

    public DateTime EndedAt { get; private set; }

    public bool? IsObjectiveReached { get; private set; }

    public decimal Score { get; private set; }

    public decimal MaxScore { get; private set; }

    public decimal? MinPartialScore { get; private set; }

    public decimal? MaxPartialScore { get; private set; }

    public IReadOnlyList<GradedCriterion> GradedCriteria { get; private set; }

    public string Summary { get; private set; }
}