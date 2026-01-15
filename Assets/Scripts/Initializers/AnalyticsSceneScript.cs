using UnityEngine;
using Unity.Services.Core;

public class AnalyticsSceneScript : InitializationCommonFunctions
{
    [SerializeField] GameObject[] AnalyticsConsentUiObjects;
    [SerializeField] GameObject Darkener;
    [SerializeField] GameObject logo;
    bool ReadyToGo;
    int ReadyToGoThreshold = 30;
    int readyToGoCounter;

    private UserInfo userInfo => SaveManager.Instance.userInfo;

    async void OnEnable()
    {
        await UnityServices.InitializeAsync();
    }

    void Start()
    {
        readyToGoCounter = 0;
        ReadyToGo = false;
        PrettyPictureToggle(userInfo.analyticsConsentAnswered);
    }

    // Update is called once per frame
    void Update()
    {
        if(userInfo.analyticsConsentAnswered){
           RunReadyToGo();
        }
    }

    public void AcceptDataCollection()
    {
        userInfo.analyticsConsentAnswered = true;
        userInfo.dataCollectionConsent = true;
        Debug.Log("Accept!");
        PrettyPictureToggle(true);
        SaveManager.Instance.Save();
    }

    public void DenyDataCollection()
    {
        userInfo.analyticsConsentAnswered = true;
        userInfo.dataCollectionConsent = false;
        Debug.Log("Decline!");
        PrettyPictureToggle(true);
        SaveManager.Instance.Save();
    }

    void RunReadyToGo()
    {
        readyToGoCounter++;
        if(readyToGoCounter >= ReadyToGoThreshold){
            Levels.Load(Levels.TitleScreen);
        }
    }

    void PrettyPictureToggle(bool whatDo)
    {
        //if it's already done...
        if(whatDo)
        {
            logo.SetActive(true);
            Darkener.SetActive(false);
            foreach(GameObject obj in AnalyticsConsentUiObjects)
            {
                obj.SetActive(false);
            }
        }
        else
        {
            //if it's not done...
            logo.SetActive(false);
            Darkener.SetActive(true);
            foreach(GameObject obj in AnalyticsConsentUiObjects)
            {
                obj.SetActive(true);
            } 
        }
    }
}
