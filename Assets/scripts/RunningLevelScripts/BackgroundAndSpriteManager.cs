//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class BackgroundAndSpriteManager : MonoBehaviour
{
    public GameObject Level1BackgroundSprites;
    public GameObject Level2BackgroundSprites;
    public GameObject Level3BackgroundSprites;

    public static string LevelLocationName;
    public static string LevelQuestName;

    public static bool CanChange = false;
    public static int currentLevelIndex = 1;
    public static int GameScore = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CanChange)
        {
            CanChange = false;
            gameObject.GetComponent<DinoController>().SubLevelIndex = currentLevelIndex;
            gameObject.GetComponent<DinoController>().SetGameScore(GameScore);
            ChangeTheBackgroundSprites();
            print("the ambience script will be triggered here");
        }
    }

    public void ChangeTheBackgroundSprites()
    {
        
        if (currentLevelIndex == 1)
        {
            Level1BackgroundSprites.SetActive(true);
            Level2BackgroundSprites.SetActive(false);
            Level3BackgroundSprites.SetActive(false);
        }
        else if (currentLevelIndex == 2)
        {
            Level1BackgroundSprites.SetActive(false);
            Level2BackgroundSprites.SetActive(true);
            Level3BackgroundSprites.SetActive(false);
        }
        else if(currentLevelIndex == 3)
        {
            Level1BackgroundSprites.SetActive(false);
            Level2BackgroundSprites.SetActive(false);
            Level3BackgroundSprites.SetActive(true);
        }
    }

}
