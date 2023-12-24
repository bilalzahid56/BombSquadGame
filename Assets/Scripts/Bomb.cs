using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public float explosionForce = 10f; // Adjust the explosion force
    public float explosionRadius = 5f;
    // public GameObject enemy;
    public GameObject player;
    private Vector3 resetPosition = new Vector3(0, -0.65f, 0);
    //public AudioSource audioBomb;
    public float projectileLifeSpan = 2.0f;
    public GameObject explosionEffect;
   public Rigidbody bombRigidbody;
    private Transform playerTransform;
    private Vector3 directionToPlayer;
   public float speed = 30f;
   // private Transform stickyBomb;
    private void Start()
    {
        bombRigidbody = GetComponent<Rigidbody>();
        playerTransform = GameObject.FindWithTag("Player").transform;
        MoveTowardsPlayer();
        // stickyBomb = GameObject.FindWithTag("Enemy").transform;
        //audioBomb = GetComponent<AudioSource>();

        StartCoroutine("WaitForBombDestory");
    }
    void MoveTowardsPlayer()
    {
        directionToPlayer = (playerTransform.position - transform.position).normalized;


        bombRigidbody.AddForce(directionToPlayer * speed, ForceMode.VelocityChange);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //transform.position = enemy.transform.position;

            //stickyBomb.transform.position = transform.position;
            Destroy(this.gameObject);
            //  audioBomb.Play();
            Explode();
        }
       // if (collision.gameObject.CompareTag("Player"))
     //   {
            //if()
         //   player.transform.position = resetPosition;
//}
    }
    void DestoryGameBallAfterStickTOPlayer()
    {
        Destroy(this.gameObject);
    }
    IEnumerator WaitForBombDestory()
    {
        yield return new WaitForSeconds(5f);
       // audioBomb.Play();
        Destroy(gameObject);
       
        Explode();
    }
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }


        Instantiate(explosionEffect, transform.position, transform.rotation);
        
       // Destroy(explosionEffect);
        DestroyImmediate(explosionEffect);
    }


    IEnumerator Wait(float Delay)
    {
        yield return new WaitForSeconds(Delay);
    }
   

    
}
