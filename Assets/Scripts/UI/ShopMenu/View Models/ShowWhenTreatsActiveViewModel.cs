using UnityEngine;

public class ShowWhenTreatsActiveViewModel : HideableViewModel<ShopMenuModel>
{
    [SerializeField] private bool showWhenTreatsActive = true;

    protected override bool IsVisible()
    {
        return Model.TreatsVisible == showWhenTreatsActive;
    }
}
