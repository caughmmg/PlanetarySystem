using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public static bool GameIsQuarter = false;
    public static bool GameIsHalf = false;

    public GameObject pauseMenuUI;

        void Update()
    {
        PauseCheck();
        QuarterCheck();
        HalfCheck();

    }//End Update

    private void HalfCheck()
    {
        if (Input.GetKeyDown("2"))
        {
            if (GameIsHalf == false)
            {
                HalfSpeed();
            }
            else
            {
                Resume();
            }
        }
    }

    private void QuarterCheck()
    {
        if (Input.GetKeyDown("1"))
        {
            if (GameIsQuarter == false)
            {
                QuarterSpeed();
            }
            else
            {
                Resume();
            }
        }
    }

    private void PauseCheck()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused == false)
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        GameIsQuarter = false;
        GameIsHalf = false;
    }

    void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    void QuarterSpeed()
    {
        Time.timeScale = .25f;
        GameIsQuarter = true;
    }

    void HalfSpeed()
    {
        Time.timeScale = .5f;
        GameIsHalf = true;
    }

}
