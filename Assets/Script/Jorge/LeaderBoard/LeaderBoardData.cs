using System;
using UnityEngine;

[Serializable]
public class LeaderBoardData
{
    public string[] names = new string[7];
    public int[] value = new int[7];
    public bool isTime;

    public LeaderBoardData(bool time)
    {
        if (time)
        {
            for (int x = 0; x < value.Length;x++)
            {
                    value[x] = 999999;
            }
        }
        else
        {
            for (int x = 0; x < value.Length; x++)
            {
                value[x] = 0;
            }
        }
            isTime = time;
    }

    public bool isNewValue(int newValue)
    {
        if (isTime)
        {
            return newValue < value[value.Length - 1];
        }
        else
        {
            Debug.Log(value.Length);
            return newValue > value[value.Length - 1];
        }
        
    }

    public void addNewValue(int newValue, string newPlayer)
    {
        if (isTime)
        {
            changeValuesTime(getPositionTime(newValue), newPlayer, newValue);
        }
        else
        {
            changeValuesNotTime(getPositionNotTime(newValue), newPlayer, newValue);
        }
    }

    private int getPositionNotTime(int newValue)
    {
       for(int i = 0; i < value.Length; i++) {
            if (newValue >= value[i])
            {
                    while (newValue == value[i])
                    {
                    i++;
                    }
                return i;
            }
        }
       return -1;
    }

    private int getPositionTime(int newValue)
    {
        for (int i = 0; i < value.Length; i++)
        {
            if (newValue <= value[i])
            {
                while (newValue == value[i])
                {
                    i++;
                }
                return i;
            }
        }
        return -1;
    }

    private void changeValuesNotTime(int position, string name, int newValue)
    {
        
        for (int i = value.Length - 1; i > position; i--)
        {
            value[i] = value[i - 1];
            names[i] = names[i - 1];
        }

        value[position] = newValue;
        names[position] = name;

    }

    private void changeValuesTime(int position, string name, int newValue)
    {
        for (int i = value.Length - 1; i > position; i--)
        {
            value[i] = value[i - 1];
            names[i] = names[i - 1];
        }

        value[position] = newValue;
        names[position] = name;
    }

    public bool haveMorePlayers(int position)
    {
        return names[position] != null;
    }

    public string represetationOfPoint(int position)
    {
        if (isTime)
        {
            return value[position] / 60 + ":" + value[position] % 60;
        }
        else
        {
            return value[position] + "";
        }
    }
}
