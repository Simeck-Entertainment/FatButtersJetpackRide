using System.Text.RegularExpressions;
using UnityEngine;
using System.Linq;

public class ShopMenuModel : Model
{
    [SerializeField] private BuyScripts buyer;

    [SerializeField] private ShopItem[] shopItems;

    private int currentSelectedShopItem;
    private SaveManager saveManager;

    public ShopItem CurrentSelectedShopItem => shopItems[currentSelectedShopItem];
    public ShopItem CurrentEquippedShopItem => shopItems.First(x => x.isSkin && x.SkinId == collectibleData.CurrentSkin);

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

    public void IncrementShopItem(int incrementAmount)
    {
        currentSelectedShopItem += incrementAmount;
        if (currentSelectedShopItem >= shopItems.Length)
        {
            currentSelectedShopItem = 0;
        }
        else if (currentSelectedShopItem < 0)
        {
            currentSelectedShopItem = shopItems.Length - 1;
        }

        Refresh();
    }

    public bool IsActiveSkinOwned()
    {
        if (!CurrentEquippedShopItem.isSkin)
        {
            return false;
        }

        return collectibleData.HaveSkins[CurrentSelectedShopItem.SkinId];
    }

    public bool IsActiveSkinEquipped()
    {
        if (!CurrentEquippedShopItem.isSkin)
        {
            return false;
        }

        return collectibleData.CurrentSkin == CurrentSelectedShopItem.SkinId;
    }

    public void BuyCurrentItem()
    {
        var price = GetCurrentItemCost();

        switch (currentSelectedShopItem)
        {
            case 0: //Will always be fuel
                buyer.UpgradeFuel(price);
                break;
            case 1: //will always be thrust
                buyer.UpgradeThrust(price);
                break;

            case 2: //will always be tummy
                buyer.UpgradeTummy(price);
                break;
            default: //everything else
                buyer.BuySkin(CurrentSelectedShopItem.SkinId, price);
                break;
        }

        Refresh();
    }

    public void EquipCurrentSkin()
    {
        buyer.EquipSkin(CurrentSelectedShopItem.SkinId);
        Refresh();
    }

    public int GetCurrentItemCost()
    {
        if (CurrentSelectedShopItem.itemPrice == 0)
        {
            // If the price is 0, query the save data and respond accordingly.
            // There's only 3 dynamically priced items so we can just use a switch.
            switch (true)
            {
                case bool _ when Regex.IsMatch(CurrentSelectedShopItem.itemName, ".*Tummy.*"):
                    return collectibleData.treatsUpgradeLevel;
                case bool _ when Regex.IsMatch(CurrentSelectedShopItem.itemName, ".*Thrust.*"):
                    return collectibleData.thrustUpgradeLevel;
                case bool _ when Regex.IsMatch(CurrentSelectedShopItem.itemName, ".*Fuel.*"):
                    return collectibleData.fuelUpgradeLevel;
                default:
                    return -1; // an error has occurred.
            }
        }
        else
        {
            return CurrentSelectedShopItem.itemPrice;
        }
    }

    public int GetCurrentBoneBalance()
    {
        return collectibleData.BONES;
    }
}
