using strange.extensions.command.impl;

public class GetScoreLinesRemovedCommand : Command
{
    [Inject]
    public Score score { get; set; }

    [Inject]
    public int _score { get; set; }

    public override void Execute()
    {
        score.SetScoreFromRemovedLines(_score);
    }
}