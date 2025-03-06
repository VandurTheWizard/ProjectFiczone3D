using System.Collections.Generic;
using UnityEngine;

public class BurguerController : MonoBehaviour
{
    [Tooltip("Objet to parent all lose hamburguer ingredient")]
    [SerializeField] private GameObject hamburguer;

    [Header("Movement")]
    [SerializeField] private float movementSpeed;
    private Vector3 endPosition;

    [Header("Level data")]
    [SerializeField] private SerializableBurguer levelDB;
    [SerializeField] private List<GameObject> ingredients = new List<GameObject>();
    private Dictionary<int, GameObject> ingredientMap = new Dictionary<int, GameObject>();
    private Lvl[] levelList;

    //Nav variables
    private int currentLevel;
    private int currentBurguer;
    private int currentIngredient;


    private void Awake()
    {
        endPosition = new Vector3(1, transform.position.y, transform.position.z);

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
    }


    private void Update()
    {
        MoveAlongScreen();
    }
    private void OnJump()
    {
        GameObject myChild = gameObject.transform.GetChild(0).gameObject;

        myChild.transform.SetParent(hamburguer.transform, true);
        myChild.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;

        myChild.GetComponent<Rigidbody>().useGravity = true;
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

    #region Ingredient controll
    Burguer myBurguer;
    private void SetIngredient()
    {
        myBurguer = levelList[currentLevel].burguers[currentBurguer];
        if (ingredientMap.TryGetValue(((int)myBurguer.ingredients[currentIngredient]), out GameObject go))
        {
            //Set ingredient in generator
            GameObject instantiatedGo = Instantiate(go, transform, false);
            instantiatedGo.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    public void NextIngredient()
    {
        currentIngredient++;

        if (myBurguer.ingredients.Count == currentIngredient) //if its last ingredient we go to the next burguer
        {
            currentIngredient = 0;
            currentBurguer++;

            if (currentBurguer == 5) //if its last burguer we go to next lvl
            {
                currentBurguer = 0;
                currentLevel++;

                //TO DO: NEXT LVL
            }
        }

        SetIngredient();
    }
    #endregion

    private void FillDictionary()
    {
        for (int i = 0; i < ingredients.Count; i++)
        {
            ingredientMap.Add(i, ingredients[i]);
        }
    }
}
