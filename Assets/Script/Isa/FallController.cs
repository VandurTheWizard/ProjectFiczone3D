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

    private int score = 0;

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
        }

        textShowed.enabled = true;

        yield return new WaitForSeconds(0.7f);

        textShowed.enabled = false;
    }
}
