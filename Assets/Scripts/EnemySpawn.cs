using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    [SerializeField] Attacker EnemyPrefab;
    [SerializeField] float mins=0;
    [SerializeField] float maxs=5f;
    [SerializeField] bool spawn = true;
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(mins,maxs));
            Spawn();
        }
    }
    private void Spawn()
    {
        Attacker NewAttacker=  Instantiate
            (EnemyPrefab, transform.position, Quaternion.identity)
              as Attacker;
        NewAttacker.transform.parent = transform;
    }
    void Update()
    {
        
    }
}
