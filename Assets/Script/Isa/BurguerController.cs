using UnityEngine;

public class BurguerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private GameObject hamburguer;

    private Vector3 endPosition;

    private void Awake()
    {
        endPosition = new Vector3(1, transform.position.y, transform.position.z);
    }


    private void Update()
    {
        if (transform.position != endPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, movementSpeed * Time.deltaTime);
        }
        else
        {
            endPosition = new Vector3(endPosition.x * -1, endPosition.y, endPosition.z);
        }
    }

    private void OnJump()
    {       
        GameObject myChild= gameObject.transform.GetChild(0).gameObject;

        myChild.transform.SetParent(hamburguer.transform, true);
        myChild.GetComponent<Rigidbody>().linearVelocity =Vector3.zero;

        myChild.GetComponent<Rigidbody>().useGravity = true;
    }

}
