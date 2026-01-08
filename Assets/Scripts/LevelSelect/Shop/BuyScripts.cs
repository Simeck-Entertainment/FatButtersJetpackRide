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

    public void EquipSkin(int skinId)
    {
        if (collectibleData.HaveSkins[skinId])
        {
            collectibleData.CurrentSkin = skinId;
            saveManager.Save();
        }
    }

    public void BuySkin(int itemId, int price)
    {
        if(collectibleData.BONES < price) { return; }
        ReduceFunds(price);

        int skinNumber = itemId;
        collectibleData.HaveSkins[skinNumber] = true;
        //lsbm.EnableSetSkinButton();
        saveManager.Save();
    }

    public void UpgradeFuel(int price)
    {
        if(collectibleData.BONES < price) { return; }
        ReduceFunds(price);

        collectibleData.fuelUpgradeLevel++;
        saveManager.Save();
        //lsbm.SetCurrentItemCostText(collectibleData.fuelUpgradeLevel);
    }

    public void UpgradeThrust(int price)
    {
        if(collectibleData.BONES < price) { return; }
        ReduceFunds(price);

        collectibleData.thrustUpgradeLevel++;
        saveManager.Save();
        //lsbm.SetCurrentItemCostText(collectibleData.thrustUpgradeLevel);
    }

    public void UpgradeTummy(int price)
    {
        if(collectibleData.BONES < price) { return; }
        ReduceFunds(price);

        collectibleData.treatsUpgradeLevel++;
        saveManager.Save();
        //lsbm.SetCurrentItemCostText(collectibleData.treatsUpgradeLevel);
    }

    public void ReduceFunds(int amount)
    {
        collectibleData.BONES -= amount;
    }
}
