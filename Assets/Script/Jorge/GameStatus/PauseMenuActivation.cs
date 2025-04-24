using System.Collections;
using UnityEngine;

public class PauseMenuActivation : MonoBehaviour
{

    public PauseMenuScript pauseMenu;

    private void Start()
    {
        StartCoroutine(soundEnable());
    }


    private IEnumerator soundEnable()
    {
        while (true) {

            if (Time.timeScale == 0)
            {
                AudioSource[] audios = GameObject.FindObjectsOfType<AudioSource>();
                foreach(AudioSource audio in audios)
                {
                    audio.Pause();
                }
               yield return new WaitForSeconds(0.1f);
            }
            else
            {
                AudioSource[] audios = GameObject.FindObjectsOfType<AudioSource>();
                foreach (AudioSource audio in audios)
                {
                    audio.UnPause();
                }
            }
            yield return new WaitForSecondsRealtime(0.1f);


        }

     


    }

    private void OnPauseMenu()
    {
        if(!TutorialGestions.isTutorialGestionEnable)
        pauseMenu.upMenu();
    }
}
