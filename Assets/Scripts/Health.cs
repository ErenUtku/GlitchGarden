using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 100f;

    [Header("Effect")]

    [SerializeField] GameObject DestroyEfect;
    [SerializeField] float durationofExplosion = 1f;
    [SerializeField] AudioClip DeathSound;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.5f;

    public void DealDamage(float damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            TriggerVFX();
            Destroy(gameObject);
       
        }       
    }
    private void TriggerVFX()
    {
        if (!DestroyEfect) { return; }
        GameObject explosion = Instantiate(DestroyEfect, transform.position, Quaternion.identity);
        Destroy(explosion, durationofExplosion);
        AudioSource.PlayClipAtPoint(DeathSound, Camera.main.transform.position, deathSoundVolume);
    }

}
