public class ShowWhenOnScreenControlsEnabled : HideableViewModel<GameplayUIModel>
{
    protected override bool IsVisible()
    {
        return Model.OnScreenControlsEnabled;
    }
}
