using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Range(0f, 5f)]
    [SerializeField] float Wait=1f;
    [SerializeField] float walkspeed = 1f;

    void Start()
    {
        
    }

    void Update()
    {
        StartCoroutine(WaitAndRun());
    }
    IEnumerator WaitAndRun()
    {
        yield return new WaitForSeconds(Wait);
        Move();
; 
    }
    public void Move()
    {
        transform.Translate(UnityEngine.Vector2.left * walkspeed * Time.deltaTime);
    }

    public void SetMovementSpeed(float speed)
    {
        walkspeed = speed;
    } 

}
