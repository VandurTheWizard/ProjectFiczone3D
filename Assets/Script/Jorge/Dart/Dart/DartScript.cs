using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DartScript : MonoBehaviour
{
    private int goingTo = 1;
    private const int LEFT = 0;
    private const int RIGHT = 2;
    private const int CENTRE = 1;

    private bool isAttack = false;
    public Vector3[] positions;

    private float time = 0;
    private bool isFind = false;

    private Vector3 startPosition;

    public DartGameGestion gestion;

    private bool isPress = false;
    private void Start()
    {
        Time.timeScale = 3;
        startPosition = transform.position;
    }

    public void OnMove(InputValue value)
    {
        if (isAttack)
        {
            return;
        }

        Vector2 val = value.Get<Vector2>();

        switch (val.x)
        {
            case > 0:
                goingTo = RIGHT;
                break;
            case < 0:
                goingTo = LEFT;
                break;
            case 0:
                goingTo = CENTRE;
                break;
        }
    }

    public void OnAttack(InputValue value)
    {
        if (!isPress)
        {
            isPress = true;
            isAttack = true;
            StartCoroutine(next());
        }
    }


    private IEnumerator next()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject.GetComponent<PlayerInput>());
        gestion.nextDart();
       
        
        

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(positions[goingTo]);
        transform.Rotate(0, 90, 0);

        if (isAttack && !isFind)
        {
            time += Time.deltaTime;
            if (time >= 1 && !isFind)
            {
                Destroy(gameObject);
            }
            transform.position = Vector3.Lerp(startPosition, positions[goingTo], time);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isFind)
        {
            return;
        }
        isFind = true;
        transform.SetParent(other.transform);
        
        other.gameObject.transform.parent.GetComponent<DartBoard>().NormalDelete();
        Destroy(other.gameObject.transform.parent.gameObject);
        Destroy(this);
    }
}
