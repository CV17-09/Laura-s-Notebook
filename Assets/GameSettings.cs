using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSettings : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Animator animator;
    public GameObject pauseMenuUI;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        animator.Play("SlideOut");
        StartCoroutine(HideAfterAnimation());
        Time.timeScale = 1f;
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        animator.Play("SlideIn");
        Time.timeScale = 0f;
        isPaused = true;
    }

    IEnumerator HideAfterAnimation()
    {
        yield return new WaitForSecondsRealtime(0.3f);
        pauseMenuUI.SetActive(false);
    }

    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    
}
