//using System.Collections;
//using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using SaveData;
using SavesPath;

public class SaveFileButton : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    public TextMeshProUGUI SavedGameData;
    public Image ScreenShot;

    public Sprite[] LevelScreenShots;


    public static string name;

    private Transform ButtonParent;
    private static bool IsLoading = false;
    private static bool IsSaving = false;

    void Start()
    {
        ButtonParent = gameObject.transform.parent;
        ScreenShot.sprite = null;
        ScreenShot.enabled = false;
        // inorder to get the screen shots straight from the file we need to create a Resource Folder so That Unity can take all the demanded
        // resources or Assets from that folder 
        // Now we can just Use the Resource from the Resources Folder but the folder must be inside the Assets Main directory of the Project file
        // We can have multiple Resource Folders No Problem 
        // We Can Load Assets one time or the entire folder of Matching type ie, GameObjects , Sprites, Vectors etc you got the point
        // just make sure that the Type of the Recieving Variable and from the sender file are same just dont let it be different or it will always return null
        // We can Load Assets One at a time or All at once by Resources.Load<Generic type>() or Resources.LoadAll<Generic type>()  
        // Difference is One returns a single Object another returns An Array of it
        LevelScreenShots = Resources.LoadAll<Sprite>("ScreenShots");
        //print("Loaded the Image");
        SavedGameData.text = "\0";
    }


    /*
    public void SaveOrLoadGameAction()
    {
        if (IsLoading && !IsSaving)
        {
            // Load Here    
        }
        else if (!IsLoading && IsSaving)
        {
            // Save Here
        }
        DefaultMode();
    }
    */
    public static void SaveMode()
    {
        IsSaving = true;
        IsLoading = false;
    }

    public static void LoadMode()
    {
        IsLoading = true;
        IsSaving = false;
    }

    public static void DefaultMode()
    {
        IsLoading = false;
        IsSaving = false;
    }

    private void CheckLevels(int LevelIndex,int SubLevelIndex)
    {
        if (LevelIndex == 2)
        {
            ScreenShot.enabled = true;
            if (SubLevelIndex == 1)
                ScreenShot.sprite = LevelScreenShots[1];
            else if (SubLevelIndex == 2)
                ScreenShot.sprite = LevelScreenShots[2];
            else if (SubLevelIndex == 3)
                ScreenShot.sprite = LevelScreenShots[3];
            else
                ScreenShot.enabled = false;
        }
        else
        {
            if (LevelIndex == 3)
            {
                ScreenShot.enabled = true;
                ScreenShot.sprite = LevelScreenShots[0];
            }
            else if (LevelIndex == 4)
            {
                ScreenShot.enabled = true;
                ScreenShot.sprite = LevelScreenShots[4];
            }
            else
                ScreenShot.enabled = false;
        }    
    }

    public void OnPointerEnter(PointerEventData data)
    {

        PlayerData playerdata = new PlayerData();
        name = transform.name;
        ScreenShot.color = new Color32(255,255, 255, 255);
        //print("Parent Name:- " + ButtonParent.transform.name);
        //print("name:- " + name + " is selected");
        print("the path will be selected check :- " + SavesDirectoryPath.WindowsSavesFolderPath + "/SavesFolder/SaveFile" + name + ".data");

        print(ButtonParent.transform.name == "LoadFileScreen");

        if (File.Exists(SavesDirectoryPath.WindowsSavesFolderPath + "/SavesFolder/SaveFile" + name + ".data"))
        {
            print(SavesDirectoryPath.WindowsSavesFolderPath + "/SavesFolder/SaveFile" + name + ".data" + "is selected");
            //string parsedData = File.ReadAllText(SavesDirectoryPath.WindowsSavesFolderPath + "/SavesFolder/SaveFile" + name + ".data");
            string parsedData = SaveFileLoader.BinaryDeserializer(SavesDirectoryPath.WindowsSavesFolderPath + "/SavesFolder/SaveFile" + name + ".data");
            //print(parsedData);
            if (parsedData != null)
            {
                playerdata = JsonUtility.FromJson<PlayerData>(parsedData);
                if (playerdata != null)
                {
                    SavedGameData.text = "Level Name:- " + playerdata.LevelName + "\n Quest Name:- " + playerdata.QuestName + "\n Score:- " + playerdata.GameScore + "\n Number of blessings left:- " + playerdata.numberOfBlessingsLeft + "\n";
                    CheckLevels(playerdata.LevelIndex, playerdata.SubLevelIndex);
                }
                else
                {
                    if (ButtonParent.transform.name.Contains("Load"))
                    {
                        SavedGameData.text = "Sorry The File Seems to be Corrupted :(";
                        gameObject.GetComponent<Button>().enabled = false;
                    }
                }
            }
            else
            {
                if (ButtonParent.transform.name.Contains("Load"))
                {
                    SavedGameData.text = "Sorry The File Seems to be Empty :(";
                    gameObject.GetComponent<Button>().enabled = false;
                }
            }
        }
        else if (File.Exists(SavesDirectoryPath.WindowsSavesFolderPath + "/SavesFolder/QuickSaveFile.data"))
        {
            if (gameObject.transform.name.Contains("Quick"))
            {
                print(SavesDirectoryPath.WindowsSavesFolderPath + "/SavesFolder/QuickSaveFile.data " + "is selected");
                //string parsedData = File.ReadAllText(SavesDirectoryPath.WindowsSavesFolderPath + "/SavesFolder/QuickSaveFile.data");
                string parsedData = SaveFileLoader.BinaryDeserializer(SavesDirectoryPath.WindowsSavesFolderPath + "/SavesFolder/QuickSaveFile.data");
                //print(parsedData);
                if (parsedData != null)
                {
                    playerdata = JsonUtility.FromJson<PlayerData>(parsedData);
                    if (playerdata != null)
                    {
                        SavedGameData.text = "Level Name:- " + playerdata.LevelName + "\n Quest Name:- " + playerdata.QuestName + "\n Score:- " + playerdata.GameScore + "\n Number of blessings left:- " + playerdata.numberOfBlessingsLeft + "\n";
                        CheckLevels(playerdata.LevelIndex, playerdata.SubLevelIndex);
                    }
                    else
                    {
                        if (ButtonParent.transform.name.Contains("Load"))
                        {
                            SavedGameData.text = "Sorry The File Seems to be Corrupted :(";
                            gameObject.GetComponent<Button>().enabled = false;
                        }
                    }
                }
                else
                {
                    if (ButtonParent.transform.name.Contains("Load"))
                    {
                        SavedGameData.text = "Sorry The File Seems to be Empty :(";
                        gameObject.GetComponent<Button>().enabled = false;
                    }
                }
            }
            else
            {
                if (ButtonParent.transform.name.Contains("Load"))
                {
                    SavedGameData.text = "Sorry The File is not Found :(";
                    gameObject.GetComponent<Button>().enabled = false;
                }
            }
        }
        else
        {
            if (ButtonParent.transform.name.Contains("Load"))
            {
                SavedGameData.text = "Sorry The File is not Found :(";
                gameObject.GetComponent<Button>().enabled = false;
            }
        }
    }
    public void OnPointerExit(PointerEventData data)
    {
        gameObject.GetComponent<Button>().enabled = true;
        ScreenShot.sprite = null;
        ScreenShot.enabled = false;
        //name = "\0";
        ScreenShot.color = new Color32(255, 255, 255, 0);
        SavedGameData.text = "\0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
