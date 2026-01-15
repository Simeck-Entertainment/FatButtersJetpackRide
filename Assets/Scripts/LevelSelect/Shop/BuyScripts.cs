using UnityEngine;

public class BuyScripts : MonoBehaviour
{
    [SerializeField] private ShopMenuModel shopMenu;

    private CollectibleData collectibleData => SaveManager.Instance.collectibleData;

    public void EquipSkin(int skinId)
    {
        if (collectibleData.HaveSkins[skinId])
        {
            collectibleData.CurrentSkin = skinId;
            SaveManager.Instance.Save();
        }
    }

    public void BuySkin(int itemId, int price)
    {
        if(collectibleData.BONES < price) { return; }
        ReduceFunds(price);

        int skinNumber = itemId;
        collectibleData.HaveSkins[skinNumber] = true;
        SaveManager.Instance.Save();
    }

    public void UpgradeFuel(int price)
    {
        if(collectibleData.BONES < price) { return; }
        ReduceFunds(price);

        collectibleData.fuelUpgradeLevel++;
        SaveManager.Instance.Save();
    }

    public void UpgradeThrust(int price)
    {
        if(collectibleData.BONES < price) { return; }
        ReduceFunds(price);

        collectibleData.thrustUpgradeLevel++;
        SaveManager.Instance.Save();
    }

    public void UpgradeTummy(int price)
    {
        if(collectibleData.BONES < price) { return; }
        ReduceFunds(price);

        collectibleData.treatsUpgradeLevel++;
        SaveManager.Instance.Save();
    }

    public void ReduceFunds(int amount)
    {
        collectibleData.BONES -= amount;
    }
}
