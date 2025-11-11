using UnityEngine;
using UnityEngine.Rendering;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    public AudioClip background;
    public static AudioManager Instance;


    private void Awake()
    {
        // If an instance already exists, destroy duplicates
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // This keeps the AudioManager alive across scenes
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    public void Start()
    {
        musicSource.clip = background;
        musicSource.loop = true; // so it doesn't stop
        musicSource.Play();
    }
}
