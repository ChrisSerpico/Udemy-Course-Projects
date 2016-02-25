using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    public AudioClip crack;
    public Sprite[] hitSprites;
    public static int breakableCount = 0;
    public GameObject smoke;

    private LevelManager levelManager;
    private int maxHits;
    private int timesHit;
    bool isBreakable;

	// Use this for initialization
	void Start () {
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        maxHits = hitSprites.Length + 1;
        
        // Keep track of breakable brick count
        isBreakable = (this.tag == "Breakable");
        if (isBreakable)
        {
            breakableCount++;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position);
        if (isBreakable)
        {
            HandleHits();
        }
    }

    void HandleHits()
    {
        timesHit++;
        if (timesHit >= maxHits)
        {
            breakableCount--;
            MakeSmoke();
            levelManager.BrickDestroyed();
            Destroy(gameObject);
        }
        else
        {
            LoadSprite();
        }
    }

    void MakeSmoke()
    {
        GameObject mySmoke = (GameObject)Instantiate(smoke, gameObject.transform.position, Quaternion.identity);
        mySmoke.GetComponent<ParticleSystem>().startColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    void LoadSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Missing sprite for block " + this + " at index " + spriteIndex);
        }
    }

    /*
    void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }
    */
}
