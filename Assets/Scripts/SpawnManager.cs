using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Enemy;
    void Start()
    {
	    StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnEnemy()
    {
	    while (true)
	    {
		    Instantiate(Enemy, new Vector3(Random.Range(-12f, 12f), 6), Quaternion.identity);
            yield return new WaitForSeconds(5f);
	    }
    }

    public void StopSpawningEnemy()
    {
        StopCoroutine(SpawnEnemy());
    }
}
