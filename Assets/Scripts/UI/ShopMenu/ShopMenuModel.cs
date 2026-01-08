using System.Text.RegularExpressions;
using UnityEngine;
using System.Linq;
using System;

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
        if (!CurrentSelectedShopItem.isSkin)
        {
            return false;
        }

        return collectibleData.HaveSkins[CurrentSelectedShopItem.SkinId];
    }

    public bool IsActiveSkinEquipped()
    {
        if (!CurrentSelectedShopItem.isSkin)
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
            // TODO Drake: This is fragile, consider adding an "ItemType" enum to the ShopItem

            // If the price is 0, query the save data and respond accordingly.
            // There's only 3 dynamically priced items so we can just use a switch.
            if (Regex.IsMatch(CurrentSelectedShopItem.itemName, ".*Tummy.*"))
            {
                return collectibleData.treatsUpgradeLevel;
            }
            else if (Regex.IsMatch(CurrentSelectedShopItem.itemName, ".*Thrust.*"))
            {
                return collectibleData.thrustUpgradeLevel;
            }
            else if (Regex.IsMatch(CurrentSelectedShopItem.itemName, ".*Fuel.*"))
            {
                return collectibleData.fuelUpgradeLevel;
            }
            else
            {
                throw new ArgumentException($"Shop item: {CurrentSelectedShopItem.itemName} has an invalid price of 0!");
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
