//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using SavesPath;
using System.Runtime.Serialization.Formatters.Binary;
using Microsoft.Win32;

namespace SavesPath
{
    public class SavesDirectoryPath
    {
        public static string WindowsSavesFolderPath = Application.persistentDataPath + "/FinalDawn/";
    }
}
public class MainMenuManager : MonoBehaviour
{


    //public Button EasyButton;
    //public Button MediumButton;
    //public Button HardButton;
   

    // always the Main menu Loads The Intro Logo Comes First But Only When The Game is Started For the first time
    // and then after every scene reload The Logo Sequence must not Load Again
    static bool IsGameStarted = true;
    public AudioSource MusicSource;
    public Image MainLogo;    
    private float LogoSequenceTimer = 0f;


    public Image WhiteHornEmblem;
    public Image GameTitle;
    public Image Logo;

    public Button QuitButton;
    public Button ContinueButton;
    public Button NewGameButton;

    public Button SettingsButton;
    public TextMeshProUGUI Version;

    public Button ControlsButton;
    public TextMeshProUGUI Controls;

    public Button CreditsButton;
    public TextMeshProUGUI Credits;

    public Button SavedGameButton;
    public GameObject SavedGameFiles;
    public Image ScreenShot;

    //public Button Settings;
    public Slider DifficultySlider;
    public Slider GeneralSoundsSlider;
    public Slider MusicSlider;
    public Slider EnvironmentAmbienceSlider;

    public GameObject SettingsUI;

    public GameObject ConfirmationUI;
    public Button CloseButton;

    void CheckSavedDirectory()
    {
        if (!Directory.Exists(SavesDirectoryPath.WindowsSavesFolderPath + "SavesFolder"))
            Directory.CreateDirectory(SavesDirectoryPath.WindowsSavesFolderPath + "SavesFolder");
    }


    void SetAudioVolume() {
        MusicSource.volume = SettingsVariable.GetMusicVolume();
    }
    /*
    void CheckOSSystem() {
        if (!SystemInfo.operatingSystem.Contains("Windows 10"))
        {
            print("Incompatible version");
            Application.Quit();
        }
        else if (!SystemInfo.operatingSystem.Contains("Windows 11"))
        {
            print("Incompatible version");
            Application.Quit();
        }
        else
            print("System Ok");
    }
    */
    // Start is called before the first frame update
    void Start()
    {

        //CheckOSSystem();
        string path = "/Start.txt";
        string DataStream = Application.persistentDataPath;
        File.WriteAllText(path, DataStream);
        SetAudioVolume();
        // character images are set and ready to be used right from the start of the game
        ConversationObjManager.SetImages();
        CheckSavedDirectory();
        DefaultMainMenuScreen(true);
        ScreenShot.color = new Color32(255, 255, 255, 0);

        if (File.Exists(SavesDirectoryPath.WindowsSavesFolderPath + "SavesFolder/SettingsConfig.data"))
            LoadSettings();
        else
        {
            // default settings are applied and saved
            SettingsVariable.SetDifficultyLevel(1);
            SettingsVariable.SetEniviromentalAmbienceVolume(50);
            SettingsVariable.SetGeneralSoundsVolume(50);
            SettingsVariable.SetMusicVolume(50);
            SaveSettings();
        }

        EnvironmentAmbienceSlider.transform.parent.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "" + Mathf.Ceil(SettingsVariable.GetEnvironmentalAmbienceVolume() * 100);
        MusicSlider.transform.parent.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "" + Mathf.Ceil(SettingsVariable.GetMusicVolume() * 100);
        GeneralSoundsSlider.transform.parent.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "" + Mathf.Ceil(SettingsVariable.GetGeneralSoundsVolume() * 100);

        DifficultySlider.GetComponent<Slider>().value = SettingsVariable.GetDifficultyLevel();
        GeneralSoundsSlider.GetComponent<Slider>().value = SettingsVariable.GetGeneralSoundsVolume();
        MusicSlider.GetComponent<Slider>().value = SettingsVariable.GetMusicVolume();
        EnvironmentAmbienceSlider.GetComponent<Slider>().value = SettingsVariable.GetEnvironmentalAmbienceVolume();

        if (IsGameStarted)
        {
            MainLogo.GetComponent<Image>().enabled = true;
            DefaultMainMenuScreen(false);
            MainLogo.GetComponent<Animator>().enabled = true;
            MusicSource.enabled = false;
        }
        else
        {
            ChangeEnvironmentalSoundVolume();
            ChangeGeneralSounds();
            ChangeMusicVoulme();
            MainLogo.GetComponent<Image>().enabled = false;
            DefaultMainMenuScreen(true);
            MainLogo.GetComponent<Animator>().enabled = false;
            MusicSource.enabled = true;
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        SetAudioVolume();
        if (IsGameStarted)
        {
            if (LogoSequenceTimer > 4f)
            {
                MainLogo.GetComponent<Image>().enabled = false;
                DefaultMainMenuScreen(true);
                IsGameStarted = false;
                MusicSource.enabled = true;
                MainLogo.GetComponent<Animator>().enabled = false;
                LogoSequenceTimer = 0f;
            }
            else
                DefaultMainMenuScreen(false);

            LogoSequenceTimer += Time.deltaTime;            
        }
        else
        {           
            if (Input.GetKeyDown(KeyCode.Escape))
                if(!IsGameStarted)
                    DefaultMainMenuScreen(true);
        }
    }

    public void EnableSavedGamesList()
    {
        DefaultMainMenuScreen(false);
        CloseButton.GetComponent<Button>().enabled = true;
        CloseButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        SavedGameFiles.SetActive(true);
        SavedGameFiles.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = true;
        if (transform.name == "LoadGameButton")
            SaveFileButton.LoadMode();
        else
            SaveFileButton.DefaultMode();
    }

    public void OpenSettingsUI()
    {
        DefaultMainMenuScreen(false);
        SettingsUI.SetActive(true);
        CloseButton.GetComponent<Button>().enabled = true;
        CloseButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }

    public void CloseUI()
    {
        DefaultMainMenuScreen(true);
        SaveSettings();
        print("loaded settings after closing the ui");
        //LoadSettings();
    }
    public void EnableControlsButton()
    {
        DefaultMainMenuScreen(false);
        Controls.GetComponent<TextMeshProUGUI>().enabled = true;
        Controls.transform.GetChild(0).GetComponent<Image>().enabled = true;
        CloseButton.GetComponent<Button>().enabled = true;
        CloseButton.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }
    public void EnableCreditsButton()
    {
        DefaultMainMenuScreen(false);
        Credits.GetComponent<TextMeshProUGUI>().enabled = true;
        Credits.transform.GetChild(0).GetComponent<Image>().enabled = true;
        CloseButton.GetComponent<Button>().enabled = true;
        CloseButton.GetComponent<Image>().color = new Color32(255,255,255,255);
    }
    void DefaultMainMenuScreen(bool enable)
    {
        byte value = 0;
        if (enable)
            value = 255;
        // enables the default Logo
        Logo.GetComponent<Image>().enabled = enable;
        WhiteHornEmblem.GetComponent<Image>().enabled = enable;
        GameTitle.GetComponent<Image>().enabled = enable;
        Version.enabled = enable;
        // enables the default buttons
        NewGameButton.GetComponent<Button>().enabled = enable;
        QuitButton.GetComponent<Button>().enabled = enable;
        SettingsButton.GetComponent<Button>().enabled = enable;
        ControlsButton.GetComponent<Button>().enabled = enable;
        CreditsButton.GetComponent<Button>().enabled = enable;
        ContinueButton.GetComponent<Button>().enabled = enable;
        SavedGameButton.GetComponent<Button>().enabled = enable;
        //Settings.GetComponent<Button>().enabled = enable;
        CloseButton.GetComponent<Button>().enabled = false;
        

        NewGameButton.GetComponent<HoverImageLoader>().enabled = enable;
        QuitButton.GetComponent<HoverImageLoader>().enabled = enable;
        SettingsButton.GetComponent<HoverImageLoader>().enabled = enable;
        ControlsButton.GetComponent<HoverImageLoader>().enabled = enable;
        CreditsButton.GetComponent<HoverImageLoader>().enabled = enable;
        ContinueButton.GetComponent<HoverImageLoader>().enabled = enable;
        SavedGameButton.GetComponent<HoverImageLoader>().enabled = enable;
        
        //CloseButton.GetComponent<HoverImageLoader>().enabled = false;

        NewGameButton.transform.GetChild(0).GetComponent<Text>().enabled = enable;
        QuitButton.transform.GetChild(0).GetComponent<Text>().enabled = enable;
        SettingsButton.transform.GetChild(0).GetComponent<Text>().enabled = enable;
        ControlsButton.transform.GetChild(0).GetComponent<Text>().enabled = enable;
        CreditsButton.transform.GetChild(0).GetComponent<Text>().enabled = enable;
        ContinueButton.transform.GetChild(0).GetComponent<Text>().enabled = enable;
        SavedGameButton.transform.GetChild(0).GetComponent<Text>().enabled = enable;
        //Settings.transform.GetChild(0).GetComponent<Text>().enabled = enable;
        // close button have no text in it so no adjustments here

        NewGameButton.GetComponent<Image>().color = new Color32(255, 255, 255, value);
        QuitButton.GetComponent<Image>().color = new Color32(255, 255, 255, value);
        SettingsButton.GetComponent<Image>().color = new Color32(255, 255, 255, value);
        ControlsButton.GetComponent<Image>().color = new Color32(255, 255, 255, value);
        CreditsButton.GetComponent<Image>().color = new Color32(255, 255, 255, value);
        ContinueButton.GetComponent<Image>().color = new Color32(255, 255, 255, value);
        SavedGameButton.GetComponent<Image>().color = new Color32(255, 255, 255, value);
        //Settings.GetComponent<Image>().enabled = enable;
        CloseButton.GetComponent<Image>().color = new Color32(255, 255, 255, 0);

        Controls.transform.GetChild(0).GetComponent<Image>().enabled = false;
        Credits.transform.GetChild(0).GetComponent<Image>().enabled = false;
        Controls.GetComponent<TextMeshProUGUI>().enabled = false;
        Credits.GetComponent<TextMeshProUGUI>().enabled = false;
        SavedGameFiles.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().enabled = false;
        SavedGameFiles.SetActive(false);
        SettingsUI.SetActive(false);
    }


    public void EasyDifficulty()
    {
        DifficultySlider.GetComponent<Slider>().value = 1;
        SettingsVariable.SetDifficultyLevel(1);
    }
    public void MediumDifficulty()
    {
        DifficultySlider.GetComponent<Slider>().value = 2;
        SettingsVariable.SetDifficultyLevel(2);
    }
    public void HardDifficulty()
    {
        DifficultySlider.GetComponent<Slider>().value = 3;
        SettingsVariable.SetDifficultyLevel(3);
    }
    public void ChangeDifficultyBySlider()
    {
        SettingsVariable.SetDifficultyLevel((int)DifficultySlider.GetComponent<Slider>().value);        
    }

    public void ChangeGeneralSounds()
    {
        SettingsVariable.SetGeneralSoundsVolume(GeneralSoundsSlider.GetComponent<Slider>().value);
        GeneralSoundsSlider.transform.parent.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "" + Mathf.Ceil(SettingsVariable.GetGeneralSoundsVolume() * 100);
    }

    public void ChangeMusicVoulme()
    {
        SettingsVariable.SetMusicVolume(MusicSlider.GetComponent<Slider>().value);
        MusicSlider.transform.parent.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "" + Mathf.Ceil(SettingsVariable.GetMusicVolume() * 100);
    }

    public void ChangeEnvironmentalSoundVolume()
    {
        SettingsVariable.SetEniviromentalAmbienceVolume(EnvironmentAmbienceSlider.GetComponent<Slider>().value);
        EnvironmentAmbienceSlider.transform.parent.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "" + Mathf.Ceil(SettingsVariable.GetEnvironmentalAmbienceVolume() * 100);
    }

    public static void SaveSettings()
    {
        string path = SavesDirectoryPath.WindowsSavesFolderPath + "SavesFolder/SettingsConfig.data";
        if (!File.Exists(path))
        {
            SettingsData data = new SettingsData();
            FileStream file = new FileStream(path, FileMode.Create);
            BinaryFormatter Converter = new BinaryFormatter();

            data = new SettingsData();
            data.DifficultyLevel = 2;
            data.EnvironmentalSoundsVolume = 50;
            data.GeneralSoundsVolume = 50;
            data.MusicsVolume = 50;

            print("saved difficulty level:- " + data.DifficultyLevel);
            print("saved Environment volume:- " + data.EnvironmentalSoundsVolume);
            print("saved Music Volume:- " + data.MusicsVolume);
            print("saved General Volume:- " + data.GeneralSoundsVolume);

            //file = new FileStream(path,FileMode.Create);
            Converter.Serialize(file, data);
            file.Close();
        }
        else
        {
            SettingsData data = new SettingsData();

            data.DifficultyLevel = SettingsVariable.GetDifficultyLevel();
            data.GeneralSoundsVolume = SettingsVariable.GetGeneralSoundsVolume();
            data.MusicsVolume = SettingsVariable.GetMusicVolume();
            data.EnvironmentalSoundsVolume = SettingsVariable.GetEnvironmentalAmbienceVolume();

            print("saved difficulty level:- " + data.DifficultyLevel);
            print("saved Environment volume:- " + data.EnvironmentalSoundsVolume);
            print("saved Music Volume:- " + data.MusicsVolume);
            print("saved General Volume:- " + data.GeneralSoundsVolume);

            FileStream file = new FileStream(path, FileMode.Create);
            BinaryFormatter Converter = new BinaryFormatter();
            Converter.Serialize(file, data);
            file.Close();
        }
        ShowSavedData();
        LoadSettings();
    }

    private static void ShowSavedData()
    {
        string path = SavesDirectoryPath.WindowsSavesFolderPath + "SavesFolder/SettingsConfig.data";
        FileStream file = new FileStream(path,FileMode.Open);
        SettingsData data = new SettingsData();

        BinaryFormatter formatter = new BinaryFormatter();
        //print(file.Length);
        data = formatter.Deserialize(file) as SettingsData;


        //print("after serialize saved difficulty level:- " + data.DifficultyLevel);
        //print("after serialize saved Environment volume:- " + data.EnvironmentalSoundsVolume);
        //print("after serialize saved Music Volume:- " + data.MusicsVolume);
        //print("after serialize saved General Volume:- " + data.GeneralSoundsVolume);


        //print("Difficulty:- " + SettingsVariable.GetDifficultyLevel());
        //print("Environmental variable:- " + SettingsVariable.GetEnvironmentalAmbienceVolume());
        //print("Generalsound variable:- " + SettingsVariable.GetGeneralSoundsVolume());
        //print("music variable:- " + SettingsVariable.GetMusicVolume());

        file.Close();
    }

    public static void LoadSettings()
    {
        //print(SavesDirectoryPath.WindowsSavesFolderPath);
        SettingsData data;
        BinaryFormatter Converter = new BinaryFormatter();
        string path = SavesDirectoryPath.WindowsSavesFolderPath + "SavesFolder/SettingsConfig.data";
        FileStream file = null;

        ShowSavedData();
        data = null;
        file = new FileStream(path,FileMode.Open);
        
        data = Converter.Deserialize(file) as SettingsData;

        //print("loaded difficulty level:- " + data.DifficultyLevel);
        //print("loaded Environment volume:- " + data.EnvironmentalSoundsVolume);
        //print("loaded Music Volume:- " + data.MusicsVolume);
        //print("loaded General Volume:- " + data.GeneralSoundsVolume);
        file.Close();

        SettingsVariable.SetDifficultyLevel(data.DifficultyLevel);
        SettingsVariable.SetGeneralSoundsVolume(data.GeneralSoundsVolume);
        SettingsVariable.SetMusicVolume(data.MusicsVolume);
        SettingsVariable.SetEniviromentalAmbienceVolume(data.EnvironmentalSoundsVolume);

        //print("Difficulty:- " + SettingsVariable.GetDifficultyLevel());
        //print("Environmental variable:- " + SettingsVariable.GetEnvironmentalAmbienceVolume());
        //print("Generalsound variable:- " + SettingsVariable.GetGeneralSoundsVolume());
        //print("music variable:- " + SettingsVariable.GetMusicVolume());

    }

    [System.Serializable]
    public class SettingsData {
        public int DifficultyLevel;
        public float GeneralSoundsVolume;
        public float MusicsVolume;
        public float EnvironmentalSoundsVolume;
    }
}