public class ShowIfCorgiSenseEnabled : HideableViewModel<GameplayUIModel>
{
    protected override bool IsVisible()
    {
        return Model.CorgiSenseEnabled;
    }
}
