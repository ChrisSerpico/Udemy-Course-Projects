using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour 
{

    public float autoLoadTime;
    
    void Start()
    {
        Invoke("LoadNextLevel", autoLoadTime);
    }
    
    public void LoadLevel(string name)
    {
        Debug.Log("Level load requested for: " + name);
        SceneManager.LoadScene(name);
    }

    public void LoadLevel(int index)
    {
        Debug.Log("Level load requested for level with index " + index);
        SceneManager.LoadScene(index);
    }

    public void QuitRequest()
    {
        Debug.Log("Quit game request received");
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        LoadLevel(Application.loadedLevel + 1);
    }
}
