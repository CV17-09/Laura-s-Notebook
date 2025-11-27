using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneSlideshow : MonoBehaviour
{
    [Header("UI Image that displays the cutscene frames")]
    public Image cutsceneImage;

    [Header("All cutscene sprites in order")]
    public Sprite[] slides;

    [Header("Scene to load after last slide")]
    public string nextSceneName;

    private int currentIndex = 0;

    void Start()
    {
        if (slides != null && slides.Length > 0)
        {
            cutsceneImage.sprite = slides[0];
        }
        else
        {
            Debug.LogError("CutsceneSlideshow: No slides assigned!");
        }
    }

    void Update()
    {
        // Click left mouse button or press Space to advance the slide
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            NextSlide();
        }
    }

    void NextSlide()
    {
        currentIndex++;

        if (currentIndex < slides.Length)
        {
            // Show next image
            cutsceneImage.sprite = slides[currentIndex];
        }
        else
        {
            // End of cutscene → load next scene
            SceneManager.LoadScene(nextSceneName);
        }
    }
}

