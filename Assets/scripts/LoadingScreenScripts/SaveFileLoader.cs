
using UnityEngine.UI;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using SaveData;
using SavesPath;
using System;
//using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveFileLoader : MonoBehaviour
{
   
    PlayerData datas;
    public AudioSource ThemeSource;
    public Image LoadingScreen;
    public GameObject ConfirmationsTab;

    float FadeOutTimer = 0f;
    bool DoFadeOut = false;
    bool ExecuteCode = false;
    static int FileIndex = 0;

    
    public SaveFileLoader()
    {
        datas = new PlayerData();
    }

    private void Start()
    {
        if (ConfirmationsTab!=null)
          ConfirmationsTab.SetActive(false);
    }

    private void Update()
    {

        if (DoFadeOut)
        {   
            if (FadeOutTimer > 0f)
            {
                ExecuteCode = true;
                if (LoadingScreen != null)
                {
                    LoadingScreen.enabled = false;
                    LoadingScreen.GetComponent<Animator>().enabled = false;
                    DoFadeOut = false;
                    LoadSaveFile();
                }

            }
            else
            {
                if (LoadingScreen != null)
                {
                    LoadingScreen.enabled = true;
                    LoadingScreen.GetComponent<Animator>().enabled = true;
                    FadeOut();
                    FadeOutTimer += Time.deltaTime;
                }
 
            }
        }
    }


    private void NewGameChangeScene()
    {
        try
        {
            LoadingScreenLinker.recievingIndex = 0;
            LoadingScreenLinker.DestinationIndex = 5;
            LoadingScreenLinker.subLevelIndex = 0;
            SceneManager.LoadSceneAsync(1);
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
        catch (Exception e)
        {
            print("Cause of Exception is here:- " + e.Message);
        }
        //DoFadeOut = false;
        //FadeOutTimer = 0f;
    }



    public void LoadQuickSavedGame()
    {
        print("Load Quick saved game is called");
        //print("will load a quick saved game file");
        if (File.Exists(SavesDirectoryPath.WindowsSavesFolderPath + "SavesFolder/QuickSaveFile.data"))
        {
            Time.timeScale = 1f;
            //string ParsedData = File.ReadAllText(SavesDirectoryPath.WindowsSavesFolderPath + "SavesFolder/QuickSaveFile.data");
            string ParsedData = BinaryDeserializer(SavesDirectoryPath.WindowsSavesFolderPath + "SavesFolder/QuickSaveFile.data");
            datas = JsonUtility.FromJson<PlayerData>(ParsedData);
            print("will print deserialzied data");
            print("Deserialized data:- " + BinaryDeserializer(SavesDirectoryPath.WindowsSavesFolderPath + "SavesFolder/QuickSaveFile.data"));

            // managed all of the scene jumps through the Loading screen scene
            LoadingScreenLinker.subLevelIndex = datas.SubLevelIndex;
            LoadingScreenLinker.recievingIndex = 0;
            LoadingScreenLinker.DestinationIndex = datas.LevelIndex;
            // if jumped to a running level then respective backgrounds will be set too
            BackgroundAndSpriteManager.currentLevelIndex = datas.SubLevelIndex;
            BackgroundAndSpriteManager.GameScore = datas.GameScore;
            BackgroundAndSpriteManager.CanChange = true;
            DinoController.SetBlessingOnLoadingFile(datas.numberOfBlessingsLeft);
            MusicsScript.MusicIndex = datas.MusicIndex;
            DinoController.SuperSprintWaitingTimerSharable = datas.SuperSprintWaitingTimer;
            BackgroundAndSpriteManager.LevelLocationName = datas.LevelName;
            BackgroundAndSpriteManager.LevelQuestName = datas.QuestName;

            // for defence the scene the temple and house sequence interactions are also overseen
            TempleSequence.StartTheSequence = datas.hasStartedSequence;
            HouseScript.ShouldSkipSequence = datas.isHouseSequenceOver;


            //conversation flags
            DinoController.SingleDialogueFlag = datas.SingleDialogueFlag;
            DinoController.ConversationFlag = datas.ConversationFlag;


            // and then we make a jump
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadSceneAsync(1);
        }
        else
        {
            print("bloody start a new game moron ");
        }


    }


    public void LoadFromSavedGameFiles()
    {
        print("Load from saved game files is called");
        SaveFileButton.name = "" + FileIndex;
        //print("checking for the file");
        //print("Savefile index:- " + SaveFileButton.name);
        if (File.Exists(SavesDirectoryPath.WindowsSavesFolderPath + "SavesFolder/SaveFile" + SaveFileButton.name + ".data"))
        {
            
            Time.timeScale = 1f;
            //string ParsedData = File.ReadAllText(SavesDirectoryPath.WindowsSavesFolderPath + "SavesFolder/SaveFile" + SaveFileButton.name + ".data");
            string ParsedData = BinaryDeserializer(SavesDirectoryPath.WindowsSavesFolderPath + "SavesFolder/SaveFile" + SaveFileButton.name + ".data");
            datas = JsonUtility.FromJson<PlayerData>(ParsedData);
            print("will print deserialzied data");
            print("Deserialized data:- " + BinaryDeserializer(SavesDirectoryPath.WindowsSavesFolderPath + "SavesFolder/" + SaveFileButton.name + ".data"));

            
            // managed all of the scene jumps through the Loading screen scene
            LoadingScreenLinker.subLevelIndex = datas.SubLevelIndex;
            LoadingScreenLinker.recievingIndex = 0;
            LoadingScreenLinker.DestinationIndex = datas.LevelIndex;
            // if jumped to a running level then respective backgrounds will be set too
            BackgroundAndSpriteManager.currentLevelIndex = datas.SubLevelIndex;
            BackgroundAndSpriteManager.GameScore = datas.GameScore;
            BackgroundAndSpriteManager.CanChange = true;
            DinoController.SetBlessingOnLoadingFile(datas.numberOfBlessingsLeft);
            MusicsScript.MusicIndex = datas.MusicIndex;

            DinoController.SuperSprintWaitingTimerSharable = datas.SuperSprintWaitingTimer;
            BackgroundAndSpriteManager.LevelLocationName = datas.LevelName;
            BackgroundAndSpriteManager.LevelQuestName = datas.QuestName;

            // for defence the scene the temple and house sequence interactions are also overseen
            TempleSequence.StartTheSequence = datas.hasStartedSequence;
            HouseScript.ShouldSkipSequence = datas.isHouseSequenceOver;

            //conversation flags
            DinoController.SingleDialogueFlag = datas.SingleDialogueFlag;
            DinoController.ConversationFlag = datas.ConversationFlag;

            // and then we make a jump
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            SceneManager.LoadSceneAsync(1);
        }
        else
        {
            print("bloody start a new game moron ");
            
        }
    }
    public void ConfirmLoadQuickSavedGame()
    {
        ConfirmationsTab.SetActive(true);
        ConfirmationsTab.GetComponent<QuestionsUIScript>().ShowQuestion("Do you really want to Continue with your last save game?", LoadQuickSavedGame, StayOnTheMainMenu);
    }


    public void ConfirmContinueAction()
    {
        ConfirmationsTab.SetActive(true);
        if (CheckQuickSaveFile())
            ConfirmationsTab.GetComponent<QuestionsUIScript>().ShowQuestion("Do you really want to Continue with your last save game?", LoadSaveFile, StayOnTheMainMenu);
        else
            ConfirmationsTab.GetComponent<QuestionsUIScript>().ShowQuestion("Cannot Continue as there is quick save file available, do you want start a new game?",NewGameChangeScene,StayOnTheMainMenu);
    }

    public void ConfirmSaveFileLoadAction()
    {
        FileIndex = Int32.Parse(SaveFileButton.name);
        ConfirmationsTab.SetActive(true);
        ConfirmationsTab.GetComponent<QuestionsUIScript>().ShowQuestion("Do you really wish to load this save game file?", LoadFromSavedGameFiles, StayOnTheMainMenu);
    }
    public void StayOnTheMainMenu()
    {
        ConfirmationsTab.SetActive(false);
    }
    private bool CheckQuickSaveFile()
    {
        bool IsExisting = false;
        
        PlayerData playerdata = new PlayerData();
        if (File.Exists(SavesDirectoryPath.WindowsSavesFolderPath + "/SavesFolder/QuickSaveFile.data"))
        {
            print(SavesDirectoryPath.WindowsSavesFolderPath + "/SavesFolder/QuickSaveFile.data " + "is selected");
            string parsedData = BinaryDeserializer(SavesDirectoryPath.WindowsSavesFolderPath + "/SavesFolder/QuickSaveFile.data");

            if (parsedData != null)
            {
                playerdata = JsonUtility.FromJson<PlayerData>(parsedData);
                if (playerdata != null)
                    IsExisting = true;
                else
                    IsExisting = false;
            }
            else
                IsExisting = false;            
        }
        return IsExisting;
    }
    public void LoadSaveFile()
    {
        print("Load save file method is called");
        if (ExecuteCode)
        {
            DoFadeOut = false;
            if (File.Exists(SavesDirectoryPath.WindowsSavesFolderPath + "SavesFolder/QuickSaveFile.data"))
            {
                //string ParsedData = File.ReadAllText(SavesDirectoryPath.WindowsSavesFolderPath + "SavesFolder/QuickSaveFile.json");
                string ParsedData = BinaryDeserializer(SavesDirectoryPath.WindowsSavesFolderPath + "SavesFolder/QuickSaveFile.data");
                datas = JsonUtility.FromJson<PlayerData>(ParsedData);
                print("Deserialized data:- " + BinaryDeserializer(SavesDirectoryPath.WindowsSavesFolderPath + "SavesFolder/QuickSaveFile.data"));

                // managed all of the scene jumps through the Loading screen scene
                LoadingScreenLinker.subLevelIndex = datas.SubLevelIndex;
                LoadingScreenLinker.recievingIndex = 0;
                LoadingScreenLinker.DestinationIndex = datas.LevelIndex;
                // if jumped to a running level then respective backgrounds will be set too
                BackgroundAndSpriteManager.currentLevelIndex = datas.SubLevelIndex;
                BackgroundAndSpriteManager.GameScore = datas.GameScore;
                BackgroundAndSpriteManager.CanChange = true;
                DinoController.SetBlessingOnLoadingFile(datas.numberOfBlessingsLeft);

                DinoController.SuperSprintWaitingTimerSharable = datas.SuperSprintWaitingTimer;
                BackgroundAndSpriteManager.LevelLocationName = datas.LevelName;
                BackgroundAndSpriteManager.LevelQuestName = datas.QuestName;

                // for defence the scene the temple and house sequence interactions are also overseen
                TempleSequence.StartTheSequence = datas.hasStartedSequence;
                HouseScript.ShouldSkipSequence = datas.isHouseSequenceOver;

                //conversation flags
                DinoController.SingleDialogueFlag = datas.SingleDialogueFlag;
                DinoController.ConversationFlag = datas.ConversationFlag;

                MusicsScript.MusicIndex = datas.MusicIndex;
                // and then we make a jump
                SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
                SceneManager.LoadSceneAsync(1);
            }
            else
            {
                print("bloody start a new game moron ");
            } 
        }
        else
            DoFadeOut = true;
    }

    // this method is for Quick Load only applicable for the playable areas 
    public void LoadFromAnySceneSaveFile(int sceneIndex)
    {
        print("Load from any scene save file is called");
        if (File.Exists(SavesDirectoryPath.WindowsSavesFolderPath + "SavesFolder/QuickSaveFile.data"))
        {
            //string ParsedData = File.ReadAllText(SavesDirectoryPath.WindowsSavesFolderPath + "SavesFolder/QuickSaveFile.data");
            String ParsedData = BinaryDeserializer(SavesDirectoryPath.WindowsSavesFolderPath + "SavesFolder/QuickSaveFile.data");
            datas = JsonUtility.FromJson<PlayerData>(ParsedData);
            print("Deserialized data:- " + BinaryDeserializer(SavesDirectoryPath.WindowsSavesFolderPath + "SavesFolder/QuickSaveFile.data"));
            if (datas != null)
            {
                Time.timeScale = 1f;
                // managed all of the scene jumps through the Loading screen scene

                LoadingScreenLinker.subLevelIndex = datas.SubLevelIndex;
                LoadingScreenLinker.recievingIndex = 0;
                LoadingScreenLinker.DestinationIndex = datas.LevelIndex;
                // if jumped to a running level then respective backgrounds will be set too
                BackgroundAndSpriteManager.currentLevelIndex = datas.SubLevelIndex;
                BackgroundAndSpriteManager.GameScore = datas.GameScore;
                BackgroundAndSpriteManager.CanChange = true;
                DinoController.SetBlessingOnLoadingFile(datas.numberOfBlessingsLeft);
                MusicsScript.MusicIndex = datas.MusicIndex;

                DinoController.SuperSprintWaitingTimerSharable = datas.SuperSprintWaitingTimer;
                BackgroundAndSpriteManager.LevelLocationName = datas.LevelName;
                BackgroundAndSpriteManager.LevelQuestName = datas.QuestName;

                // for defence the scene the temple and house sequence interactions are also overseen
                TempleSequence.StartTheSequence = datas.hasStartedSequence;
                HouseScript.ShouldSkipSequence = datas.isHouseSequenceOver;


                //conversation flags
                DinoController.SingleDialogueFlag = datas.SingleDialogueFlag;
                DinoController.ConversationFlag = datas.ConversationFlag;

                // and then we make a jump
                SceneManager.UnloadSceneAsync(sceneIndex);
                SceneManager.LoadSceneAsync(1);
            }
        }
        else
        {
            print("bloody start a new game moron ");
        }
    }

    public static string LoadGameData()
    {
        print("load game data is called");
        string ParsedData;
        if (File.Exists(SavesDirectoryPath.WindowsSavesFolderPath + "SavesFolder/QuickSaveFile.data"))
        {
            //print("a file was found here");
            //ParsedData = File.ReadAllText(SavesDirectoryPath.WindowsSavesFolderPath + "SavesFolder/QuickSaveFile.data");
            ParsedData = BinaryDeserializer(SavesDirectoryPath.WindowsSavesFolderPath + "SavesFolder/QuickSaveFile.data");
        }
        else
        {
            print("there is no file here");
            ParsedData = null;
        }
        //print("return string:- " + ParsedData);
        return ParsedData;
    }

    void FadeOut()
    {
        if (ThemeSource.volume > 0)
            ThemeSource.volume -= 0.001f;
    }

    public static void BinarySerializer(string DataStream, string FilePath)
    {
        MainMenuManager.SaveSettings();

        // this line creates a new file and writes in it if the file was non existant or truncates the existing file to write the file a new
        FileStream file = new FileStream(FilePath,FileMode.Create);
        // the formatter object will allow us to format our json string to binary stream
        BinaryFormatter formatter = new BinaryFormatter();
        // here the json string is converted into the binary stream and written in the file
        formatter.Serialize(file,DataStream);
        file.Close();
    }

    public static string BinaryDeserializer(string path)
    {
        if (File.Exists(SavesDirectoryPath.WindowsSavesFolderPath + "SavesFolder/SettingsConfig.data"))
            MainMenuManager.LoadSettings();
        else
            MainMenuManager.SaveSettings();

        string DataStream = null;
        if (File.Exists(path))
        {
            FileStream file = new FileStream(path, FileMode.Open);

            BinaryFormatter formatter = new BinaryFormatter();

            DataStream = formatter.Deserialize(file) as string;
            file.Close();
        }
        
        return DataStream;
    }

}
