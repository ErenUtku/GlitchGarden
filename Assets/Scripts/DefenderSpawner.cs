using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{

    Defenders Defenderprefab;
    

    private void OnMouseDown()
    {
        AttemptToPlaceDefenderAt(SpawnSquare());
    }

    private Vector2 SpawnSquare()
    {
      

        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 WorldPos = Camera.main.ScreenToWorldPoint(mousePos);
        Vector2 gridPos = SnapToGrid(WorldPos);       
        return gridPos;
    }

    private void SpawnDefender(Vector2 roundedpos)
    {
        Defenders newdefender = Instantiate(Defenderprefab, roundedpos, transform.rotation) as Defenders;
    }

    public void SetSelectedDefender(Defenders defenderToSelect)
    {
        this.Defenderprefab = defenderToSelect;
    }

   
    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newposX = Mathf.RoundToInt(rawWorldPos.x);
        float newposY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newposX, newposY);
       

    }
    private void AttemptToPlaceDefenderAt(Vector2 gridPos)
    {
        var StarDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = Defenderprefab.GetStarCost();
        if (StarDisplay.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            StarDisplay.SpendStar(defenderCost);
        }

       


    }
    
}
