using UnityEngine;

public class Dificult : MonoBehaviour
{
    public float timeScale = 2f;

    public RespawBalloons balloons;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
        Time.timeScale = timeScale;



        
        Destroy(this);
    
    }


}
