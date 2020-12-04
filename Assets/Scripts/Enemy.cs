using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	    transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if (transform.position.y < -6)
	    {
            transform.position = new Vector3(Random.Range(-12f, 12f), 6);
	    }
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Laser")
		{
            Destroy(other.gameObject);
            Destroy(gameObject);
		} else if (other.gameObject.tag == "Player")
		{
			Destroy(gameObject);
			other.transform.GetComponent<Player>().TakeDamage();
		}
	}
}
