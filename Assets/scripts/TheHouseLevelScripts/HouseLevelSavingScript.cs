using System.Collections;
using UnityEngine;
//using System.IO;
using SaveData;
using TMPro;
using UnityEngine.UI;
using SavesPath;

public class HouseLevelSavingScript : MonoBehaviour
{
    public GameObject Pausemenu;
    public GameObject ConfirmationsTab;
    private PlayerData datas;
    public TextMeshProUGUI LevelName;
    public GameObject SavedGamesFilesList;
    public GameObject LoadGamesFilesList;
    public TextMeshProUGUI ControlsTab;
    public TextMeshProUGUI ObjectivesTab;
    public Image SavingIcon;
    SaveFileLoader Loader;
    public static bool isPauseMenuEnabled;
    public GameObject CloseButton;

    public AudioSource AmbienceSource;
    // Start is called before the first frame update

    void Start()
    {
        CloseButton.GetComponent<Image>().color = new Color32(255,255,255,0);
        CloseButton.GetComponent<Button>().enabled = false;
        SavingIcon.enabled = false;
        datas = new PlayerData();
        Loader = new SaveFileLoader();
        
        SaveFile();
        LevelName.text = "\"" + datas.QuestName + "\"" + ",\n" + datas.LevelName;
        LevelName.color = new Color32(255, 255, 255, 255);
        Pausemenu.transform.GetChild(9).GetComponent<TextMeshProUGUI>().text = "\"" + datas.QuestName + "\"" + ",\n" + datas.LevelName ;
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSecondsRealtime(2f);
        LevelName.color -= new Color32(0,0,0,1);    
    }


    IEnumerator WaitForSaveIcon()
    {
        SavingIcon.enabled = true;
        yield return new WaitForSecondsRealtime(3f);
        SavingIcon.enabled = false;
    }
    // Update is called once per frame
    void Update()
    {
        AmbienceSource.volume = SettingsVariable.GetEnvironmentalAmbienceVolume();


        if(HouseScript.ShouldSkipSequence)
            Pausemenu.transform.GetChild(9).GetComponent<TextMeshProUGUI>().text = "\"" + datas.QuestName + "\"" + ",\n" + datas.LevelName + "\n" + ObjectivesTab.text;

        //print(Pausemenu.transform.GetChild(7));
        //print(datas);
        //print(ObjectivesTab);

        if (LevelName.color.a > 0)
            StartCoroutine(WaitTime());

        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(WaitForSaveIcon());
            SaveFile();        
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Time.timeScale = 1f;
            Loader.LoadFromAnySceneSaveFile(3);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPauseMenuEnabled)
            {
                ControlsTab.color = new Color32(255, 255, 255, 0);
                ObjectivesTab.color = new Color32(255, 255, 255, 0);
                isPauseMenuEnabled = true;
                Time.timeScale = 0f;
                Pausemenu.SetActive(true);

                CloseButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                CloseButton.GetComponent<Button>().enabled = true;
            }
            else
            {
                ResumeGame();
            }
        }

        //print(gameObject.GetComponent<HouseScript>().isSequenceOn);
    }

    public void ResumeGame()
    {
        CloseButton.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
        CloseButton.GetComponent<Button>().enabled = false;

        isPauseMenuEnabled = false;
        Time.timeScale = 1f;
        Pausemenu.SetActive(false);
        ConfirmationsTab.SetActive(false);
        SavedGamesFilesList.SetActive(false);
        LoadGamesFilesList.SetActive(false);
    }
    public void SaveInGameFile()
    {
        StartCoroutine(WaitForSaveIcon());
        print("saved in a game file");
        datas.LevelName = "Darker Unsar";
        datas.QuestName = "An Unexpected Guest";
        datas.LevelIndex = 3;
        datas.SubLevelIndex = 0;
        datas.hasStartedSequence = false;
        datas.numberOfBlessingsLeft = DinoController.GetNumberofBlessingsLeft();
        datas.SuperSprintWaitingTimer = 181f;
        if (gameObject.GetComponent<HouseScript>().isSequenceOn)
            datas.isHouseSequenceOver = false;
        else
            datas.isHouseSequenceOver = true;


        string SaveTimeText = JsonUtility.ToJson(datas);
        string Location = SavesDirectoryPath.WindowsSavesFolderPath + "/SavesFolder/SaveFile" + SaveFileButton.name +".data";
        //File.WriteAllText(Location, SaveTimeText);
        SaveFileLoader.BinarySerializer(SaveTimeText, Location);
    }

    public void SaveFile()
    {
        print("saved in Quick Save game file");
        datas.LevelName = "Darker Unsar";
        datas.QuestName = "An Unexpected Guest";
        datas.LevelIndex = 3;
        datas.SubLevelIndex = 0;
        datas.hasStartedSequence = false;
        datas.numberOfBlessingsLeft = DinoController.GetNumberofBlessingsLeft();
        datas.SuperSprintWaitingTimer = 181f;
        if (gameObject.GetComponent<HouseScript>().isSequenceOn)
            datas.isHouseSequenceOver = false;
        else
            datas.isHouseSequenceOver = true;

        string SaveTimeText = JsonUtility.ToJson(datas);
        string Location = SavesDirectoryPath.WindowsSavesFolderPath + "/SavesFolder/QuickSaveFile.data";
        //File.WriteAllText(Location, SaveTimeText);
        SaveFileLoader.BinarySerializer(SaveTimeText, Location);
    }    
}
