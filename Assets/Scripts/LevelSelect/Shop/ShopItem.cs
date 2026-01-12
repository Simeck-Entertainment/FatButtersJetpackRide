using UnityEngine;

[CreateAssetMenu(fileName = "Shop Item", menuName = "Fatbutters/Shop Item")]
public class ShopItem : ScriptableObject
{
    public ShopItemType Type;
    public string itemName;
    public Sprite itemImg;
    public Sprite JetpackImg;
    public Sprite dogHouseButtersImg;
    [Tooltip ("0 for incremental, any value for set price.")]
    public int itemPrice;
    [Header("Matters Only for Skins")]
    public int SkinId;
}

public enum ShopItemType
{
    Skin,
    Fuel,
    Thrust,
    Tummy
}
