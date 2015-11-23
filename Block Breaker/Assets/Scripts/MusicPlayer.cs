using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{

    static MusicPlayer instance = null;
    
    // Use this for initialization
    void Start()
    {
        if (instance != null)
        {
            Debug.Log("Duplicate Music Player self-destructing");
            Destroy(this.gameObject);
        }
        else
        {
            GameObject.DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
