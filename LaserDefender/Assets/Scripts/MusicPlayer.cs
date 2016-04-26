using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{

    static MusicPlayer instance = null;

    public AudioClip startClip;
    public AudioClip gameClip;
    public AudioClip endClip;

    private AudioSource music;
    
    
    // Use this for initialization
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Debug.Log("Duplicate Music Player self-destructing");
            Destroy(this.gameObject);
        }
        else
        {
            GameObject.DontDestroyOnLoad(this.gameObject);
            instance = this;
            music = GetComponent<AudioSource>();
            music.clip = startClip;
            music.loop = true;
            music.Play();
        }
    }

    void OnLevelWasLoaded(int level)
    {
        Debug.Log("Music Player: Loaded level " + level);
        music.Stop();

        if (level == 0)
        {
            music.clip = startClip;
        }
        if (level == 1)
        {
            music.clip = gameClip;
        }
        if (level == 2)
        {
            music.clip = endClip;
        }

        music.Play();
    }
}
