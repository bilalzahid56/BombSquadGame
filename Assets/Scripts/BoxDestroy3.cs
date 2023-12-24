using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestroy3 : MonoBehaviour
{
 //  public GameObject bombBox3;
   
    private void Start()
    {
        StartCoroutine(DestroyBox());
    }
    public void  OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
           // bombBox3.SetActive(false);
              
              Destroy(gameObject);
             
        }
       
      
    }
       
    public IEnumerator DestroyBox()
    {
        yield return new WaitForSeconds(7);
        Destroy(gameObject);
    }
}
