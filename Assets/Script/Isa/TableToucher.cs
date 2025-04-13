using UnityEngine;

public class TableToucher : MonoBehaviour
{
    public GameObject fallGO;
    private void OnCollisionEnter(Collision collision)
    {
        //Something touched the table

        //decir a fallcontroller que tocaron la mesa
        fallGO.gameObject.GetComponent<FallController>().tableTouched = true;
        //GameObject.Find("Generator").gameObject.GetComponent<BurguerController>().NextIngredient();
    }


}
