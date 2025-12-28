public class PauseButtonViewModel : ButtonViewModel<GameplayUIModel>
{
    protected override void OnClick()
    {
        Model.SetPaused(true);
    }
}
