using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Mathematics;

public class UIManager : MonoBehaviour
{
    [SerializeField] SaveManager saveManager;
    public GameObject playerObj;
    [SerializeField] Player player;
    [SerializeField] public TMP_Text bonesText;
    [SerializeField] Image fuelGuage;
    [SerializeField] Sprite[] FuelGuageColors;
    [Header("Pause menu Stuff")]
    [SerializeField] GameObject PauseButton;
    [SerializeField] GameObject PauseMenu;

    [Header("Failure Menu Stuff")]
    [SerializeField] public TMP_Text FailText;
    [SerializeField] public GameObject FailMenu;
    [SerializeField] public GameObject savedBonesText;
    [Header("Success Menu Stuff")]
    [SerializeField] public GameObject WinMenu;
    [SerializeField] public TMP_Text endLevelStats;

    [Header("Damage Indicator stuff")]
    [SerializeField] Renderer HurtIndicator;
    [SerializeField] public bool runningHurt;
    [SerializeField] public int hurtCounter = 0;
    int hurtCounterThreshold = 20;
    [SerializeField] GameObject GameplayIndicators;

    [SerializeField] private FailMenuModel failMenu;
    [SerializeField] private SuccessMenuModel successMenu;

    private UiState currentState;
    private int numNewBones;

    // Start is called before the first frame update
    void Start()
    {
        if (saveManager == null) {
            saveManager = Helper.NabSaveData().GetComponent<SaveManager>();
        }
        HurtIndicator.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SetUIIndicators();
    }
    public void ActivateHurt()
    {
        runningHurt = true;
    }
    public void SetUIIndicators()
    {
        fuelManager();
        bonesText.text = (player.saveManager.collectibleData.BONES + player.tempBones).ToString();
        if (runningHurt)
        {
            HurtIndicator.gameObject.SetActive(true);
            HurtRunner();
        }
    }
    public void SetEndLevelStats(int newbones)
    {
        numNewBones = newbones;

        endLevelStats.text = "You have found " + newbones + " new bones!"; // TODO Drake: remove this
    }
    public void HurtRunner() {
        hurtCounter++;
        Vector2 inTiling = Vector2.one;
        Vector2 outTiling = new Vector2(0.1f, 0.1f);
        Vector2 inOffset = Vector2.zero;
        Vector2 outOffset = new Vector2(0.5f, 0.5f);
        if (hurtCounter <= hurtCounterThreshold * 0.5f) {
            HurtIndicator.material.mainTextureScale = Vector2.Lerp(outTiling, inTiling, Helper.RemapToBetweenZeroAndOne(0.0f, hurtCounterThreshold * 0.5f, hurtCounter));
            HurtIndicator.material.mainTextureOffset = Vector2.Lerp(outOffset, inOffset, Helper.RemapToBetweenZeroAndOne(0.0f, hurtCounterThreshold * 0.5f, hurtCounter));
        } else if (hurtCounter > hurtCounterThreshold * 0.5f && hurtCounter < hurtCounterThreshold) {
            HurtIndicator.material.mainTextureScale = Vector2.Lerp(inTiling, outTiling, Helper.RemapToBetweenZeroAndOne(hurtCounterThreshold * 0.5f, hurtCounterThreshold, hurtCounter));
            HurtIndicator.material.mainTextureOffset = Vector2.Lerp(inOffset, outOffset, Helper.RemapToBetweenZeroAndOne(hurtCounterThreshold * 0.5f, hurtCounterThreshold, hurtCounter));
        } else {
            hurtCounter = 0;
            runningHurt = false;
            HurtIndicator.gameObject.SetActive(false);
        }
    }

    public void RunOneHitKill()
    {
        DisableGameplayIndicators(); // TODO: hideable view model based on currentState
        playerObj.gameObject.SetActive(false);

        currentState = UiState.Fail;
        FailMenu.SetActive(true); // TODO: hideable view model based on currentState
        failMenu.FailReason = FailReason.NoHealth;
    }

    public void RunNoFuel()
    {
        DisableGameplayIndicators(); // TODO: hideable view model based on currentState

        currentState = UiState.Fail;
        FailMenu.SetActive(true); // TODO: hideable view model based on currentState
        failMenu.FailReason = FailReason.NoFuel;
    }

    public void ActivateWinMenu()
    {
        DisableGameplayIndicators();
        WinMenu.SetActive(true);

        currentState = UiState.Success;
    }

    public void ActivateFailMenu()
    {
        DisableGameplayIndicators(); // TODO: hideable view model based on currentState
        FailMenu.SetActive(true);

        currentState = UiState.Fail;
    }
    public void PauseGame() {
        DisableGameplayIndicators();
        Time.timeScale = 0.0f;
    }
    public void UnpauseGame() {
        saveManager.Save();
        EnableGameplayIndicators();
        Time.timeScale = 1.0f;
    }

    public void EnableGameplayIndicators()
    {
        GameplayIndicators.SetActive(true);
    }
    public void DisableGameplayIndicators()
    {
        GameplayIndicators.SetActive(false);
    }

    #region buttonStuff
    public void FailToLevelSelect()
    {
        saveManager.collectibleData.BONES = saveManager.collectibleData.BONES + player.tempBones;
        saveManager.collectibleData.HASBALL = false;
        saveManager.Save();
        //UnpauseGame();
        Helper.LoadToLevel(Levels.LevelSelect);
    }
    public void PauseToLevelSelect() {
        saveManager.collectibleData.HASBALL = false;
        saveManager.Save();
        UnpauseGame();
        Helper.LoadToLevel(Levels.LevelSelect);
    }
    public void WinToLevelSelect() {
        saveManager.collectibleData.BONES = saveManager.collectibleData.BONES + player.tempBones;
        saveManager.collectibleData.HASBALL = false;
        saveManager.collectibleData.LevelBeaten[saveManager.sceneLoadData.LastLoadedLevelInt] = true;
        saveManager.Save();
        Helper.LoadToLevel(Levels.LevelSelect);

    }
    public void ActivatePauseMenu()
    {
        PauseButton.SetActive(false);
        PauseMenu.SetActive(true);
        PauseGame();

        currentState = UiState.Settings;
    }
    public void DeActivatePauseMenu()
    {
        PauseButton.SetActive(true);
        PauseMenu.SetActive(false);
        UnpauseGame();

        currentState = UiState.Base;
    }

    #endregion
    #region fuelStuff
    void fuelManager()
    {
        
        //fuelGuage.m_FillAmount = player.fuel/player.maxFuel;
        fuelGuage.fillAmount = player.fuel / player.maxFuel;
        if (fuelGuage.fillAmount > 0.5f)
        {
            fuelGuage.color = Color.Lerp(Color.white, Color.black, 0); // alpha PingPong.

            fuelGuage.sprite = FuelGuageColors[0];
        }
        if (fuelGuage.fillAmount <= 0.5f & fuelGuage.fillAmount > 0.25f)
        {
             fuelGuage.color = Color.Lerp(Color.white, Color.black, 0); // alpha PingPong.
            fuelGuage.sprite = FuelGuageColors[1];
        }
        if (fuelGuage.fillAmount <= 0.25f)
        {
            fuelGuage.sprite = FuelGuageColors[2];
            fuelGuage.color = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, .3f)); // alpha PingPong.

        }

    }
#endregion
}
