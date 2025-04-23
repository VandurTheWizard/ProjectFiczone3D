using UnityEngine;
using UnityEngine.InputSystem;

public class FireDugeonController : MonoBehaviour
{
    Vector2 movement;

    int sensivity = 5;

    Animator animator;

    float time = 0;

    public bool touchFireFloor = false;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }
        time += Time.deltaTime / Time.timeScale;
        {
            if (movement == Vector2.zero || time > FireDugeonGameGestion.timePlay)
            {
                animator.Play("Idle");
            }
            else
            {
                animator.Play("Walk");

                Vector3 moveDirection = new Vector3(movement.x, 0, movement.y).normalized;
                transform.position += moveDirection * sensivity * Time.deltaTime / Time.timeScale;

                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    Quaternion.LookRotation(moveDirection),
                    Time.deltaTime / Time.timeScale * 10f
                );
            }
        }
    }

    public void OnMove(InputValue value)
    {
        if(Time.timeScale == 0)
        {
            movement = Vector2.zero;
        }
        else
        {
            movement = value.Get<Vector2>();
        }
           
    }


}
