using System.Collections.Generic;
using UnityEngine;

public class PotionManager : MonoBehaviour
{
    public List<GameObject> potionPrefabs;
    public Transform potionParent;
    private GameObject currentPotion;
    private DecalGenerator decalGen;

    void Start()
    {
        decalGen = FindAnyObjectByType<DecalGenerator>();
        int randomIndex = Random.Range(0, potionPrefabs.Count);
        LoadPotion(randomIndex);
    }

    private void LoadPotion(int index)
    {
        if (currentPotion != null)
            Destroy(currentPotion);

        currentPotion = Instantiate(potionPrefabs[index], potionParent);
        currentPotion.transform.localPosition = Vector3.zero;
        currentPotion.transform.localRotation = Quaternion.identity;
        
        Transform transformPotion = currentPotion.transform;
        decalGen.UpdateTarget(transformPotion.transform);
    }
}

