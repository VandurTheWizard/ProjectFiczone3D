using UnityEngine;

public class LaserSpawner : MonoBehaviour
{
    public GameObject laserPrefab;
    public int laserCount = 5;
    public float minY = -150f;
    public float maxY = 150f;
    public float minSpacing = 2.5f;

    public bool autoCalculateHeight = false; // Activar en modo infinito
    public bool isParent = true;

    private static float lastMinY = -150f;
    private static float lastMaxY = 150f;

    void Start()
    {
        if (autoCalculateHeight && !isParent)
        {
            minY = lastMinY - 300f;
            maxY = lastMaxY - 300f;

            lastMinY = minY;
            lastMaxY = maxY;
        }

        SpawnAllLasers();
    }

    public void SpawnAllLasers()
    {
        float[] usedHeights = new float[laserCount];

        for (int i = 0; i < laserCount; i++)
        {
            float newY;
            int attempts = 0;
            do
            {
                newY = Random.Range(minY, maxY);
                attempts++;
            }
            while (!IsHeightValid(newY, usedHeights) && attempts < 10);

            usedHeights[i] = newY;

            Vector3 spawnPos = new Vector3(0, newY, 0);
            Quaternion rotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 90f);

            GameObject laser = Instantiate(laserPrefab, spawnPos, rotation);
            laser.transform.SetParent(transform);
        }
    }

    bool IsHeightValid(float y, float[] existing)
    {
        foreach (float value in existing)
        {
            if (Mathf.Abs(y - value) < minSpacing)
                return false;
        }
        return true;
    }
}
