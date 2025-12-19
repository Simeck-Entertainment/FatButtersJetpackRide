public class ShowWhenBoneDoublerVideoAdsEnabled : HideableViewModel<SettingsMenuModel>
{
    protected override bool IsVisible()
    {
        return Model.BoneDoublerVideoAdsEnabled;
    }
}