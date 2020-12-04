using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeField]
    private float _speed = 20f;
    [SerializeField]
    private GameObject laser;

    private int Lives = 3;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	    InputMovement();
        BoundingMovement();
        SpawnLaser();
    }

    private void InputMovement()
    {
	    var horizontalInput = Input.GetAxis("Horizontal");
	    var verticalInput = Input.GetAxis("Vertical");
	    var direction = new Vector3(horizontalInput, verticalInput, 0);
	    transform.Translate(direction * Time.deltaTime * _speed);
    }
    private void BoundingMovement()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);
        var rightBound = 12.5f;
        var leftBound = -12.5f;
        if (transform.position.x >= rightBound)
        {
	        transform.position = new Vector3(leftBound, transform.position.y, 0);
        } else if (transform.position.x <= leftBound)
        {
	        transform.position = new Vector3(rightBound, transform.position.y, 0);
        }
    }

    private void SpawnLaser()
    {
	    if (Input.GetKeyDown(KeyCode.Space))
	    {
		    Instantiate(laser, transform.position, Quaternion.identity);
	    }
    }

    public void TakeDamage()
    {
	    Lives--;
	    if (Lives <= 0)
	    {
		    var spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
            spawnManager.StopSpawningEnemy();
            Destroy(gameObject);
	    }
    }
}
