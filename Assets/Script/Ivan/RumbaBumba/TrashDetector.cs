using System.Collections;
using UnityEngine;

public class TrashDetector : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private ArrayList trashList = new ArrayList();
    private bool isTrashInRange = false;
    public float timeToChangeColor = 0.5f; 
    public float timeToWin = 1f;
    private float timer = 0f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.red; 
    }

    void Update()
    {
        if(trashList.Count > 0){
            timer += Time.deltaTime;
            if(timer >= timeToChangeColor){
                spriteRenderer.color = Color.green; 
                if(timer >= timeToWin){
                    Debug.Log("You win");
                }
            }
        }else{
            timer = 0f;
            spriteRenderer.color = Color.red; 
        }
    } 

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Trash"))
        {
            trashList.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Trash"))
        {
            trashList.Remove(other.gameObject);
        }
    }
}
