using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BurguerDB", menuName = "BurguerDB", order = 0)]
public class SerializableBurguer : ScriptableObject
{
    [SerializeField] Lvl[] levels;

    public Lvl[] GetLvlList() { return levels; }
    public Lvl GetBurguer(int index)
    {
        return levels[index];
    }

    public int GetLvlCount()
    {
        return levels.Length;
    }
}


[System.Serializable]
public class Lvl
{
    public int id;
    public Burguer[] burguers;
}

[System.Serializable]
public class Burguer
{
    public int idBurguer;
    public int numRep;
    public List<Ingredient> ingredients;

    //public Ingredient ingredient;
    public enum Ingredient { BreadBottom, Meat, Cheese, Lettuce, Tomato,BreadTop }     

}

//Array burguer: pan, carne, queso, lechuga, tomate, pan 