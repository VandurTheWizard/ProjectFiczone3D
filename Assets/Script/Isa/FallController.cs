using System;
using System.Collections;
using UnityEngine;

public class FallController : MonoBehaviour
{
    private int finalScore=0;
    private int score;

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
            tableTouched = false;
        }
        else
        {
            finalScore++;
            Transform priorIngredient = other.transform.parent.GetChild(other.transform.GetSiblingIndex() - 1);

            if(Math.Abs(priorIngredient.position.x - other.transform.position.x) < 0.05f)
            {
                Debug.Log("Perfect");
                score += 2;
            }
            else
            {
                Debug.Log("Good");
                score++;
            }
        }
        GameObject.Find("Generator").gameObject.GetComponent<BurguerController>().NextIngredient();
    }
}
