using UnityEngine;

public class ColisionesNave : MonoBehaviour
{

    private GestionCorreYCoge gestionCorreYCoge;
    private MovimientoCorreYCoge movimientoCorreYCoge;

    void Start()
    {
        gestionCorreYCoge = FindFirstObjectByType<GestionCorreYCoge>();
        movimientoCorreYCoge = GetComponent<MovimientoCorreYCoge>();
    } 

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Trash"))
        {
            gestionCorreYCoge.PerderNivel();
            movimientoCorreYCoge.isLose = true;
        }
    }
}