//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreenLinker : MonoBehaviour
{
    public static int recievingIndex = 0;
    public static int DestinationIndex = 0;
    public static int subLevelIndex = 0;
    public static int GameScore = 0;
    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeTheScene()
    {
        SceneManager.UnloadSceneAsync(1);
        SceneManager.LoadScene(DestinationIndex);
        BackgroundAndSpriteManager.currentLevelIndex = subLevelIndex;                        
        BackgroundAndSpriteManager.CanChange = true;            
    }
    
}
