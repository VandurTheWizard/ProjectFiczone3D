using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using static System.Collections.Specialized.BitVector32;

public class ChainMovement : MonoBehaviour
{

    public Vector3 firstPosition;
    public Vector3 lastPosition;

    public int chainNumber;

    private float time;
    private bool isUp = false;


    DartGameGestion game;


    private void Start()
    {
        game = GameObject.FindAnyObjectByType<DartGameGestion>();
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (isUp)
        {

            transform.position = Vector3.Lerp(lastPosition, firstPosition, time / 3);
        }
        else
        {

            transform.position = Vector3.Lerp(firstPosition, lastPosition, time / 3);
        }
        if(isUp && time > 4)
        {
            game.changeUsable(chainNumber);
            Destroy(gameObject);
        }
        if(time > 4)
        {
            StartCoroutine(up());
        }
            
    }
    private IEnumerator up()
    {
        yield return new WaitForSeconds(0.5f);
        time = 0;
        isUp = true;

    }
}
