using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinManager : MonoBehaviour
{
    [SerializeField] private Image ovejaImage, pulgarImage, fondoImage;
    [SerializeField] private RawImage camaraImage;
    public RenderTexture camaraTextura;
    public Vector3 firstShowSheepPos;
    public Vector3 showSheepPos;
    public Vector3 hideSheepPos;
    public float widthHand = 300f;
    public float heightHand = 300f;

    void Start()
    {
        camaraTextura = new RenderTexture(Screen.width, Screen.height, 24);

        Camera camara = Camera.main;

        camara.targetTexture = camaraTextura;
    }

    private void ShowWinScreen()
    {
        ovejaImage.gameObject.SetActive(true);
        pulgarImage.gameObject.SetActive(true);
        fondoImage.gameObject.SetActive(true);
        if(camaraImage != null)
        {
            camaraImage.texture = camaraTextura;
        }
        else
        {
            Debug.LogError("RawImage camaraImage no está asignado en el inspector.");
        }
    }

    public void OnWin()
    {
        Debug.Log("Win!");
        ShowWinScreen();
    }

    IEnumerator AnimateSheep()
    {
        ovejaImage.rectTransform.position = firstShowSheepPos;
        float time = 0;
        float duration = 1f;

        while (time < duration)
        {
            ovejaImage.rectTransform.position = Vector3.Lerp(firstShowSheepPos, showSheepPos, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        ovejaImage.rectTransform.position = showSheepPos;

        yield return new WaitForSeconds(2f);

        time = 0;
        while (time < duration)
        {
            ovejaImage.rectTransform.position = Vector3.Lerp(showSheepPos, hideSheepPos, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        ovejaImage.rectTransform.position = hideSheepPos;
    }
}