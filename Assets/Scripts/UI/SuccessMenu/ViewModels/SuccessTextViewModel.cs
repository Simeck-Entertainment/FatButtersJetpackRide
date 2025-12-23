public class SuccessTextViewModel : TextViewModel<SuccessMenuModel>
{
    protected override string GetText()
    {
        return $"You have found {Model.NewBones} new bones!";
    }
}
