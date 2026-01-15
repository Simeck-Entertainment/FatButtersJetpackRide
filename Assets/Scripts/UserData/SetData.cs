using UnityEngine;
using TMPro;

public class SetData : MainMenuCommonData
{
    [SerializeField] TMP_InputField codeEntry;
    [SerializeField] TMP_Text codeFailText;
    //This is a set of dev cheats so that I can get around easily and prototype stuff.
    //during production I will change these to unlock stuff with (very) long codes.

    private CollectibleData collectibleData => SaveManager.Instance.collectibleData;

    public void codefail()
    {
        codeEntry.text = "";
        codeFailText.gameObject.SetActive(true);
    }

    public void Test()
    {
        Debug.Log("Derp");
    }

    public void DevBones()
    {
        collectibleData.BONES = 999;
        Save();
    }

    public void DevFuel()
    {
        collectibleData.fuelUpgradeLevel = 999;
        Save();
    }

    public void DevThrust()
    {
        collectibleData.thrustUpgradeLevel = 50;
        Save();
    }

    public void DevKillAds()
    {
        collectibleData.killAds = true;
        Save();
    }

    public void DevBall()
    {
        collectibleData.HASBALL = true;
        Save();
    }

    public void DevSkin1()
    {
        collectibleData.HaveSkins[1] = true;
        Save();
    }

    public void DevSkin2()
    {
        collectibleData.HaveSkins[2] = true;
        Save();
    }

    public void DevSkin3()
    {
        collectibleData.HaveSkins[3] = true;
        Save();
    }

    public void DevSkin4()
    {
        collectibleData.HaveSkins[4] = true;
        Save();
    }

    public void DevSkin5()
    {
        collectibleData.HaveSkins[5] = true;
        Save();
    }

    public void DevSkin6()
    {
        collectibleData.HaveSkins[6] = true;
        Save();
    }

    public void DevIDKFA()
    {
        SaveManager.Instance.CreateCompletedSave();
    }

    public void DevLevels()
    {
        for(int i=0;i<=21;i++){
            collectibleData.LevelBeaten[i] = true;
        }
        Save();
    }

    void Save()
    {
        SaveManager.Instance.Save();
    }
}
