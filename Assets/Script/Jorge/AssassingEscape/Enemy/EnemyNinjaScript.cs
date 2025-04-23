using System.Collections;
using UnityEngine;

public class EnemyNinjaScript : MonoBehaviour
{
    private bool isDie = false;

    public Vector3 firstPosition;
    public Vector3 lastPosition;

    private bool isGoing = true;

    private float time = 0;
    public float maxTime = 2;

    private Animator animator;

    public bool isSeePlayer = false;
    private Vector3 playerPosition;

    private void Start()
    {
        playerPosition = Camera.main.transform.position;
        animator = GetComponent<Animator>();
        animator.Play("Move");
    }

    private void Update()
    {
        if (Time.timeScale == 0)
        {   
            return;
        }
        if (isDie)
        {
            return;
        }

        if (isGoing)
        {
            transform.position = Vector3.Lerp(firstPosition, lastPosition, time / maxTime);
            transform.LookAt(lastPosition);
        }
        else
        {
            transform.position = Vector3.Lerp(lastPosition, firstPosition, time / maxTime);
            transform.LookAt(firstPosition);
        }
        if (isSeePlayer)
        {
            transform.LookAt(playerPosition);
        }

        if(time >= maxTime)
        {
            isGoing = !isGoing;
            time = 0;   
        }
        time = time + Time.deltaTime;
    }

    public bool isFind()
    {
        if (isDie)
        {
            return false;
        }
        isDie = true;
        animator.Play("Dying");
        Destroy(gameObject, 3f);
        return true;
    }

}
