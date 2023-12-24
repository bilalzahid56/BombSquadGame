using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
  

    public GameObject enemy;
    public GameObject[] bombBox;
    
   
  
    void Start()
    {

        InvokeRepeating("RepeatingEnemy", 11f, 11f);
        InvokeRepeating("BombBox1", 5f, 11f);
        InvokeRepeating("BombBox2", 11f, 19f);
        InvokeRepeating("BombBox3", 11f, 11f);
    }
    
    private void RepeatingEnemy()
    {
        Instantiate(enemy, new Vector3(Random.Range(-12.5f, 12.5f), 0, Random.Range(-9.3f, 9.3f)), transform.rotation);
       
    }
    private void BombBox1()
    {
        Instantiate(bombBox[0], new Vector3(Random.Range(7f,11.5f), 0, Random.Range(-7.5f, 7.5f)),transform.rotation);
    }
    private void BombBox2()
    {
        Instantiate(bombBox[1], new Vector3(Random.Range(-5.5f,4f),0,Random.Range(-10f,10f)),transform.rotation);
    }
    private void BombBox3()
    {
        Instantiate(bombBox[2], new Vector3(Random.Range(-4f,5.5f), 0, Random.Range(-11f,11f)), transform.rotation);
    }
 
    

}
