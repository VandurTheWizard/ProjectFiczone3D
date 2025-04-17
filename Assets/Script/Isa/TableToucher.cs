using UnityEngine;

public class TableToucher : MonoBehaviour
{
    public GameObject fallGO;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.transform.name);

            fallGO.GetComponent<FallController>().tableTouched = true;
    }
    /*private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.transform.name);

        if (!collision.gameObject.CompareTag("Plate"))
        {
            fallGO.GetComponent<FallController>().tableTouched = true;
        }
    }*/


}
