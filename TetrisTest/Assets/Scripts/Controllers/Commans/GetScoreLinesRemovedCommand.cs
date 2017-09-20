using strange.extensions.command.impl;

public class GetScoreLinesRemovedCommand : EventCommand
{
    [Inject]
    public Score score { get; set; }

    public override void Execute()
    {
        int linesCount = (int) evt.data;
        score.SetScoreFromRemovedLines(linesCount);
    }
}