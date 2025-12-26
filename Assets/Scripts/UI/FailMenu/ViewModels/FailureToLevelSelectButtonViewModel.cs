public class FailureToLevelSelectButtonViewModel : ButtonViewModel<FailMenuModel>
{
    protected override void OnClick()
    {
        Model.ToLevelSelect();
    }
}
