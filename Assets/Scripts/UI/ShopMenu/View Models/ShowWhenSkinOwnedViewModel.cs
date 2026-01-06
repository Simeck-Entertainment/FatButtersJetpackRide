using UnityEngine;

public class ShowWhenSkinOwnedViewModel : HideableViewModel<ShopMenuModel>
{
    [SerializeField] private bool showWhenSkinOwned = true;

    protected override bool IsVisible()
    {
        return Model.IsActiveSkinOwned() == showWhenSkinOwned;
    }
}
