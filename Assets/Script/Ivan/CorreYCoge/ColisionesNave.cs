using UnityEngine;

public class ColisionesNave : MonoBehaviour
{

    private GestionCorreYCoge gestionCorreYCoge;

    void Start()
    {
        gestionCorreYCoge = FindFirstObjectByType<GestionCorreYCoge>();
    } 

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            gestionCorreYCoge.PerderNivel();
            Destroy(gameObject);
        }
    }
}
