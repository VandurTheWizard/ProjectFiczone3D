using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Stopid : MonoBehaviour
{
    public GameObject textMesh;
    public GameObject imagen;
    public GameObject text2;

    private void Start()
    {
        StartCoroutine(canvasDisable());
    }

    private IEnumerator canvasDisable()
    {
    while (true)
    {
        if (Time.timeScale == 0)
        {
            textMesh.SetActive(false);
            imagen.SetActive(false);
            text2.SetActive(false);
            yield return new WaitForSeconds(0.1f);
        }
        else
        {
            textMesh.SetActive(true);
            imagen.SetActive(true);
            text2.SetActive(true);
        }
        yield return new WaitForSecondsRealtime(0.1f);
    }

    }
}
