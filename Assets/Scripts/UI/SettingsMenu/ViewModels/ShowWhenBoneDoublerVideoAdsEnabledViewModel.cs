public class ShowWhenBoneDoublerVideoAdsEnabledViewModel : HideableViewModel<SettingsMenuModel>
{
    protected override bool IsVisible()
    {
        return Model.BoneDoublerVideoAdsEnabled;
    }
}
