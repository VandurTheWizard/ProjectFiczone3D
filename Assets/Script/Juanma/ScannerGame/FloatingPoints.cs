using UnityEngine;
using TMPro;

public class FloatingPoints : MonoBehaviour
{
    public float riseSpeed = 50f;
    public float fadeSpeed = 2f;
    private TextMeshProUGUI text;
    private CanvasGroup canvasGroup;

    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        canvasGroup = GetComponent<CanvasGroup>();
        Destroy(gameObject, 0.5f);
    }

    void Update()
    {
        transform.Translate(Vector3.up * riseSpeed * Time.deltaTime);
        canvasGroup.alpha -= fadeSpeed * Time.deltaTime;
    }
}
