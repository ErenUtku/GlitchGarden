using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderAttack : MonoBehaviour
{
    [SerializeField] GameObject Projectile,ShootingRange;
    EnemySpawn mylaneSpawner;
    Animator animator;

    void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {

        if (AttackerInlane())
        {
            Debug.Log("Pew Pew");
            animator.SetBool("IsAttacking", true);
        }
        else
        {
            Debug.Log("No");
            animator.SetBool("IsAttacking", false);
        }
       
    }
    private void SetLaneSpawner()
    {
        EnemySpawn[] enemyspawn = FindObjectsOfType<EnemySpawn>();

        foreach(EnemySpawn EnemySpawn in enemyspawn)
        {
            bool IsCloseEnough = (Mathf.Abs(EnemySpawn.transform.position.y-transform.position.y )<= Mathf.Epsilon);
            if (IsCloseEnough)
            {
                mylaneSpawner = EnemySpawn;
            }
        }
    }

    private bool AttackerInlane()
    {
        if(mylaneSpawner.transform.childCount <=0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Fire()
    {
       
        Instantiate(Projectile, ShootingRange.transform.position, transform.rotation);    
    }
  
}
