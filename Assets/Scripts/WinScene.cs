using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinScene : MonoBehaviour
{
   public Button backButton;

   void Start()
   {
  	    backButton.onClick.AddListener(BackToMain);
   }

   void BackToMain()
   {
	    SceneManager.LoadScene(0);
   }
}
