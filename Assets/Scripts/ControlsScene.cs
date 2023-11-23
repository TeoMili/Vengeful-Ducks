using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlsScene : MonoBehaviour
{
   public Button backButton;

   void Start()
   {
		backButton.onClick.AddListener(BackToTitle);
   }

   private void BackToTitle()
   {
		//reactivate UI elements
		GameObject canvas = GameObject.FindGameObjectWithTag("MasterCanvas");
		canvas.GetComponent<TitleScreen>().ReactivateUI();
		SceneManager.UnloadScene("Controls");
   }
}
