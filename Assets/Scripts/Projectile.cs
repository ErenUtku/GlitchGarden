using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 7f;
    [SerializeField] float damage = 100f;


    [Header("Effect")]

    [SerializeField] GameObject DestroyEfect;
    [SerializeField] float durationofExplosion = 1f;
    [SerializeField] AudioClip DeathSound;
    [SerializeField] [Range(0, 1)] float deathSoundVolume = 0.5f;


    void Update()
    {
        Move();       
    }

    private void Move()
    {

        transform.Translate(UnityEngine.Vector2.right * speed * Time.deltaTime);     
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var health = other.GetComponent<Health>();
        var attacker = other.GetComponent<Attacker>();
        if (health && attacker)
        {
            health.DealDamage(damage);
            GameObject explosion = Instantiate(DestroyEfect, transform.position, Quaternion.identity);
            Destroy(explosion, durationofExplosion);
            AudioSource.PlayClipAtPoint(DeathSound, Camera.main.transform.position, deathSoundVolume);
            Destroy(gameObject);
        }
        
    }

}
