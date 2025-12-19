public class ShowWhenPauseMenuAdsEnabled : HideableViewModel<SettingsMenuModel>
{
    protected override bool IsVisible()
    {
        return Model.PauseMenuAdsEnabled;
    }
}
