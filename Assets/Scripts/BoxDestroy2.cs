using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestroy2 : MonoBehaviour
{
    //public GameObject bombBox2;public int bomBoxDestory2 = 0;
    private void Start()
    {
        StartCoroutine(DestroyBox());
    }
    public void   OnTriggerEnter(Collider other)
    { 
        
        if (other.gameObject.CompareTag("Player"))
        {
            //bombBox2.SetActive(false);

            Destroy(gameObject);
           
           
           
        }
       

    }
    public IEnumerator DestroyBox()
    {
        yield return new WaitForSeconds(7);
        Destroy(gameObject);
    }
}
