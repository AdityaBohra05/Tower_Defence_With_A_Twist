using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class waveSpawn : MonoBehaviour {

	[System.Serializable]
public class Wave {

	public GameObject enemy;
	public int count;
	public float rate;

}

	public static int EnemiesAlive = 0;

	public Wave[] waves;

	public Transform spawnPoint;

	public float timeBetweenWaves = 5f;
	private float countdown = 2f;

	public Text waveCountdownText;

	public GameManager gameManager;

	private int waveIndex = 0;

	void Update ()
	{
		if (EnemiesAlive > 0)
		{
			return;
		}

		if (waveIndex == waves.Length)
		{
			gameManager.WinLevel();
			this.enabled = false;
		}

		if (countdown <= 0f)
		{
			StartCoroutine(SpawnWave());
			countdown = timeBetweenWaves;
			return;
		}

		countdown -= Time.deltaTime;

		countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

		waveCountdownText.text = string.Format("{0:00.00}", countdown);
	}

	IEnumerator SpawnWave ()
	{
		PlayerStats.Rounds++;

		Wave wave = waves[waveIndex];

		EnemiesAlive = wave.count;

		for (int i = 0; i < wave.count; i++)
		{
			SpawnEnemy(wave.enemy);
			yield return new WaitForSeconds(1f / wave.rate);
		}

		waveIndex++;
	}

	void SpawnEnemy (GameObject enemy)
	{
		//Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
		 Debug.Log("Spawning enemy: " + enemy.name);
    	Vector3 randomSpawnPosition1 = new Vector3(Random.Range(-310,-291),5,Random.Range(-10,11));
    	Vector3 randomSpawnPosition2 = new Vector3(Random.Range(310,291),5,Random.Range(-10,11));
    	Vector3 randomSpawnPosition3 = new Vector3(Random.Range(-10,11),5,Random.Range(-310,-291));
    	Vector3 randomSpawnPosition4 = new Vector3(Random.Range(-10,11),5,Random.Range(310,291));
    	Instantiate(enemy, randomSpawnPosition1, Quaternion.identity);
    	Instantiate(enemy, randomSpawnPosition2, Quaternion.identity);
    	Instantiate(enemy, randomSpawnPosition3, Quaternion.identity);
    	Instantiate(enemy, randomSpawnPosition4, Quaternion.identity);
	}

}
