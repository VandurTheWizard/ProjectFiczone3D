using UnityEngine;

public class PauseMenuActivation : MonoBehaviour
{

    public PauseMenuScript pauseMenu;

    private void OnPauseMenu()
    {
        if(!TutorialGestions.isTutorialGestionEnable)
        pauseMenu.upMenu();
    }
}
