public class ShowWhenPostLevelAdsEnabledViewModel : HideableViewModel<SettingsMenuModel>
{
    protected override bool IsVisible()
    {
        return Model.PostLevelAdsEnabled;
    }
}
