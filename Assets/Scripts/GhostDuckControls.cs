using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class GhostDuckControls : MonoBehaviour
{
	public GameObject duck;

	public AIPath aiPath;

	private bool facingLeft;

	private GameObject player;
	private AudioSource hitSound;

	void Start()
	{
		//get the player game object
		player = GameObject.FindGameObjectWithTag("Player");

		//get the ghost hit sound
		hitSound = player.GetComponent<AudioSource>();

        //set target for path finding
        AIDestinationSetter script = GetComponent<AIDestinationSetter>();
		script.target = GameObject.FindGameObjectWithTag("Player").transform;

		facingLeft = true;
	}

	void Update()
	{
		//flip sprite depending on the direction in which the ghost duck will move
		if (facingLeft && aiPath.desiredVelocity.x >= 0.1f)
		{
			facingLeft = false;
			Flip();
		}
		else if (!facingLeft && aiPath.desiredVelocity.x <= 0.1f)
		{
			facingLeft = true;
			Flip();
		}
	}

	void Flip()
	{
		//rotates a sprite to face in the direction of the movement
		transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}

	void OnCollisionEnter2D(Collision2D col)
	{ 
		if (col.gameObject.tag == "Bullet")
		{
			//destroy the ghost
			DestroyGhost();

			//destroy the bullet
			Destroy(col.gameObject);
		}
		else if(col.gameObject.tag == "Player")
		{
			//destroy the ghost
			DestroyGhost();
		}

	}

	private void DestroyGhost()
	{
        //play hit sound
        hitSound.Play();

        //destroy the ghost, with a delay to ensure the sound is played
        Destroy(gameObject);

        //revive a duck
        Instantiate(duck, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
