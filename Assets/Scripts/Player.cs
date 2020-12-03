using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _speed = 1.5f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	    var horizontalInput = Input.GetAxis("Horizontal");
	    var verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * _speed);
        transform.Translate(Vector3.up * verticalInput * Time.deltaTime * _speed);

        //transform.position.x =
    }
}
