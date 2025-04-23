using TMPro;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    private int carPosition = -30;
    private int floorPosition = 25;

    public GameObject floor;
    public GameObject enemiesCar;

    private float time = 0;
    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        time += Time.deltaTime /Time.timeScale;
        if (transform.position.z > carPosition)
        {
           
            Instantiate(floor, new Vector3(0, 0, floorPosition), Quaternion.identity);
            if (time > 1)
            {
                if (Random.Range(0, 2) == 0)
                {
                    Instantiate(enemiesCar, new Vector3(enemiesCar.transform.position.x, enemiesCar.transform.position.y, enemiesCar.transform.position.z + floorPosition), enemiesCar.transform.rotation);
                }
                else
                {
                    Instantiate(enemiesCar, new Vector3(enemiesCar.transform.position.x - 1, enemiesCar.transform.position.y, enemiesCar.transform.position.z + floorPosition), enemiesCar.transform.rotation);
                }
            }

           
            carPosition += 5;
            floorPosition += 5;
        }
    }
}
