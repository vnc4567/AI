namespace LocalAI.Web.EvaluatedCalls;

public sealed class GradedCriterion
{
    public string Category { get; private set; }

    public string CriterionName { get; private set; }

    public string Comment { get; private set; }

    public string Appreciation { get; private set; }

    public decimal Score { get; private set; }

    public decimal MaxScore { get; private set; }

    public IReadOnlyList<KeyPoint> KeyPoints { get; private set; }
}