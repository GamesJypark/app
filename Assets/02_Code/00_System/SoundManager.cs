using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager soundManager = null;
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    private void Awake()
    {
        if(soundManager == null)
        {
            soundManager = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void HP34()
    {
        audioSource.clip = audioClips[2];
    }
    public void HP12()
    {
        audioSource.clip = audioClips[3];
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch(scene.buildIndex)
        {
            case 0:
                audioSource.clip = audioClips[0];
                audioSource.Play();
                break;
            case 2:
                audioSource.clip = audioClips[1];
                audioSource.Play();
                break;
        }
        
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
