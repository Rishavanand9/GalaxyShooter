using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    [SerializeField]
    private GameObject[] powerups;

    [SerializeField]
    private GameObject enemy;

    private GameManager gameManager;
	void Start () {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        StartCoroutine(spawnEnemy());
        StartCoroutine(spawnPowerUp());
     	
	}

    public void startSpawnRoutine()
    {
        StartCoroutine(spawnEnemy());
        StartCoroutine(spawnPowerUp());
    }

    public IEnumerator spawnEnemy()
    {
        while (gameManager.gameOver==false)
        {
            Instantiate(enemy, new Vector3(Random.Range(-7, 7), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(2.0f);
        }
    }

    public IEnumerator spawnPowerUp()
    {
        while (gameManager.gameOver == false)
        {
            int randompower = Random.Range(0, 3);
            Instantiate(powerups[randompower], new Vector3(Random.Range(-7, 7), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }


    }

}
