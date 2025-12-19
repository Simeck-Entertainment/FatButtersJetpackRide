public class ShowWhenPostLevelAdsEnabled : HideableViewModel<SettingsMenuModel>
{
    protected override bool IsVisible()
    {
        return Model.PostLevelAdsEnabled;
    }
}
