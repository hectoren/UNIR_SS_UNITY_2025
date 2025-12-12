using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] GameObject gameOverUI;
    [SerializeField] GameObject pauseUI;

    public bool IsPaused = false;

    private void Awake()
    {
        Instance = this;    
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0f;
        MusicController.Instance.PauseMusic();
    }
   
    public void TogglePause()
    {
        if (IsPaused)
            Resume();
        else
            Pause();
    }

    public void Pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        MusicController.Instance.PauseMusic();
        IsPaused = true;    
    }

    public void Resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        MusicController.Instance.ResumeMusic();
        IsPaused = false;   
    }

}
