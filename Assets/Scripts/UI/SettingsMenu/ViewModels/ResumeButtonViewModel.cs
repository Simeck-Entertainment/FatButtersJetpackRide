public class ResumeButtonViewModel : ButtonViewModel<GameplayUIModel>
{
    protected override void OnClick()
    {
        Model.SetPaused(false);
    }
}
