using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
