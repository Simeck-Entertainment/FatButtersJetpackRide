using UnityEngine;

public class MainMenuCommonData : MonoBehaviour
{
    [Header("Common Main Menu Data")]
    [SerializeField] public MainMenuCameraMover mainMenuCameraMover;

    public void BackButton()
    {
        mainMenuCameraMover.MoveTo(mainMenuCameraMover.MainMenu);
    }
}
