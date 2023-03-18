//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//using TMPro;

public class PauseMenu : MonoBehaviour
{
    public QuestionsUIScript ConfirmationTab;
    public Image TransitionScreen;
    private SaveFileLoader Loader;

    public GameObject SavedGameFilesList;
    public GameObject LoadGameFilesList;
    public GameObject Player;

    public GameObject StatusBars;
    public GameObject CloseButton;

    // Start is called before the first frame update
    void Start()
    {
        //ConfirmationTab.gameObject.SetActive(false);
        Loader = new SaveFileLoader();
    }

    public void SavedGameLists()
    {
        gameObject.SetActive(false);
        SavedGameFilesList.SetActive(true);
        LoadGameFilesList.SetActive(false);
    }
    public void LoadGameLists()
    {
        gameObject.SetActive(false);
        SavedGameFilesList.SetActive(false);
        LoadGameFilesList.SetActive(true);
    }

    public void ResumeGame()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        DinoController.isPauseMenuActive = false;
        SavedGameFilesList.SetActive(false);
        LoadGameFilesList.SetActive(false);
    }
    public void MainMenu()
    {
        //print(ConfirmationTab);
        ConfirmationTab.gameObject.SetActive(true);
        ConfirmationTab.ShowQuestion("Are you sure you want to quit to Main Menu?",JumpToMainMenu,RemainOnLevel);   
    }
    public void QuitGame()
    {
        ConfirmationTab.gameObject.SetActive(true);
        ConfirmationTab.ShowQuestion("Are you sure you want to quit?", QuitGameToDesktop, RemainOnLevel);
    }

    public void LoadLevel()
    {
        ConfirmationTab.gameObject.SetActive(true);
        ConfirmationTab.ShowQuestion("Are you sure you want to reload a Lastest Quick saved file?",LoadGameFile,RemainOnLevel);
    }

    public void SaveLevel()
    {
        ConfirmationTab.gameObject.SetActive(true);
        ConfirmationTab.ShowQuestion("You might be overwriting the latest saved data save cautiously,\nwant to save still?", GameSave,RemainOnLevel);
    }


    void GameSave()
    {
        Player.GetComponent<SaveGameScript>().SaveFile();
        Time.timeScale = 1f;
        DinoController.isPauseMenuActive = false;
        gameObject.SetActive(false);
        ConfirmationTab.gameObject.SetActive(false);
        StatusBars.SetActive(true);
        CloseButton.SetActive(false);        
    }

    public void QuitGameToDesktop()
    {
        Application.Quit();
    }
    public void JumpToMainMenu()
    {
        LoadingScreenLinker.DestinationIndex = 0;
        LoadingScreenLinker.recievingIndex = 2;
        LoadingScreenLinker.subLevelIndex = 0;
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(1);
    }

    void LoadGameFile()
    {
        Loader.LoadFromAnySceneSaveFile(2);
        Time.timeScale = 1f;
        DinoController.isPauseMenuActive = false;
    }
    
    void RemainOnLevel()
    {
        ConfirmationTab.gameObject.SetActive(false);    
    }
}
