using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombThrow : MonoBehaviour
{
    public GameObject  bomb;
    public Rigidbody bombRb;

    private Vector3 direction;
    //public GameObject AreaCertainBomb;
    public GameObject player;
    public float speed = 5f;
    private void Start()
    {
        bombRb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        BallMoveAheadFromPlayer();
    }
    void BallMoveAheadFromPlayer()
    {
        
        
        if(Input.GetKeyDown(KeyCode.F))
        {
            bomb.SetActive(true);
            direction = player.transform.position - bomb.transform.position;
            bombRb.AddForceAtPosition(direction.normalized,transform.position);
            //bomb.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z) + new Vector3(AreaCertainBomb.transform.position.x, AreaCertainBomb.transform.position.y, AreaCertainBomb.transform.position.z);
            Debug.Log("FFF");
        
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }

}
