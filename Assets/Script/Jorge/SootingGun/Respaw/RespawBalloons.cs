using UnityEngine;

public class RespawBalloons : MonoBehaviour
{
    public Transform[] positionsOfBalloons;
    public GameObject balloon;

    public int minY = 0;
    public int maxY = 0;

    public ShootingGunController gunController;

    private int[] positions;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        positions = new int[Random.Range(2, 5)];
        gunController.balloonHasBeenDestroy = positions.Length;

        createBalloon();

        for (int i = 0; i < positions.Length; i++)
        {
            Vector3 vector = new Vector3(positionsOfBalloons[positions[i]].position.x,Random.Range(minY, maxY+1), positionsOfBalloons[positions[i]].position.z);
            Instantiate(balloon, vector, Quaternion.identity);
        }

        Destroy(this);
    }


    public void createBalloon()
    {
        int x = 0;

        for (int i = 0; i < positions.Length; i++)
        {
            positions[i] = -1;
        }

        while (x < positions.Length)
        {
            int y = Random.Range(0, positionsOfBalloons.Length);
            for (int i = 0; i < positions.Length; i++)
            {
                if (positions[i] == -1)
                {
                    positions[i] = y;
                    x++;
                    break;
                }
                if (positions[i] == y)
                {
                    break;
                }

            }

        }
    }
}
