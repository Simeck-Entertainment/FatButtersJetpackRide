public class SuccessToLevelSelectButtonViewModel : ButtonViewModel<SuccessMenuModel>
{
    protected override void OnClick()
    {
        Model.ToLevelSelect();
    }
}
