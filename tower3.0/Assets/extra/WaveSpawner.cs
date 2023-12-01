// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.AI;


// public class WaveSpawner : MonoBehaviour
// {
    
//     public enum SpawnState {SPAWNING, WAITING, COUNTING};
//     [System.Serializable]
//     public class Wave
// {
//    public string name;
//    public Transform enemy;
//    public int count;
//    public int rate;

   
// }

// public Wave[] waves;
// private int nextWave =0;
// public float timeBetweenWaves =5f;
// public float waveCountdown;
// private float searchCountdown; 
// private SpawnState state = SpawnState.COUNTING;

// void Start()
// {
//     waveCountdown = timeBetweenWaves;
// }

// void Update()
// {

//     if(state == SpawnState.WAITING)
//     {
//         // check if enemy alive
//         if(!EnemyIsAlive())
//         {
//             //begin new round
//             Debug.Log("Wave Completed");
//             return;
//         }
//         else
//         {
//             return;
//         }
//     }
//     if(waveCountdown <= 0)
//     {
//         if(state != SpawnState.SPAWNING)
//         {
//             // start spawning the waves

//             StartCoroutine(SpawnWave (waves[nextWave]));
//         }
//     }

//     else
//     {
//         waveCountdown -= Time.deltaTime;
//     }

// }

// bool EnemyIsAlive()
// {
//     searchCountdown -= Time.deltaTime;
//     if(searchCountdown<=0f)
//     {
//         searchCountdown =1f;
//          if(GameObject.FindGameObjectWithTag("Enemy")== null)
//         {
//             return false;
//         }
//     }
   

//     return true;
// }

// IEnumerator SpawnWave(Wave _wave)
// {
//     Debug.Log("Spawning Wave:" + _wave.name);
//     state =SpawnState.SPAWNING;

//     for(int i = 0; i < _wave.count; i++)
//     {
//         SpawnEnemy(_wave.enemy);
//         yield return new WaitForSeconds( 1f/ _wave.rate);
//     }

//     state = SpawnState.WAITING;

//     yield break;
// }

// void SpawnEnemy(Transform _enemy)
// {
//     //spawn enemy
//     Debug.Log("Spawning enemy: " + _enemy.name);
//     Vector3 randomSpawnPosition1 = new Vector3(Random.Range(-310,-291),5,Random.Range(-10,11));
//     Vector3 randomSpawnPosition2 = new Vector3(Random.Range(310,291),5,Random.Range(-10,11));
//     Vector3 randomSpawnPosition3 = new Vector3(Random.Range(-10,11),5,Random.Range(-310,-291));
//     Vector3 randomSpawnPosition4 = new Vector3(Random.Range(-10,11),5,Random.Range(310,291));
//     Instantiate(_enemy, randomSpawnPosition1, Quaternion.identity);
//     Instantiate(_enemy, randomSpawnPosition2, Quaternion.identity);
//     Instantiate(_enemy, randomSpawnPosition3, Quaternion.identity);
//     Instantiate(_enemy, randomSpawnPosition4, Quaternion.identity);

   
    
// }

// }
