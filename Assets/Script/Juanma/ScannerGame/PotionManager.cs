using System.Collections.Generic;
using UnityEngine;

public class PotionManager : MonoBehaviour
{
    public List<GameObject> potionPrefabs;
    public Transform potionParent; // Empty donde instancias las pociones (por ejemplo el mismo donde estaba antes)
    private GameObject currentPotion;
    private DecalGenerator decalGen;

    private int currentIndex = 0;
    private int decalsHit = 0;
    public int decalsToNext = 5;

    void Start()
    {
        decalGen = GetComponent<DecalGenerator>();
        LoadPotion(currentIndex);
    }

    public void OnDecalHit()
    {
        decalsHit++;
        if (decalsHit >= decalsToNext)
        {
            decalsHit = 0;
            currentIndex = (currentIndex + 1) % potionPrefabs.Count;
            LoadPotion(currentIndex);
        }
    }

    private void LoadPotion(int index)
    {
        if (currentPotion != null)
            Destroy(currentPotion);

        currentPotion = Instantiate(potionPrefabs[index], potionParent);
        currentPotion.transform.localPosition = Vector3.zero;
        currentPotion.transform.localRotation = Quaternion.identity;
        Transform transformPotion = currentPotion.transform;
        decalGen.UpdateTarget(transformPotion);
    }
}
