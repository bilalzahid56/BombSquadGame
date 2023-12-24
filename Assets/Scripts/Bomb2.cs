using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb2 : MonoBehaviour
{
    public float explosionForce = 10f; // Adjust the explosion force
    public float explosionRadius = 5f;
    public GameObject player;
    private Vector3 resetPosition = new Vector3(0, -0.65f, 0);

    //public AudioSource audioBomb;
    public GameObject explosionEffect;
    public Rigidbody bombRigidbody;
    private Transform playerTransform;
    private Vector3 directionToPlayer;

   public float speed = 30f;
    private void Start()
    {
        bombRigidbody = GetComponent<Rigidbody>();
        playerTransform = GameObject.FindWithTag("Player").transform;
       // audioBomb = GetComponent<AudioSource>();
        MoveTowardsPlayer();

        StartCoroutine("WaitForBombDestory");
    }
    void MoveTowardsPlayer()
    {  
        directionToPlayer = (playerTransform.position - transform.position).normalized;     
        

        bombRigidbody.AddForce(directionToPlayer * speed, ForceMode.VelocityChange);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
           // audioBomb.Play();
            Explode();
        }
     //   if (collision.gameObject.CompareTag("Player"))
       // {
       //     player.transform.position = resetPosition;
      ///  }
    }
    IEnumerator WaitForBombDestory()
    {
        yield return new WaitForSeconds(5f);
        
        Destroy(gameObject);
       // audioBomb.Play();
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

        DestroyImmediate(explosionEffect,true);
    }
   


}
