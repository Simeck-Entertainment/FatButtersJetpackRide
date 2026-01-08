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
    public ShopItem CurrentEquippedShopItem => shopItems.First(x => x.Type == ShopItemType.Skin && x.SkinId == collectibleData.CurrentSkin);

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
        if (CurrentSelectedShopItem.Type != ShopItemType.Skin)
        {
            return false;
        }

        return collectibleData.HaveSkins[CurrentSelectedShopItem.SkinId];
    }

    public bool IsActiveSkinEquipped()
    {
        if (CurrentSelectedShopItem.Type != ShopItemType.Skin)
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
        switch (CurrentSelectedShopItem.Type)
        {
            case ShopItemType.Fuel:
                return collectibleData.fuelUpgradeLevel;
            case ShopItemType.Thrust:
                return collectibleData.thrustUpgradeLevel;
            case ShopItemType.Tummy:
                return collectibleData.treatsUpgradeLevel;
            default:
                return CurrentSelectedShopItem.itemPrice;
        }
    }

    public int GetCurrentBoneBalance()
    {
        return collectibleData.BONES;
    }
}
