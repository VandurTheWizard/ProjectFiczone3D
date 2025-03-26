using TMPro;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    private int carPosition = -30;
    private int floorPosition = 25;

    public GameObject floor;
    public GameObject enemiesCar;
    
    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > carPosition)
        {
           
            Instantiate(floor, new Vector3(0, 0, floorPosition), Quaternion.identity);
            if(Random.Range(0, 2) == 0)
            {
                Instantiate(enemiesCar, new Vector3(enemiesCar.transform.position.x, enemiesCar.transform.position.y, enemiesCar.transform.position.z + floorPosition), enemiesCar.transform.rotation);
            }
            else
            {
                Instantiate(enemiesCar, new Vector3(enemiesCar.transform.position.x - 1, enemiesCar.transform.position.y, enemiesCar.transform.position.z + floorPosition), enemiesCar.transform.rotation);
            }
           
            carPosition += 5;
            floorPosition += 5;
        }
    }
}
