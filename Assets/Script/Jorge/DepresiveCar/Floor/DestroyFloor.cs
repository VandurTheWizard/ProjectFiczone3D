using UnityEngine;

public class DestroyFloor : MonoBehaviour
{
    private int maxTime = 10;
    private float time = 0;

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time > maxTime)
        {
            Destroy(gameObject);
        }
    }
}
