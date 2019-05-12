using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour {

    public Canvas pause;

    private void Awake()
    {
        Continue();
    }

    public void Exit()
    {
        SceneManager.LoadScene(1);
        Continue();
    }

    public void Continue()
    {
        if (Time.timeScale == 0f)
            Time.timeScale = 1f;

        pause.gameObject.SetActive(false);
    }
    public void Restart()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

        Continue();
    }

    void PauseGame()
    {
        if (Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
            pause.gameObject.SetActive(true);
        }
        else if (Time.timeScale == 0f)
            Continue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseGame();
    }
}
