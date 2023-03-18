//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class NewGameButtonScript : MonoBehaviour
{
    public AudioSource ThemeSource;
    public Image LoadingScreen;
    public GameObject ConfirmationsTab;


    float FadeOutTimer = 0f;
    bool DoFadeOut = false;
    bool ExecuteCode = false;
    // Start is called before the first frame update
    void Start()
    {
        LoadingScreen.GetComponent<Animator>().enabled = false;
        LoadingScreen.enabled = false;
        ConfirmationsTab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (DoFadeOut)
        {
            if (FadeOutTimer > 3f)
            {
                LoadingScreen.enabled = false;                
                LoadingScreen.GetComponent<Animator>().enabled = true;
                ExecuteCode = true;
                NewGameChangeScene();
            }
            else
            {
                LoadingScreen.enabled = true;
                LoadingScreen.GetComponent<Animator>().enabled = true;
                FadeOut();
                FadeOutTimer += Time.deltaTime;
            }
        }
        */
    }

    public void ConfirmNewGame()
    {
        ConfirmationsTab.SetActive(true);
        ConfirmationsTab.GetComponent<QuestionsUIScript>().ShowQuestion("Do You Really want to Start a new Game?",NewGameChangeScene,StayOnTheMainMenu);
    }

    public void StayOnTheMainMenu()
    {
        ConfirmationsTab.SetActive(false);
    }

    public void NewGameChangeScene()
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

    void FadeOut()
    {
        if (ThemeSource.volume > 0)
            ThemeSource.volume -= 0.001f;
    }
}
