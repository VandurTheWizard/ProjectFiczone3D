using UnityEngine;

public class FireDugeonFloorDestruction : MonoBehaviour
{

    float time = 0;
    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        time += Time.deltaTime / Time.timeScale;


        if (time > FireDugeonGameGestion.timePlay)
        {
            Destroy(gameObject);
        }
    }
}
