public class ShowWhenPauseMenuAdsEnabledViewModel : HideableViewModel<SettingsMenuModel>
{
    protected override bool IsVisible()
    {
        return Model.PauseMenuAdsEnabled;
    }
}
