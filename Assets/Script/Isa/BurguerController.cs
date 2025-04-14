using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BurguerController : MonoBehaviour
{
    [Tooltip("Objet to parent all loose hamburguer ingredient")]
    [SerializeField] private GameObject hamburguer;

    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    private Vector3 endPosition;
    private Vector3 startPosition;

    [Header("Level data")]
    [SerializeField] private SerializableBurguer levelDB;
    [SerializeField] private List<GameObject> ingredients = new List<GameObject>();
    private Dictionary<int, GameObject> ingredientMap = new Dictionary<int, GameObject>();
    private Lvl[] levelList;

    [Header("Status Text")]
    [SerializeField] private TextMeshProUGUI nextTMP;


    [Header("Sound")]
    [SerializeField] private AudioSource fallSound;

    //Nav variables
    private int currentLevel;
    private int currentBurguer;
    private int currentIngredient;

    private bool canPlay=true;

    private int ingredientPoints = 0;


    private void Awake()
    {
        endPosition = new Vector3(1, transform.position.y, transform.position.z);
        startPosition = new Vector3(0, transform.position.y, transform.position.z);


        //Start level1
        currentLevel = 0;
        currentBurguer = 0;
        currentIngredient = 0;

        FillDictionary();

    }


    private void Start()
    {
        levelList = levelDB.GetLvlList();
        SetIngredient();

        //CountIngredient();
    }


    private void Update()
    {
        MoveAlongScreen();
    }

    private void OnJump()
    {
        if (LevelManager.Instance.playing && canPlay)
        {
            GameObject myChild = gameObject.transform.GetChild(0).gameObject;

            myChild.transform.SetParent(hamburguer.transform, true);
            myChild.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;

            myChild.GetComponent<Rigidbody>().useGravity = true;

            fallSound.Play();

            canPlay = false;
        }
    }

    private void MoveAlongScreen()
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

    private void ResetPosition()
    {
        transform.position = startPosition;
    }

    IEnumerator ShowText(string text)
    {
        yield return new WaitForSeconds(0.2f);
        nextTMP.enabled = true;
        nextTMP.text = text;
        yield return new WaitForSeconds(1f);
        nextTMP.enabled = false;
    }

    #region Ingredient controll
    Burguer myBurguer;
    private void SetIngredient()
    {
        ResetPosition();
        myBurguer = levelList[currentLevel].burguers[currentBurguer];
        if (ingredientMap.TryGetValue(((int)myBurguer.ingredients[currentIngredient]), out GameObject go))
        {
            //Set ingredient in generator
            GameObject instantiatedGo = Instantiate(go, transform, false);
            instantiatedGo.GetComponent<Rigidbody>().useGravity = false;
            canPlay = true;
        }
    }

    public void NextIngredient()
    {
        currentIngredient++;

        if (myBurguer.ingredients.Count == currentIngredient) //if its last ingredient we go to the next burguer
        {
            currentIngredient = 0;
            currentBurguer++;

            StartCoroutine(ShowText("Keep it up"));
            movementSpeed = movementSpeed + 0.1f;
                       
            foreach (Transform child in hamburguer.transform)
            {
                if (!child.CompareTag( "Plate"))
                {
                    GameObject.Destroy(child.gameObject);
                }
            }

            if (currentBurguer == 5 && currentLevel+1 < levelList.Length) //if its last burguer we go to next lvl
            {
                currentBurguer = 0;
                currentLevel++;

                StartCoroutine(ShowText("Faster!"));
                movementSpeed = movementSpeed * 1.5f;
                //TO DO: NEXT LVL
            }
        }

        SetIngredient();
    }
    #endregion

    #region Control Methods
    private void FillDictionary()
    {
        for (int i = 0; i < ingredients.Count; i++)
        {
            ingredientMap.Add(i, ingredients[i]);
        }
    }


    private void CountIngredient()
    {
        int burguerNumber = 0;
        int ingredientNumber = 0;
        foreach (Lvl level in levelList)
        {
            foreach (Burguer burguer in level.burguers)
            {
                burguerNumber++;
                for (int i = 0; i < burguer.ingredients.Count; i++)
                {
                    ingredientNumber++;
                    //Debug.Log(burguer.ingredients[i]);
                }
            }
        }
        int totalPointsNeeded = ingredientNumber  * 2; //Todos los ingredientes *2 (perfect)
        Debug.Log(totalPointsNeeded);
    }
    #endregion
}
