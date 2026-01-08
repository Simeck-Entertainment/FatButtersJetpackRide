using UnityEngine;

public class IncrementShopItemButtonViewModel : ButtonViewModel<ShopMenuModel>
{
    [SerializeField] private int incrementAmount;

    protected override void OnClick()
    {
        Model.IncrementShopItem(incrementAmount);
    }
}
