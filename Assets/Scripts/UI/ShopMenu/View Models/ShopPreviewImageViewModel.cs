using UnityEngine;

public class ShopPreviewImageViewModel : ImageViewModel<ShopMenuModel>
{
    protected override Sprite GetSprite()
    {
        return Model.CurrentSelectedShopItem.itemImg;
    }
}
