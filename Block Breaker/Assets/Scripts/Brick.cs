using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    public AudioClip crack;
    public Sprite[] hitSprites;
    public static int breakableCount = 0; 

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
            levelManager.BrickDestroyed();
            Destroy(gameObject);
        }
        else
        {
            LoadSprite();
        }
    }

    void LoadSprite()
    {
        int spriteIndex = timesHit - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    }

    // TODO remove this method once we can actually win
    void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }
}
