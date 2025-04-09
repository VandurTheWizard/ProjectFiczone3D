using Unity.Mathematics;
using UnityEngine;

public class TrashMove : MonoBehaviour
{
    public Vector3 [] movePoints;
    public float speed = 1f;
    public float waitTime = 1f;

    // Variable para ajustar la rotacion del objeto
    public quaternion rotationOffset = quaternion.EulerXYZ(0, 0, 0);

    private float waitTimer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(waitTimer >= waitTime)
        {
            MoveToNextPoint();
            RotationToFoward();
        }
        else
        {
            waitTimer += Time.deltaTime;
        }
    }

    private void MoveToNextPoint()
    {
        if(movePoints.Length == 0) return;

        Vector3 targetPosition = movePoints[0];
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            waitTimer = 0f;
            System.Array.Copy(movePoints, 1, movePoints, 0, movePoints.Length - 1);
            movePoints[movePoints.Length - 1] = targetPosition;
        }
    }

    private void RotationToFoward()
    {
        if (movePoints.Length == 0) return;

        Vector3 targetPosition = movePoints[0];
        Vector3 direction = (targetPosition - transform.position).normalized;

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        targetRotation *= Quaternion.Euler(rotationOffset.value.x, rotationOffset.value.y, rotationOffset.value.z);

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
    }
}
