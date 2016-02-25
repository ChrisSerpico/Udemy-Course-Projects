using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
    public void LoadLevel(string name)
    {
        Debug.Log("Level load requested for: " + name);
        Application.LoadLevel(name);
    }

    public void LoadLevel(int index)
    {
        Debug.Log("Level load requested for level with index " + index);
        Application.LoadLevel(index);
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
