using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class OvejaLoading : MonoBehaviour
{
    public RectTransform[] images;
    public float jumpHeight = 30f;
    public float duration = 0.3f;
    public float delayBetween = 0.1f;

    void Start()
    {
        StartCoroutine(AnimateImages());
    }

    IEnumerator AnimateImages()
    {
        while (true)
        {
            foreach (RectTransform img in images)
            {
                Vector3 originalPos = img.localPosition;
                Vector3 targetPos = originalPos + Vector3.up * jumpHeight;

                yield return StartCoroutine(MoveOverTime(img, originalPos, targetPos, duration / 2f));

                yield return StartCoroutine(MoveOverTime(img, targetPos, originalPos, duration / 2f));

                yield return new WaitForSeconds(delayBetween);
            }
        }
    }

    IEnumerator MoveOverTime(RectTransform rect, Vector3 from, Vector3 to, float time)
    {
        float elapsed = 0f;
        while (elapsed < time)
        {
            rect.localPosition = Vector3.Lerp(from, to, elapsed / time);
            elapsed += Time.deltaTime;
            yield return null;
        }
        rect.localPosition = to;
    }
}
