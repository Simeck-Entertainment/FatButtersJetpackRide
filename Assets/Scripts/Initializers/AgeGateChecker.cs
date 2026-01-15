using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using TMPro;

public class AgeGateChecker : InitializationCommonFunctions
{
    [SerializeField] GameObject[] AgeGateUiObjects;
    [SerializeField] TMP_Dropdown DayPicker;
    [SerializeField] TMP_Dropdown MonthPicker;
    [SerializeField] TMP_Dropdown YearPicker;
    [SerializeField] GameObject logo;
    UnityEngine.UI.Image logoImg;
    public List<string> YearOptions = new List<string>();
    bool ReadyToGo;
    int ReadyToGoThreshold = 30;
    int readyToGoCounter;
    [SerializeField] UnityEngine.UI.Image darkener;

    private UserInfo userInfo => SaveManager.Instance.userInfo;
    private SceneLoadData sceneLoadData => SaveManager.Instance.sceneLoadData;

    // Start is called before the first frame update
    void Start()
    {
        logoImg = logo.GetComponent<UnityEngine.UI.Image>();
        ReadyToGo = false;
        readyToGoCounter = 0;
        CreateYearOptions();

        if(userInfo.AgeGateQuestionAnswered){
            ensureCorrectStatus();
            return;
        } else {
            darkener.gameObject.SetActive(true);
            logo.SetActive(false);
            foreach (GameObject obj in AgeGateUiObjects)
            {
                obj.SetActive(true);
            }
        }
    }

    void Update() {
        if(userInfo.AgeGateQuestionAnswered)
        {
            ReadyToGo = true;
        }

        if(ReadyToGo)
        {
            readyToGoCounter++;
        }

        if(readyToGoCounter <= ReadyToGoThreshold)
        {
            darkener.color = new Color(0,0,0,Helper.RemapArbitraryValues(0f,1f,0f,0.8f,(ReadyToGoThreshold-readyToGoCounter)/ReadyToGoThreshold));
            logoImg.color = new Color(1f,1f,1f,(ReadyToGoThreshold-readyToGoCounter)/ReadyToGoThreshold);
        }
        else
        {
            sceneLoadData.SceneToLoad = Levels.TitleScreen;
            sceneLoadData.LastLoadedLevelInt = 0;
            sceneLoadData.LastLoadedLevel = "";
            SaveManager.Instance.Save();
            SceneManager.LoadScene(Levels.SceneLoader);
        }
    }

    void ensureCorrectStatus()
    {
        //start with the year
        if(!userInfo.isOldEnoughForAds)
        {
            if(userInfo.yearBorn < DateTime.Now.Year-13) //if year older
            {
                userInfo.isOldEnoughForAds = true;
                SaveManager.Instance.Save();
                return;
            }
            else if (userInfo.yearBorn == DateTime.Now.Year-13) //if at year threshold
            {
                if(userInfo.monthBorn < DateTime.Now.Month) //if month older
                {
                    userInfo.isOldEnoughForAds = true;
                    SaveManager.Instance.Save();
                    return;
                }
                else if (userInfo.monthBorn == DateTime.Now.Month) //if at month threshold
                {
                    if(userInfo.dayBorn <= DateTime.Now.Day) //if day older or at day threshold
                    {
                        userInfo.isOldEnoughForAds = true;
                        SaveManager.Instance.Save(); 
                    }
                    else //if day younger
                    {
                        return;
                    }
                }
                else //if month younger
                {
                    return;
                }
            }
            else //if year younger
            {
                return;
            }
        }
    }

    private void CreateYearOptions()
    {
        YearPicker.ClearOptions();
        YearOptions.Add("Year");
        for (int i = 0; i < 100; i++)
        {
            YearOptions.Add((DateTime.Now.Year - i).ToString());
        }
        YearPicker.AddOptions(options: YearOptions);
    }

    public void writeAgeValues()
    {
        userInfo.monthBorn = MonthPicker.value;
        userInfo.dayBorn = DayPicker.value;
        userInfo.yearBorn = int.Parse(YearPicker.options[YearPicker.value].text);
        SaveManager.Instance.Save();
    }

    public void isOldEnoughForAds()
    {
        userInfo.isOldEnoughForAds = true;
        userInfo.AgeGateQuestionAnswered = true;
        SaveManager.Instance.Save();
    }

    public void notOldEnoughForAds()
    {
        userInfo.isOldEnoughForAds = false;
        userInfo.AgeGateQuestionAnswered = true;
        SaveManager.Instance.Save();
    }

    public void submissionChecker()
    {
        int yearInt;
        yearInt = int.Parse(YearPicker.options[YearPicker.value].text);

        if(yearInt > DateTime.Now.Year - 13) //if year younger
        {
            writeAgeValues();
            notOldEnoughForAds();
            return;
        }
        else if ( YearPicker.value == 13) //if same year
        {
            if(MonthPicker.value > DateTime.Now.Month) //if month younger
            {
                writeAgeValues();
                notOldEnoughForAds();
                return;
            }
            else if( MonthPicker.value == DateTime.Now.Month) //if same month
            {
                if(DayPicker.value > DateTime.Now.Day) //if day younger
                {
                    writeAgeValues();
                    notOldEnoughForAds();
                    return;
                }
                else //if day older or same as threshold
                {
                    writeAgeValues();
                    isOldEnoughForAds();
                    return;
                }
            }
            else //if month older
            {
                writeAgeValues();
                isOldEnoughForAds();
                return;
            }
        }
        else //if year older
        {
            writeAgeValues();
            isOldEnoughForAds();
            return;
        }
    }
}
