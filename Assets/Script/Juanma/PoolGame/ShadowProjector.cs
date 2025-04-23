using UnityEngine;

public class ShadowProjector : MonoBehaviour
{
    public Transform target;
    public LayerMask groundLayer;
    public float maxDistance = 100f;

    void Update()
    {
        if(Time.timeScale == 0)
        {
            return;
        }
        if (target == null) return;

        Ray ray = new Ray(target.position, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, groundLayer))
        {
            transform.position = hit.point + Vector3.up * 0.05f;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
