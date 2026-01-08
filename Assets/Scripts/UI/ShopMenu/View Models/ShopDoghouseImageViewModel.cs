using UnityEngine;

public class ShopDoghouseImageViewModel : ImageViewModel<ShopMenuModel>
{
    protected override Sprite GetSprite()
    {
        if (Model.CurrentSelectedShopItem.dogHouseButtersImg != null)
        {
            return Model.CurrentSelectedShopItem.dogHouseButtersImg;
        }
        else
        {
            return Model.CurrentEquippedShopItem.dogHouseButtersImg;
        }
    }
}
