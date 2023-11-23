using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimControls : MonoBehaviour
{

    private Vector3 mousePosition;
    public Camera mainCamera;

    public GameObject bullet;

    public GameObject player;

    public AudioSource shootSound;

    void Update()
    {
        //get current mouse position
        mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

	    if(!player.GetComponent<PlayerControls>().won && Input.GetMouseButtonDown(0))
	    {
		    //spawn bullet
		    Instantiate(bullet, transform.position, transform.rotation);

            //play shooting sound
            shootSound.Play();
	    }
    }

    void FixedUpdate()
    {
        //rotate the arrow in accordance with the mouse position
	    Vector3 direction = mousePosition - transform.position;
	    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
	    transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
