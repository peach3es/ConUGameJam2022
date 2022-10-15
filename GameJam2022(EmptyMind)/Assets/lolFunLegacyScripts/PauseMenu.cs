using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _pauseMenu;
    [SerializeField]
    private bool _pause;
    [SerializeField]
    private float _currentTimeScale;
    private void Start()
    {
        Time.timeScale = 1;
    }


    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Debug.Log(" GetKeyDown Escape");
            _pause = !_pause;
        }


        if (_pause)
        {
            Debug.Log(" true");
            if (Time.timeScale > 0)
            {
                _currentTimeScale = Time.timeScale;
            }
            Cursor.visible = true;
            Time.timeScale = 0;
            _pauseMenu.SetActive(true);
        }
        else
        {
            Debug.Log("false :( ");
            Cursor.visible = false;
            if (Time.timeScale == 0)
            {
                Time.timeScale = _currentTimeScale;
            }
            _pauseMenu.SetActive(false);
        }

    }


    public void ResumeGame()
    {
        _pause = false;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
        
    }
}
