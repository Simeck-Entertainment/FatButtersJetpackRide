using UnityEngine;

public class ShopJetpackImageViewModel : ImageViewModel<ShopMenuModel>
{
    protected override Sprite GetSprite()
    {
        return Model.CurrentSelectedShopItem.JetpackImg;
    }
}
