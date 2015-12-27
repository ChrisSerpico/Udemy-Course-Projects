using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

    private int maxHits;
    private int timesHit;

    public Sprite[] hitSprites;

    private LevelManager levelManager;

	// Use this for initialization
	void Start () {
        timesHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        maxHits = hitSprites.Length + 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        bool isBreakable = (this.tag == "Breakable");

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
