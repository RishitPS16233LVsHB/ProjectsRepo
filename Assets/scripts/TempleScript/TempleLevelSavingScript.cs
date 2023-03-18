using System.Collections;
using UnityEngine;
//using System.IO;
using SaveData;
using TMPro;
using UnityEngine.UI;
using SavesPath;

public class TempleLevelSavingScript : MonoBehaviour
{
    PlayerData datas;
    SaveFileLoader Loader;

    public GameObject PauseMenuUI;
    public GameObject ConfirmationsTab;
    public static bool isPauseMenuEnabled = false;
    public Image TransitionScreen;
    public TextMeshProUGUI LevelName;
    public Image SavingIcon;


    public GameObject SavedGamesList;
    public GameObject LoadSavedGamesList;

    public TextMeshProUGUI ControlsTab;
    public TextMeshProUGUI ObjectivesTab;

    public Button CloseButton;

        
    // Start is called before the first frame update
    void Start()
    {
        EarlyLevelTimer = 0f;
        CloseButton.enabled = false;
        CloseButton.GetComponent<Image>().color = new Color32(255,255,255,0);
        SavingIcon.enabled = false;
        datas = new PlayerData();
        Loader = new SaveFileLoader();
        //SaveFile();


        ControlsTab.color = new Color32(255,255,255,0);
        ObjectivesTab.color = new Color32(255,255,255,0);
        ControlsTab.enabled = false;
        ObjectivesTab.enabled = false;
        if (TempleSequence.StartTheSequence)
        {
            ControlsTab.enabled = false;
            ObjectivesTab.enabled = false;
        }

        LevelName.text = "\"Final Dawn\"" + ",\n" + "Green Mists";
        LevelName.color = new Color32(255, 255, 255, 255);
        PauseMenuUI.transform.GetChild(9).GetComponent<TextMeshProUGUI>().text = "\"Final Dawn\"" + ",\n" + "Green Mists" + "\n" + ObjectivesTab.text;
        PauseMenuUI.SetActive(false);
        TransitionScreen.enabled = true;
        TransitionScreen.color = new Color32(0, 0, 0, 255);

        SavedGamesList.SetActive(false);
        LoadSavedGamesList.SetActive(false);
    }
    IEnumerator WaitTime()
    {
        yield return new WaitForSecondsRealtime(2f);
        LevelName.color -= new Color32(0, 0, 0, 5);
    }
    IEnumerator WaitForSaveIcon()
    {
        SavingIcon.enabled = true;
        yield return new WaitForSecondsRealtime(3f);
        SavingIcon.enabled = false;
    }

    private bool isLevelStarted = true;
    private float EarlyLevelTimer = 0f;
    // Update is called once per frame
    void Update()
    {
        if (!isLevelStarted)
            LevelCode();
        else
        {
            print(EarlyLevelTimer);
            if (EarlyLevelTimer >= 0 && EarlyLevelTimer <= 0.2f)
            {
                TransitionScreen.GetComponent<Image>().enabled = true;
                TransitionScreen.GetComponent<Image>().color = new Color32(0, 0, 0, 255);
                LevelName.color = new Color32(255, 255, 255, 0);
                LevelName.enabled = true;
                //ConversationObject.SetActive(false);
                //GameStatusBars.SetActive(false);
                ObjectivesTab.enabled = false;
            }
            else if (EarlyLevelTimer >= 0.29f && EarlyLevelTimer <= 2f)
            {
                if (LevelName.color.a < 255)
                    LevelName.color += new Color32(0, 0, 0, 5);
            }
            else if (EarlyLevelTimer >= 3f && EarlyLevelTimer <= 5f)
            {
                if (EarlyLevelTimer >= 3f && EarlyLevelTimer <= 3.1f)
                {
                    ControlsTab.enabled = true;
                    ObjectivesTab.enabled = true;
                    ControlsTab.color = new Color32(255, 255, 255, 0);
                    ObjectivesTab.color = new Color32(255, 255, 255, 0);
                }

                if (ObjectivesTab.color.a <= 255)
                    ObjectivesTab.color += new Color32(0, 0, 0, 5);
                if (ControlsTab.color.a <= 255)
                    ControlsTab.color += new Color32(0, 0, 0, 5);
            }
            else if (EarlyLevelTimer >= 11f && EarlyLevelTimer <= 13f)
            {
                if (ObjectivesTab.color.a > 0)
                    ObjectivesTab.color -= new Color32(0, 0, 0, 5);
                if (ControlsTab.color.a > 0)
                    ObjectivesTab.color -= new Color32(0, 0, 0, 5);
            }
            else if (EarlyLevelTimer >= 10f && EarlyLevelTimer <= 11f)
            {

                if (LevelName.color.a > 0)
                    LevelName.color -= new Color32(0, 0, 0, 5);
                if (EarlyLevelTimer >= 5.8f)
                    if (TransitionScreen.color.a > 0)
                        TransitionScreen.color -= new Color32(0, 0, 0, 5);
            }
            else if (EarlyLevelTimer >= 13f)
            {
                EarlyLevelTimer = 0f;
                isLevelStarted = false;
                ObjectivesTab.enabled = true;
                //if (ConversationFlag)
                //  ConversationObject.SetActive(true);
                //GameStatusBars.SetActive(true);
            }
            EarlyLevelTimer += Time.deltaTime;
        }
    }

    void LevelCode()
    {
        if (LevelName.color.a > 0)
            StartCoroutine(WaitTime());


        if (Input.GetKeyDown(KeyCode.S))
        {

            StartCoroutine(WaitForSaveIcon());
            print("will quick save your progress now");
            SaveFile();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Time.timeScale = 1f;
            Loader.LoadFromAnySceneSaveFile(4);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPauseMenuEnabled)
            {
                CloseButton.enabled = true;
                CloseButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                ControlsTab.color = new Color32(255, 255, 255, 0);
                ObjectivesTab.color = new Color32(255, 255, 255, 0);
                isPauseMenuEnabled = true;
                Time.timeScale = 0f;
                PauseMenuUI.SetActive(true);
            }
            else
            {
                ResumeGame();
            }
        }
    }
    public void ResumeGame()
    {        
        CloseButton.enabled = false;
        CloseButton.GetComponent<Image>().color = new Color32(255, 255, 255, 0);
        isPauseMenuEnabled = false;
        Time.timeScale = 1f;
        PauseMenuUI.SetActive(false);
        ConfirmationsTab.SetActive(false);
        LoadSavedGamesList.SetActive(false);
        SavedGamesList.SetActive(false);
    }

    public void SaveInGameFile()
    {
        StartCoroutine(WaitForSaveIcon());
        datas.SuperSprintWaitingTimer = 0f;
        datas.LevelIndex = 4;
        datas.SubLevelIndex = 0;
        datas.LevelName = "Green Mists";
        datas.QuestName = "Final Dawn";
        datas.isHouseSequenceOver = false;
        datas.numberOfBlessingsLeft = DinoController.GetNumberofBlessingsLeft();
        if (TempleSequence.StartTheSequence)
            datas.hasStartedSequence = true;
        else
            datas.hasStartedSequence = false;

        string SaveTimeData = JsonUtility.ToJson(datas);
        string Location = SavesDirectoryPath.WindowsSavesFolderPath + "/SavesFolder/Savefile" + SaveFileButton.name +".data";
        //File.WriteAllText(Location, SaveTimeText);
        SaveFileLoader.BinarySerializer(SaveTimeData, Location);
    }

    public void SaveLevel()
    {
        ConfirmationsTab.gameObject.SetActive(true);
        ConfirmationsTab.GetComponent<QuestionsUIScript>().ShowQuestion("You might be overwriting the latest saved data save cautiously,\nwant to save still?", SaveFile, RemainOnLevel);
    }

    void RemainOnLevel()
    {
        ConfirmationsTab.SetActive(false);
        SavedGamesList.SetActive(false);
        LoadSavedGamesList.SetActive(false);
    }

    public void SaveFile()
    {
        SavedGamesList.SetActive(false);
        LoadSavedGamesList.SetActive(false);
        PauseMenuUI.SetActive(false);
        ConfirmationsTab.SetActive(false);

        StartCoroutine(WaitForSaveIcon());
        datas.SuperSprintWaitingTimer = 0f;
        datas.LevelIndex = 4;
        datas.SubLevelIndex = 0;
        datas.LevelName = "Green Mists";
        datas.QuestName = "Final Dawn";
        datas.isHouseSequenceOver = false;
        datas.numberOfBlessingsLeft = DinoController.GetNumberofBlessingsLeft();
        if (TempleSequence.StartTheSequence)
            datas.hasStartedSequence = true;
        else
            datas.hasStartedSequence = false;

        string SaveTimeData = JsonUtility.ToJson(datas);
        string Location = SavesDirectoryPath.WindowsSavesFolderPath + "/SavesFolder/QuickSavefile.data";
        //File.WriteAllText(Location, SaveTimeText);
        SaveFileLoader.BinarySerializer(SaveTimeData, Location);
    }
}
