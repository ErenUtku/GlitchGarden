using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defenders : MonoBehaviour
{
    public int StarCost = 100;

    public void AddStar(int amount)
    {
        FindObjectOfType<StarDisplay>().AddStar(amount);
    }
    public int GetStarCost()
    {
        return StarCost;
    }
  

}
