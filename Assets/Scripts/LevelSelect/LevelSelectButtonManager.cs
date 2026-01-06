using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using NUnit.Framework;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using System.Collections.Generic;
public class LevelSelectButtonManager : MonoBehaviour
{
    [SerializeField] CollectibleData collectibleData;
    [SerializeField] UserInfo userInfo;
    [SerializeField] SaveManager saveManager;
    [SerializeField] LevelSelectScroller levelSelectScroller;
    [SerializeField] GameObject MainMenuButton;
    [SerializeField] Scrollbar scrollbar;

    #region ShopVars
    [Header("Shop menu stuff")]
    [SerializeField] Sprite treatsOpen;
    [SerializeField] Sprite treatsClosed;
    [SerializeField] Image treatsImgSlot;
    [SerializeField] public int CurrentSelectedShopItem;
    [SerializeField] TMP_Text itemName;
    [SerializeField] TMP_Text itemCost;
    [SerializeField] Image itemImg;
    [SerializeField] Image JetpackImg;
    [SerializeField] Image DoghouseButtersImg;
    [SerializeField] public ShopItem[] shopItems;
    [SerializeField] public Sprite cantGetRead;
    [SerializeField] Button BuyButton;
    [SerializeField] Button SetSkinButton;
    [SerializeField] AudioClip[] barks;
    #endregion

    void Start()
    {
        saveManager.EnsureSaveFileExists();
        //Set the settings menu for all the settings options that need it...
        SetSettings();
    }

    #region SettingsMethods
    void SetSettings() // TODO Drake: Delete after updating the shop menu
    {
        saveManager.Load();
        //shop stuff
        SetAllShopText();
        saveManager.Save();
    }

    private void SetAllShopText()
    {
        itemName.text = GetCurrentItemName();
        SetCurrentItemCostText(GetCurrentItemCost());
        itemImg.sprite = GetCurrentItemImg();
        JetpackImg.sprite = GetCurrentJetpackImg();
        if (CurrentSelectedShopItem < 3)
        {
            DoghouseButtersImg.sprite = shopItems[collectibleData.CurrentSkin + 3].dogHouseButtersImg;
            return;
        }
        //if (!DoWeOwnThisSkin()) { return; } //You know what? Let them see the skins in their full glory.
        if (GetCurrentDoghouseImg() != null)
        {
            DoghouseButtersImg.sprite = GetCurrentDoghouseImg();
        }
        else
        {
            DoghouseButtersImg.sprite = cantGetRead;
        }
    }

    bool DoWeOwnThisSkin()
    {
        return collectibleData.HaveSkins[CurrentSelectedShopItem - 3];
    }

    #endregion
    #region ShopMethods

    public void ToggleTreatsHolder()
    {
        if (treatsImgSlot.sprite == treatsOpen)
        {
            treatsImgSlot.sprite = treatsClosed;
        }
        else
        {
            treatsImgSlot.sprite = treatsOpen;
        }
    }
    string GetCurrentItemName()
    {
        return shopItems[CurrentSelectedShopItem].itemName;
    }

    public int GetCurrentItemCost()
    {
        if (shopItems[CurrentSelectedShopItem].itemPrice == 0)
        { //If the price is 0, query the save data and respond accordingly.
          //There's only 3 dynamically priced items so we can just use a switch.
            switch (true)
            {
                case bool _ when Regex.IsMatch(shopItems[CurrentSelectedShopItem].itemName, ".*Tummy.*"):
                    return collectibleData.treatsUpgradeLevel;
                case bool _ when Regex.IsMatch(shopItems[CurrentSelectedShopItem].itemName, ".*Thrust.*"):
                    return collectibleData.thrustUpgradeLevel;
                case bool _ when Regex.IsMatch(shopItems[CurrentSelectedShopItem].itemName, ".*Fuel.*"):
                    return collectibleData.fuelUpgradeLevel;
                default:
                    return -1; //an error has occurred.
            }
        }
        else
        {
            return shopItems[CurrentSelectedShopItem].itemPrice;
        }
    }
    public void SetCurrentItemCostText(int amount)
    {
        if (amount == 0)
        {
            itemCost.text = "";
        }
        else
        {
            itemCost.text = amount.ToString() + "/" + collectibleData.BONES.ToString() + " Bones    ";
        }

    }
    Sprite GetCurrentItemImg()
    {
        return shopItems[CurrentSelectedShopItem].itemImg;
    }
    Sprite GetCurrentJetpackImg()
    {
        return shopItems[CurrentSelectedShopItem].JetpackImg;
    }

    Sprite GetCurrentDoghouseImg()
    {
        return shopItems[CurrentSelectedShopItem].dogHouseButtersImg;
    }
    public void BuyCurrentItem()
    {
        //Deferred to BuyScripts, but here for readability.
        GetComponent<BuyScripts>().RunBuy(CurrentSelectedShopItem);
    }

    public void SetCurrentSkin()
    {
        GetComponent<BuyScripts>().EnableCurrentSkin();
    }
    public void runRightShopButton()
    {
        CurrentSelectedShopItem++;
        if (CurrentSelectedShopItem >= shopItems.Length)
        {
            CurrentSelectedShopItem = 0;
        }
        SetAllShopText();
        EnsureCorrectBuyButton();
    }
    public void runLeftShopButton()
    {
        CurrentSelectedShopItem--;
        if (CurrentSelectedShopItem < 0)
        {
            CurrentSelectedShopItem = shopItems.Length - 1;
        }
        SetAllShopText();
        EnsureCorrectBuyButton();
    }
    public void EnsureCorrectBuyButton()
    { //This method uses a nested if statement. This bears looking at later and rethinking.
        if (CurrentSelectedShopItem < 3)
        {
            EnableBuyButton();
            return;
        }
        if (collectibleData.HaveSkins[shopItems[CurrentSelectedShopItem].SkinId] == true)
        { //if we have the skin...
            if (shopItems[CurrentSelectedShopItem].SkinId == collectibleData.CurrentSkin)
            { //And we have the skin equipped...
                EnableNoBuyOrSkinButton(); //kill the buttons.
            }
            else
            {
                EnableSetSkinButton(); //If we have the skin but it's unequipped, enable the equip button.
            }
        }
        else
        {
            EnableBuyButton(); //Otherwise enable the buy button.
        }
    }


    public void EnableBuyButton()
    {
        BuyButton.gameObject.SetActive(true);
        SetSkinButton.gameObject.SetActive(false);
    }
    public void EnableSetSkinButton()
    {
        BuyButton.gameObject.SetActive(false);
        SetSkinButton.gameObject.SetActive(true);
    }
    public void EnableNoBuyOrSkinButton()
    {
        BuyButton.gameObject.SetActive(false);
        SetSkinButton.gameObject.SetActive(false);
    }
    #endregion

    public void DoBark()
    {
        AudioClip thisBark = barks[UnityEngine.Random.Range(0, barks.Length - 1)];
        AudioSource sauce = DoghouseButtersImg.gameObject.GetComponent<AudioSource>();
        sauce.clip = thisBark;
        sauce.Play();

    }


}
