using UnityEngine;

public class FireDugeonFloorDestruction : MonoBehaviour
{

    float time = 0;
    int maxTime = 7;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > maxTime)
        {
            Destroy(gameObject);
        }
    }
}
