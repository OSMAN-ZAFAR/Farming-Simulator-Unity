
using UnityEngine;

public class UISoundManagerOur : MonoBehaviour
{
    public static UISoundManagerOur Instance;
    public AudioSource audioSource;
    public AudioClip clickSound;
    public AudioSource bgMusic;
    void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayClick()
    {
        if (clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    } 
    public void MusicOn()
    {
        if (!bgMusic .isPlaying)
        {
            bgMusic.Play();
            print("on");
        }

    } public void MusicOf()
    {
        if (bgMusic.isPlaying)
        {
            bgMusic.Stop();
            print("off");
        }

    }

}
