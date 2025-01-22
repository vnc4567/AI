namespace LocalAI.Web.EvaluatedCalls;

public static class TranscriptionUtteranceExtension
{
    public static IReadOnlyList<TranscriptionUtterance> CleanTranscriptionUtterances(this IEnumerable<TranscriptionUtterance> utterances)
    {
        List<TranscriptionUtterance> transcriptionUtterancesCleaned = [];

        List<TranscriptionUtterance> utterancesList = utterances?.ToList();

        if (utterancesList is null || utterancesList.Count == 0)
        {
            return transcriptionUtterancesCleaned;
        }

        TranscriptionUtterance currentUtterance = utterancesList[0];

        transcriptionUtterancesCleaned.Add(currentUtterance);

        for (int i = 1; i < utterancesList.Count; i++)
        {
            TranscriptionUtterance nextUtterance = utterancesList[i];

            bool isSameSpeaker = currentUtterance.Speaker == nextUtterance.Speaker;

            if (ShouldMergeUtterances(currentUtterance, nextUtterance))
            {
                currentUtterance.ConcatUtterance(nextUtterance);

                if (!isSameSpeaker)
                {
                    transcriptionUtterancesCleaned.Add(currentUtterance);
                }
            }
            else
            {
                transcriptionUtterancesCleaned.Add(nextUtterance);
                currentUtterance = utterancesList[i];
            }
        }

        return transcriptionUtterancesCleaned;
    }

    private static bool ShouldMergeUtterances(TranscriptionUtterance current, TranscriptionUtterance next)
    {
        IReadOnlyList<char> punctuations =
        [
            '.',
            '?',
            '!',
        ];

        char word = current.Text.TrimEnd().Last();

        return !punctuations.Contains(word) && current.Speaker == next.Speaker && current.Channel == next.Channel;
    }
}