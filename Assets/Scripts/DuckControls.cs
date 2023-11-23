using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckControls : MonoBehaviour
{
    private float maxDistance = 3.5f; //max distance a duck can travel to still be in the pond

    private float maxGhostDistance = 7f; //max position where a ghost duck can be spawned

    public float range = 0.5f;  //max distance between the duck and the next destination point before it is reset

    public float speed = 2f;

    private Vector3 destination; //point that the duck is trying to arrive at

    public bool facingLeft; //duck sprite orientation

    private Rigidbody2D rb;

    private GameObject player;

    public GameObject ghostDuck;

    public AudioSource duckSound;

    void Start()
    {
        //get player object
        player = GameObject.FindGameObjectWithTag("Player");

        facingLeft = true;

        rb = transform.GetComponent<Rigidbody2D>();

	    SetNewDestination();
        
    }

    void Update()
    {
	    transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);        
       
        if(Vector3.Distance(transform.position, destination) < range)
	    {
		    SetNewDestination();
	    }

        float direction = destination.x - transform.position.x;

        //flip the sprite if the direction of movement has changed
        if(facingLeft && direction >= 0.1f)
        {
            facingLeft = false;
            Flip();
        }
        else if(!facingLeft && direction <= 0.1f)
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

    private void SetNewDestination()
    {
 	    destination = new Vector3(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance), transform.position.z);
    }

    private void OnCollisionEnter2D(Collision2D col)
    { 
        if (col.gameObject.tag == "Bullet")
        {
            //play duck hit sound
            duckSound.Play();

            //destroy the bullet that collided with the duck
            Destroy(col.gameObject);

            Color oldC = gameObject.GetComponent<SpriteRenderer>().color;

            if (oldC.a > 0.3)
            {
                //duck still has lives, increase the transparency of the sprite
                Color newC = new Color(oldC.r, oldC.g, oldC.b, oldC.a - 0.4f);

                gameObject.GetComponent<SpriteRenderer>().color = newC;

            }
            else
            {
                //the duck has no lives left so destroy
                Destroy(gameObject);

                //spawn new ghost duck
                Vector3 location = NewSpawnLocation();
                Instantiate(ghostDuck, location, Quaternion.identity);
            }
        }

    }

    private Vector3 NewSpawnLocation()
    {
        Vector3 location = new Vector3(Random.Range(-maxGhostDistance, maxGhostDistance), Random.Range(-maxGhostDistance, maxGhostDistance), 0);

        //check that location is not too close to the player
        if (Vector3.Distance(player.transform.position, location) < 3)
        {
            location = new Vector3(location.x + 3, location.y + 3, 0);
        }

        return location;

    }
}
