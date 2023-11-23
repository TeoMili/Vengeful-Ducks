using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
   public Button playButton;
   public Button controlsButton;
   public Button exitButton;
   public GameObject UIholder;

   void Start()
   {
		playButton.onClick.AddListener(LoadGame);
		controlsButton.onClick.AddListener(LoadControls);
		exitButton.onClick.AddListener(Exit);
   }

   void LoadGame()
   {
		SceneManager.LoadScene(2);
   }

   void LoadControls()
   {
		//deactivate UI elements and load controls scene
		UIholder.SetActive(false);
		SceneManager.LoadScene(1, LoadSceneMode.Additive);
   }

   void Exit()
   {
		#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
		#else
			Application.Quit();
		#endif
   }

   public void ReactivateUI()
   {
		UIholder.SetActive(true);
   }
}
