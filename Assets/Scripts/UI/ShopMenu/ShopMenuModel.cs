using UnityEngine;

public class ShopMenuModel : Model
{
    [SerializeField] private BuyScripts buyer;

    [SerializeField] private ShopItem[] shopItems;

    private int currentSelectedShopItem;
    private SaveManager saveManager;

    public ShopItem[] ShopItems => shopItems;
    public ShopItem CurrentSelectedShopItem => shopItems[currentSelectedShopItem];

    private bool _treatsVisible;
    public bool TreatsVisible
    {
        get
        {
            return _treatsVisible;
        }
        set
        {
            _treatsVisible = value;
            Refresh();
        }
    }

    private CollectibleData collectibleData => saveManager.collectibleData;

    private void Awake()
    {
        saveManager = Helper.NabSaveData().GetComponent<SaveManager>();
        saveManager.Load();
    }

    public bool IsActiveSkinOwned()
    {
        return collectibleData.HaveSkins[currentSelectedShopItem];
    }

    public bool IsActiveSkinEquipped()
    {
        return collectibleData.CurrentSkin == currentSelectedShopItem;
    }

    public void BuyCurrentSkin()
    {
        buyer.RunBuy(currentSelectedShopItem);
        Refresh();
    }

    public void EquipCurrentSkin()
    {
        buyer.RunBuy(currentSelectedShopItem);
        Refresh();
    }
}
