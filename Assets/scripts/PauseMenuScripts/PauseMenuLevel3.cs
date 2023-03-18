//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuLevel3 : MonoBehaviour
{
    public GameObject Pausemenu;
    public GameObject ConfirmationsTab;
    public TempleLevelSavingScript Saver;
    public GameObject SavedGamesList;
    public GameObject LoadGamesList;
    SaveFileLoader Loader;
    // Start is called before the first frame update
    void Start()
    {
        //gameObject.GetComponent<PauseMenu>().enabled = false;
        ConfirmationsTab.SetActive(false);
    }
    public void SavedGameLists()
    {
        gameObject.SetActive(false);
        SavedGamesList.SetActive(true);
        LoadGamesList.SetActive(false);
    }
    public void LoadGameLists()
    {
        gameObject.SetActive(false);
        SavedGamesList.SetActive(false);
        LoadGamesList.SetActive(true);
    }
    public void ResumeGame()
    {
        Time.timeScale = 1f;
        HouseLevelSavingScript.isPauseMenuEnabled = false;
        Pausemenu.SetActive(false);
        ConfirmationsTab.SetActive(false);
        LoadGamesList.SetActive(false);
        SavedGamesList.SetActive(false);
    }
    public void MainMenu()
    {
        ConfirmationsTab.SetActive(true);
        ConfirmationsTab.GetComponent<QuestionsUIScript>().ShowQuestion("Are you sure you really want to quit to the Main Menu?", JumpToMainMenu, RemainOnLevel);
    }
    public void QuitGame()
    {
        ConfirmationsTab.gameObject.SetActive(true);
        ConfirmationsTab.GetComponent<QuestionsUIScript>().ShowQuestion("Are you sure you want to quit?", QuitGameToDesktop, RemainOnLevel);
    }

    public void LoadLevel()
    {
        ConfirmationsTab.gameObject.SetActive(true);
        ConfirmationsTab.GetComponent<QuestionsUIScript>().ShowQuestion("Are you sure you want to reload a Lastest Quick saved file?", LoadGameFile, RemainOnLevel);
    }

    public void SaveLevel()
    {
        ConfirmationsTab.gameObject.SetActive(true);
        ConfirmationsTab.GetComponent<QuestionsUIScript>().ShowQuestion("You might be overwriting the latest saved data save cautiously,\nwant to save still?", GameSave, RemainOnLevel);
    }

    void JumpToMainMenu()
    {
        LoadingScreenLinker.DestinationIndex = 0;
        LoadingScreenLinker.recievingIndex = 3;
        LoadingScreenLinker.subLevelIndex = 0;
        SceneManager.LoadSceneAsync(1);
        Time.timeScale = 1f;
        SceneManager.UnloadSceneAsync(3);
    }
    void QuitGameToDesktop()
    {
        Application.Quit();
    }

    void RemainOnLevel()
    {
        ConfirmationsTab.SetActive(false);
        LoadGamesList.SetActive(false);
        SavedGamesList.SetActive(false);
    }

    void GameSave()
    {
        Saver.SaveFile();
        ResumeGame();
    }
    void LoadGameFile()
    {
        Loader = new SaveFileLoader();
        ResumeGame();
        Loader.LoadFromAnySceneSaveFile(4);
    }

}
