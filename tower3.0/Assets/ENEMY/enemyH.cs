using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyH : MonoBehaviour
{
   [SerializeField] GameObject kaboom;
   public int Health = 10;

   

   public void Damage(int damage)
   {
    Health -= damage;

    if(Health <=0)
    {
        
        Destroy(this.gameObject);
        GameObject explosion = Instantiate(kaboom,transform.position, transform.rotation);
        waveSpawn.EnemiesAlive--;
        
    }
   }
}
