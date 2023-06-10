using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    private const string LevelIndexKey = "LevelIndex";
    public Controls Controls;
    public GameObject DeathMenu;
    public GameObject WinMenu;
    public enum State
    {
        Playing,
        Won,
        Loss
    }

    public State CurrentState { get; private set; }

    public void OnPlayerDied()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Loss;
        Controls.enabled = false;
        Debug.Log("Game Over!!!");
        DeathMenu.SetActive(true);
    }

    public void OnPlayerReachFinish()
    {
        if (CurrentState != State.Playing) return;
        CurrentState = State.Won;
        Controls.enabled = false;
        Debug.Log("You won!");
        WinMenu.SetActive(true);
    }

    public int LevelIndex
    {
        get => PlayerPrefs.GetInt(LevelIndexKey, 0);
        private set
        {
            PlayerPrefs.SetInt(LevelIndexKey, value);
            PlayerPrefs.Save();
        }
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadNextLevel()
    {
        LevelIndex++;
        ReloadLevel();
    }

    public void ClearPrefs()
    {
        PlayerPrefs.DeleteAll();
        ReloadLevel();
    }

    public void SetDeathMenuActive()
    {
        DeathMenu.SetActive(true);
    }

    public void SetWinMenuActive()
    {
        WinMenu.SetActive(true);
    }

    //private float delay = 1f;
    private void Update()
    {
        /*if(CurrentState == State.Loss)
        {
            if (delay > 0f) { delay -= MenuSpeedDelay * 0.1f; }
            if (delay <= 0f) { DeathMenu.SetActive(true); }
        }
        if(CurrentState == State.Won)
        {
            if (delay > 0f) { delay -= MenuSpeedDelay * 0.1f; }
            if (delay <= 0f) { WinMenu.SetActive(true); }
        }*/
    }
}
