using UnityEngine;

public class TableToucher : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("Generator").gameObject.GetComponent<BurguerController>().NextIngredient();
    }
}
