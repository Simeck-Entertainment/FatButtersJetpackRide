using UnityEngine;

public class BuyScripts : MonoBehaviour
{
    [SerializeField] private ShopMenuModel shopMenu;

    private SaveManager saveManager;

    private CollectibleData collectibleData => saveManager.collectibleData;

    private void Start()
    {
        saveManager = Helper.NabSaveData().GetComponent<SaveManager>();
        saveManager.Load();
    }

    public void RunBuy(int item)
    {
        switch(item){
            case 0: //Will always be fuel
                UpgradeFuel();
                break;
            case 1: //will always be thrust
                UpgradeThrust();
                break;

            case 2: //will always be tummy
                UpgradeTummy();
                break;
            default: //everything else
                BuyCurrentSkin();

                break;
        }
    }

    void BuyCurrentSkin()
    {
        int cost = shopMenu.CurrentSelectedShopItem.itemPrice;
        if(collectibleData.BONES < cost){return;}
        ReduceFunds(shopMenu.CurrentSelectedShopItem.itemPrice);
        int skinNumber = shopMenu.CurrentSelectedShopItem.SkinId;
        collectibleData.HaveSkins[skinNumber] = true;
        //lsbm.EnableSetSkinButton();
        saveManager.Save();
    }

    public void EnableCurrentSkin()
    {
        collectibleData.CurrentSkin = shopMenu.CurrentSelectedShopItem.SkinId;
        saveManager.Save();
        //lsbm.EnableNoBuyOrSkinButton();
    }

    public void UpgradeFuel()
    {
        if(collectibleData.BONES < collectibleData.fuelUpgradeLevel){return;}
        ReduceFunds(collectibleData.fuelUpgradeLevel);
        collectibleData.fuelUpgradeLevel++;
        saveManager.Save();
        //lsbm.SetCurrentItemCostText(collectibleData.fuelUpgradeLevel);
    }

    public void UpgradeThrust()
    {
        if(collectibleData.BONES < collectibleData.thrustUpgradeLevel){return;}
        ReduceFunds(collectibleData.thrustUpgradeLevel);
        collectibleData.thrustUpgradeLevel++;
        saveManager.Save();
        //lsbm.SetCurrentItemCostText(collectibleData.thrustUpgradeLevel);
    }

    public void UpgradeTummy()
    {
        if(collectibleData.BONES < collectibleData.treatsUpgradeLevel){return;}
        ReduceFunds(collectibleData.treatsUpgradeLevel);
        collectibleData.treatsUpgradeLevel++;
        saveManager.Save();
        //lsbm.SetCurrentItemCostText(collectibleData.treatsUpgradeLevel);
    }

    public void ReduceFunds(int amount)
    {
        collectibleData.BONES -= amount;
    }
}
