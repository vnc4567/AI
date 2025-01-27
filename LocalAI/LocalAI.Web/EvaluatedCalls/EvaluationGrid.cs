using System.Text;

namespace ConvoAnalyzer.Domain.Entities.Grids;

public sealed class EvaluationGrid 
{
    public EvaluationGrid()
    {
        
    }
    public string Name { get;  set; }

    public string Description { get;  set; }

    public decimal TotalMaxScore { get;  set; }

    public DateTime UpdatedAt { get;  set; }
    public DateTime CreatedAt { get;  set; }

    public IReadOnlyList<EvaluationGridCriterion> Criteria { get;  set; }

    public bool IsActive { get;  set; }

    public decimal? MinPartialScore { get;  set; }

    public decimal? MaxPartialScore { get;  set; }

    public string SummaryPrompt { get;  set; }

    public string ExternalReferenceId { get;  set; }

    public bool IsDeleted { get;  set; }

    public string PrintCriteriaToString()
    {
        StringBuilder stringBuilder = new();

        foreach (EvaluationGridCriterion evaluationGridCriterion in Criteria)
        {
            stringBuilder.Append(evaluationGridCriterion.PrintEvaluationGridCriterion());
        }

        return stringBuilder.ToString();
    }

    public static EvaluationGrid Create(string name,
                                        string description,
                                        decimal totalMaxScore,
                                        IEnumerable<EvaluationGridCriterion> criteria,
                                        decimal? minPartialScore = null,
                                        decimal? maxPartialScore = null,
                                        string summaryPrompt = null,
                                        string externalReferenceId = null)
    {
        return new EvaluationGrid
        {
            Name = name,
            Description = description,
            Criteria = criteria.ToList(),
            IsActive = true,
            MinPartialScore = minPartialScore,
            MaxPartialScore = maxPartialScore,
            UpdatedAt = DateTime.UtcNow,
            SummaryPrompt = summaryPrompt,
            ExternalReferenceId = externalReferenceId,
        };
    }

    public IReadOnlyList<EvaluationGridCriterion> GetOrderedEvaluationGridCriteria()
    {
        if (Criteria.Any(x => x.Position != 0))
        {
            return Criteria.OrderBy(x => x.Position).ToList();
        }

        for (int i = 0; i < Criteria.Count; i++)
        {
            Criteria[i].SetPosition(i);
        }

        return Criteria;
    }
}

public sealed record EvaluationGridCriterion
{
    public int Position { get;  set; }
    
    public string Category { get;  set; }

    public string Name { get;  set; }

    public string Description { get;  set; }

    public string MaxScore { get;  set; }

    public string CompliantReason { get;  set; }

    public string PartialReason { get;  set; }

    public string NonCompliantReason { get;  set; }

    public string NonApplicableReason { get;  set; }

    public bool MustBeSatisfied { get;  set; }

    public bool IsActive { get;  set; }

    public EvaluationGridCriterion()
    {
    }

   
    public string PrintEvaluationGridCriterion()
    {
        StringBuilder stringBuilder = new();

        stringBuilder.Append(Environment.NewLine);
        stringBuilder.Append($"Categorie : {Category}");
        stringBuilder.Append(Environment.NewLine);
        stringBuilder.Append($"Critère : {Name}");
        stringBuilder.Append(Environment.NewLine);
        stringBuilder.Append($"- Conforme : {CompliantReason}");

        if (!string.IsNullOrWhiteSpace(PartialReason))
        {
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append($"- Partiel si : {PartialReason}");
        }

        stringBuilder.Append(Environment.NewLine);
        stringBuilder.Append($"- Non conforme si : {NonCompliantReason}");

        if (!string.IsNullOrWhiteSpace(NonApplicableReason))
        {
            stringBuilder.Append(Environment.NewLine);
            stringBuilder.Append($"- Non applicable si : {NonApplicableReason}");
        }

        stringBuilder.Append(Environment.NewLine);
        stringBuilder.Append($"Max score : {MaxScore}");

        return stringBuilder.ToString();
    }

    public void SetPosition(int position)
    {
        Position = position;
    }
}