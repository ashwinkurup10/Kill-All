using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawningEnemy : MonoBehaviour
{
    public int waveNumber = 0;
    public int enemySpawnNumber = 0;
    public int enemiesKilled = 0;
    public int countdown = 0;

    public GameObject[] spawners;
    public GameObject enemy;
    public Text txt;
    
    

    private void Start()
    {
        spawners = new GameObject[5];
        for (int i = 0; i < spawners.Length; i++)
        {
            spawners[i] = transform.GetChild(i).gameObject;
        }
        StartWave();
    }

    public void Update()
    {
        
        if (countdown >= enemySpawnNumber)
        {
            StartCoroutine(NextWave());
        }
        txt.text = enemiesKilled.ToString();
        

    }

    private void SpawnEnemy()
    {
        int spawnerID = Random.Range(0, spawners.Length);
        Instantiate(enemy, spawners[spawnerID].transform.position, spawners[spawnerID].transform.rotation);
    }

    private void StartWave()
    {
        waveNumber = 1;
        enemySpawnNumber = 2;
        enemiesKilled = 0;
        countdown = 0;

        for (int i = 0; i < 2; i++)
        {
            SpawnEnemy();
        }
    }

    IEnumerator NextWave()
    {
        waveNumber++;
        countdown = 0;
        

        for (int i = 0; i <= enemySpawnNumber; i++)
        {
            yield return new WaitForSeconds(1f);
            SpawnEnemy();
        }
        enemySpawnNumber ++;
    }

}
