using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;


public class LoadLevel : MonoBehaviour 
{
    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    public void LoadScene () 
	{
        SceneManager.LoadScene("Gameplay");
    }
	
	public void MainMenu () 
	{
		Time.timeScale = 1.0f;
		SceneManager.LoadScene("MainMenu");
	}
	
	public void ApplicationExit ()
	{
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
	}
	
}