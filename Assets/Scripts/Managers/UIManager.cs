using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] SaveManager saveManager;
    public GameObject playerObj;
    [SerializeField] Player player;
    [SerializeField] public TMP_Text bonesText;
    [SerializeField] Image fuelGuage;
    [SerializeField] Sprite[] FuelGuageColors;

    [Header("Damage Indicator stuff")]
    [SerializeField] Renderer HurtIndicator;
    [SerializeField] public bool runningHurt;
    [SerializeField] public int hurtCounter = 0;
    int hurtCounterThreshold = 20;
    [SerializeField] GameObject GameplayIndicators;

    [SerializeField] private GameplayUIModel gameplayUI;
    [SerializeField] private FailMenuModel failMenu;
    [SerializeField] private SuccessMenuModel successMenu;

    public FailReason FailReason { get; set; }

    private GameplayUIState CurrentState
    {
        get 
        {
            return gameplayUI.UIState;
        }
        set
        {
            gameplayUI.UIState = value;
        }
    }

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

    public void SetUIIndicators() // TODO Drake: figure out how to make a view model for this
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
        successMenu.NewBones = newbones;
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

    public void ActivateWinMenu()
    {
        CurrentState = GameplayUIState.Success;
    }

    public void ActivateFailMenu()
    {
        failMenu.FailReason = FailReason;
        CurrentState = GameplayUIState.Fail;
    }

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
