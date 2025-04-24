using System.Collections;
using UnityEngine;

public class DisableBurguerHub : MonoBehaviour
{
    public GameObject canvas;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(comprobeHub());
    }

    private IEnumerator comprobeHub()
    {
        while (true) {
            if (Time.timeScale == 0)
            {
                canvas.SetActive(false);
                yield return new WaitForSeconds(0.1f);
            }
            else
            {
                canvas.SetActive(true);
            }

            yield return new WaitForSecondsRealtime(0.1f);
        }
    }
}
