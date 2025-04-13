using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FallController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI stateTMP;
    [SerializeField] private Slider scoreSlider;

    private int finalScore=0;
    private int score = 0;

    public bool tableTouched = false;


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
            StartCoroutine(ShowText("Fail"));
            tableTouched = false;
        }
        else
        {
            finalScore++;
            Transform priorIngredient = other.transform.parent.GetChild(other.transform.GetSiblingIndex() - 1);

            if(Math.Abs(priorIngredient.position.x - other.transform.position.x) < 0.05f)
            {
                Debug.Log("Perfect");
                StartCoroutine(ShowText("Perfect!"));
                UpdateScore(2);
            }
            else
            {
                Debug.Log("Good");
                StartCoroutine(ShowText("Good"));
                UpdateScore(1);
            }
        }
        
        GameObject.Find("Generator").gameObject.GetComponent<BurguerController>().NextIngredient();
    }


    private void UpdateScore(int pointsToAdd)
    {
        score += pointsToAdd;
        scoreSlider.value = score;
    }

    IEnumerator ShowText(string text)
    {
        stateTMP.enabled = true;
        stateTMP.text = text;
        yield return new WaitForSeconds(0.7f);
        stateTMP.enabled = false;
    }
}
