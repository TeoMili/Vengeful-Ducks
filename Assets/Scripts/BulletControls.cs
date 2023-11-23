using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletControls : MonoBehaviour
{
    
    public float speed = 4.5f;

    void Update()
    {
        transform.position += transform.up * Time.deltaTime * speed;

		if(transform.position.x < -10 || transform.position.x > 10 || transform.position.y < -10 || transform.position.y > 10)
		{
			//out of bounds
			Destroy(gameObject);
		}
    }

}
