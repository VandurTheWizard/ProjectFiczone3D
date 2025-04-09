using UnityEngine;
using System.Collections.Generic;

public class PeopleSpawner : MonoBehaviour
{
    public GameObject personPrefab;
    public int personCount = 10;
    public Vector2 areaSize = new Vector2(10f, 10f);
    public float minDistance = 1.5f;

    private List<Vector3> usedPositions = new List<Vector3>();

    void Start()
    {
        SpawnPeople();
    }

    void SpawnPeople()
    {
        int attempts = 0;

        for (int i = 0; i < personCount; i++)
        {
            bool placed = false;

            while (!placed && attempts < 1000)
            {
                attempts++;

                Vector3 randomPos = transform.position + new Vector3(
                    Random.Range(-areaSize.x / 2f, areaSize.x / 2f),
                    0f,
                    Random.Range(-areaSize.y / 2f, areaSize.y / 2f)
                );

                if (IsFarEnough(randomPos))
                {
                    Instantiate(personPrefab, randomPos, Quaternion.identity);
                    usedPositions.Add(randomPos);
                    placed = true;
                }
            }
        }
    }

    bool IsFarEnough(Vector3 newPos)
    {
        foreach (var pos in usedPositions)
        {
            if (Vector3.Distance(pos, newPos) < minDistance)
                return false;
        }
        return true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, new Vector3(areaSize.x, 0.1f, areaSize.y));
    }
}
