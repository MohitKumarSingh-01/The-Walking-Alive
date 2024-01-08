using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePauseMenu : MonoBehaviour
{
    #region Singleton
    public static GamePauseMenu instance;
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }

    }
    #endregion

    public GameObject pauseMenuUi;
    public AudioSource backgroundAudio;

    public bool isPaused = false;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && MouseLook.instance.openPanel == false)
        {
            MouseLook.instance.openPanel = true;
            isPaused = true;
            Time.timeScale = 0.0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            pauseMenuUi.SetActive(true);
            backgroundAudio.enabled = false;
        }

    }
	public void ResumeGame () 
	{
        MouseLook.instance.openPanel = false;
        isPaused = false;
		Time.timeScale = 1.0f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
		pauseMenuUi.SetActive(false);
        backgroundAudio.enabled = true;
	}
  }

