using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
//using System.IO;
using UnityEngine.UI;
using SaveData;
using SavesPath;

public class SaveGameScript : MonoBehaviour
{
    SaveFileLoader Loader;
    public Image TransitionScreen;
    public GameObject MusicsObject;
    public Image SavingImage;
    private PlayerData datas;
    private DinoController Player;
    // this saving script is a local saving script intended to for the running levels only but the implementation of class object player data is to be applicable
    // to all levels and yes except for the Loading screen scene

    //bool StartTimer = false;
    //bool DoFadeOut = false;
    //bool DoFadeIn = true;
    //float FadeTimer = 0f;

    private void Start()
    {
        Player = FindObjectOfType<DinoController>();
        datas = new PlayerData();
        Loader = new SaveFileLoader();
        SavingImage.color = new Color32(255, 255, 255,0);
    }

    // Update is called once per frame
    void Update()
    {
        // the quick save logic and trigger is here
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveFile();
        }
        // the Quick Load Logic is Right here
        else if (Input.GetKeyDown(KeyCode.L))   
        {            
            Time.timeScale = 1f;
            Loader.LoadFromAnySceneSaveFile(2);
        }
    }
    IEnumerator FadeInFadeOut()
    {
            SavingImage.color += new Color32(0,0,0,255);
        yield return new WaitForSecondsRealtime(3f);
            SavingImage.color -= new Color32(0,0,0,255);
    }

    public void SaveInGameFile()
    {
        if (!gameObject.GetComponent<DinoController>().GetGameOverFlag())
        {
            StartCoroutine(FadeInFadeOut());
            datas.LevelIndex = 2; // gets the scene Index
            datas.SubLevelIndex = gameObject.GetComponent<DinoController>().SubLevelIndex; // gets the SubLevel Index
            datas.GameScore = gameObject.GetComponent<DinoController>().GetScore(); // Gets The Score
            datas.isHouseSequenceOver = false;
            datas.hasStartedSequence = false;
            datas.numberOfBlessingsLeft = DinoController.GetNumberofBlessingsLeft();
            datas.MusicIndex = MusicsScript.MusicIndex;
            datas.SuperSprintWaitingTimer = DinoController.SuperSprintWaitingTimerSharable;
            datas.ConversationFlag = DinoController.ConversationFlag;
            datas.SingleDialogueFlag = DinoController.SingleDialogueFlag;

            if (datas.SubLevelIndex == 1)
            {
                datas.LevelName = "Red Sands";
                datas.QuestName = "Fall of An Evil";
            }
            else if (datas.SubLevelIndex == 2)
            {
                datas.LevelName = "Darker Unsar";
                datas.QuestName = "Into A Dark Trap";
            }
            else
            {
                datas.LevelName = "Green Mists";
                datas.QuestName = "Off With The Scheme";
            }
            // after initializing every attirbute we need to convert the Object into json file compatible text
            string SaveTimeText = JsonUtility.ToJson(datas);
            string Location = SavesDirectoryPath.WindowsSavesFolderPath + "/SavesFolder/SaveFile" + SaveFileButton.name +  ".data";
            print(Location);
            //File.WriteAllText(Location, SaveTimeText);

            Location = SavesDirectoryPath.WindowsSavesFolderPath + "/SavesFolder/SaveFile" + SaveFileButton.name + ".data";

            SaveFileLoader.BinarySerializer(SaveTimeText,Location);
            //Time.timeScale = 0f;
        }
        else
        {
            print("cant do anything the game is over");
        }
    }


    public void SaveFile()
    {
        if (!gameObject.GetComponent<DinoController>().GetGameOverFlag())
        {
            StartCoroutine(FadeInFadeOut());
            datas.LevelIndex = 2; // gets the scene Index
            datas.SubLevelIndex = gameObject.GetComponent<DinoController>().SubLevelIndex; // gets the SubLevel Index
            datas.GameScore = gameObject.GetComponent<DinoController>().GetScore(); // Gets The Score
            datas.isHouseSequenceOver = false;
            datas.hasStartedSequence = false;
            datas.numberOfBlessingsLeft = DinoController.GetNumberofBlessingsLeft();
            datas.MusicIndex = MusicsScript.MusicIndex;
            datas.SuperSprintWaitingTimer = DinoController.SuperSprintWaitingTimerSharable;
            datas.ConversationFlag = DinoController.ConversationFlag;
            datas.SingleDialogueFlag = DinoController.SingleDialogueFlag;
            if (datas.SubLevelIndex == 1)
            {
                datas.LevelName = "Red Sands";
                datas.QuestName = "Fall of An Evil";
            }
            else if (datas.SubLevelIndex == 2)
            {
                datas.LevelName = "Darker Unsar";
                datas.QuestName = "Into A Dark Trap";
            }
            else
            {
                datas.LevelName = "Green Mists";
                datas.QuestName = "Off With The Scheme";
            }
            // after initializing every attirbute we need to convert the Object into json file compatible text
            string SaveTimeText = JsonUtility.ToJson(datas);
            string Location = SavesDirectoryPath.WindowsSavesFolderPath + "/SavesFolder/QuickSaveFile.data";
            print(Location);
            //File.WriteAllText(Location, SaveTimeText);

            //Location = SavesDirectoryPath.WindowsSavesFolderPath + "/SavesFolder/QuickSaveFile.data";

            SaveFileLoader.BinarySerializer(SaveTimeText, Location);
            //Time.timeScale = 0f;
        }
        else
        {
            print("cant do anything the game is over");
        }

    }

    /*
    Image FadeIn(Image img, byte intensity)
    {
        if (img.color.a < 255)
            img.color += new Color32(0,0,0,intensity);
        return img;
    }
    Image FadeOut(Image img, byte intensity)
    {
        if (img.color.a > 0)
            img.color -= new Color32(0, 0, 0, intensity);
        return img;
    }
   */

}
namespace SaveData
{
    public class PlayerData
    {
        public int LevelIndex = 0;
        public int SubLevelIndex = 0;
        public int GameScore = 0;
        public int numberOfBlessingsLeft = 0;
        public int MusicIndex = 0;
        public string LevelName;
        public string QuestName;
        public float SuperSprintWaitingTimer;
        // running Level Conversation Attributes
        public bool ConversationFlag = false;
        public bool SingleDialogueFlag = false;

        // level 2 saves
        public bool isHouseSequenceOver = false;
        // level 3 
        public bool hasStartedSequence = false;
    }
}

