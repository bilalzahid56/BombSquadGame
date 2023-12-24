using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDestroy : MonoBehaviour
{
   // public GameObject bombBox1;
    
    private void Start()
    {
        StartCoroutine(DestroyBox());
    }
    public void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.CompareTag("Player"))
        {
          //  bombBox1.SetActive(false);
           
            Destroy(gameObject);
        }
      
        
    }

    public IEnumerator  DestroyBox()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
