using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FallController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goodText,perfectText, failText;
    [SerializeField] private Slider scoreSlider;
    [SerializeField] private GameObject sliderIcon;

    [Header("Images")]
    [SerializeField] private Image burguerImage;
    [SerializeField] private Image imageFail1, imageFail2, imageFail3;
    [SerializeField] private GameObject containerFail1, containerFail2, containerFail3;

    private int score = 0;
    private int fails= 0;

    public bool tableTouched = false;

    private void Start()
    {
        sliderIcon.gameObject.SetActive(false);
        scoreSlider.gameObject.SetActive(false);

        goodText.enabled = false;
        perfectText.enabled = false;
        failText.enabled = false;
    }

    private void OnTriggerExit(Collider other)
    {

        StartCoroutine(WaitForTable(other));
    }

    IEnumerator WaitForTable(Collider other)
    {
        yield return new WaitForSeconds(0.6f);
        
        if (tableTouched)
        {
            Debug.Log("Tocaste mesa");
            StartCoroutine(ShowText(0));
            tableTouched = false;
        }
        else
        {
            Transform priorIngredient = other.transform.parent.GetChild(other.transform.GetSiblingIndex() - 1);

            if(Math.Abs(priorIngredient.position.x - other.transform.position.x) < 0.05f)
            {
                Debug.Log("Perfect");
                StartCoroutine(ShowText(2));
                UpdateScore(2);
            }
            else
            {
                Debug.Log("Good");
                StartCoroutine(ShowText(1));
                UpdateScore(1);
            }
        }
        
        GameObject.Find("Generator").gameObject.GetComponent<BurguerController>().NextIngredient();
    }


    private void UpdateScore(int pointsToAdd)
    {
        if (score == 0)
        {
            sliderIcon.gameObject.SetActive(true);
            scoreSlider.gameObject.SetActive(true);
        }

        score += pointsToAdd;
        scoreSlider.value = score;
        LevelManager.Instance.finalScore = score;
    }

    private int lastFailBurguer=-1, lastFailLevel=-1;
    private void CountFail()
    {
        int currentBurguer = LevelManager.Instance.currentBurguer;
        int currentLevel= LevelManager.Instance.currentLevelt;

        if (currentBurguer!=lastFailBurguer || currentLevel != lastFailLevel) //Its a different burguer
        {
            fails++;
            LevelManager.Instance.fails = fails;

            lastFailLevel = currentLevel;
            lastFailBurguer=currentBurguer;

            //Set burguer in fail
            switch (fails)
            {
                case 1:
                    containerFail1.SetActive(true);
                    imageFail1.sprite = burguerImage.sprite;
                    break;
                case 2:
                    containerFail2.SetActive(true);
                    imageFail2.sprite = burguerImage.sprite;
                    break;
                case 3:
                    containerFail3.SetActive(true);
                    imageFail3.sprite = burguerImage.sprite;
                    LevelManager.Instance.EndGame();
                    break;
            }
        }
    }
    IEnumerator ShowText(int score)
    {
        TextMeshProUGUI textShowed=failText;

        switch (score)
        {
            case 1:
                textShowed = goodText;
                break;
            case 2:
                textShowed = perfectText;
                break;
            case 0:
                CountFail();
                break;
        }

        textShowed.enabled = true;

        yield return new WaitForSeconds(0.7f);

        textShowed.enabled = false;
    }
}
