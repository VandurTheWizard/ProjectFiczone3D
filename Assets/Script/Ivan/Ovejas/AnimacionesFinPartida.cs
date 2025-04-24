using UnityEngine;
using UnityEngine.UI;

public class AnimacionesFinPartida : MonoBehaviour
{
    public GameObject oveja;
    public GameObject pulgar;

    public Sprite pulgarArriba;
    public Sprite pulgarAbajo;

    public Sprite ovejaFeliz;
    public Sprite ovejaTriste;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();   
    }


    public void AnimacionGanadora(){
        oveja.GetComponent<Image>().sprite = ovejaFeliz;
        pulgar.GetComponent<Image>().sprite = pulgarArriba;
        animator.Play("Animation");
    }

    public void AnimacionPerdedora(){
        oveja.GetComponent<Image>().sprite = ovejaTriste;
        pulgar.GetComponent<Image>().sprite = pulgarAbajo;
        animator.Play("Animation");
    }

    public void AnimationWait()
    {
        animator.Play("Wait");
    }
}
