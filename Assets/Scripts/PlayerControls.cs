using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    private float hInput;
    private float vInput;

    public bool won = false; 

    private float speed = 3.5f;

    void Update()
    {
		//get keyboard input
        hInput = Input.GetAxis("Horizontal");
		vInput = Input.GetAxis("Vertical");

		if(!won)
		{
			transform.Translate(hInput * speed * Time.deltaTime, vInput * speed * Time.deltaTime, transform.position.z);
			CheckWinCond();
		}

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadScene(0);
        }
    }

    private void CheckWinCond()
    {
		//checks if the win conditions have been met
		GameObject[] ducksAlive = GameObject.FindGameObjectsWithTag("Duck");
		if(ducksAlive.Length <= 0)
		{
			Time.timeScale = 0;
			won = true;
			SceneManager.LoadScene(3, LoadSceneMode.Additive);
		}

    } 
}
