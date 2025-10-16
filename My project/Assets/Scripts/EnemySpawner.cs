using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public bool spawning = false;

    public GameManager gm;

    public GameObject enemy;

    public float spawnWait;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("gm").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!spawning && gm.enemiesCanSpawn)
        {
            spawning = true;
            Instantiate(enemy, transform.position, transform.rotation);
            gm.enemiesSpawned++;
            StartCoroutine("SpawnCooldown");
        }
        
    }

    IEnumerator SpawnCooldown()
    {
        yield return new WaitForSeconds(spawnWait);
        spawning = false;
    }
}
