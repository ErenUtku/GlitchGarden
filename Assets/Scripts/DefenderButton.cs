using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defenders DefenderPrefab;

    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach(DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255 ,145);
        }
        GetComponent<SpriteRenderer>().color=Color.white;
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(DefenderPrefab);
    }
}
