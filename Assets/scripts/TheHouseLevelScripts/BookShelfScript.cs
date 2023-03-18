//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class BookShelfScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject PlayerControlSuggestionText;
    private bool activate = false;
    public GameObject ObjectUI;

    

    // ui child component
    TextMeshProUGUI UItitle;
    TextMeshProUGUI BookTitle;
    Button NextPage;
    Button PreviousPage;
    Button CloseButton;
    TextMeshProUGUI BookContents;
    Image BackgroundImage;
    private bool isUIactive = false;
   
    // Start is called before the first frame update
    void Start()
    {        
        PlayerControlSuggestionText.transform.GetChild(0).GetComponent<Image>().enabled = false;
        PlayerControlSuggestionText.transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = false;
        ConnectUIElements();
        UIEnabling(false);
        ObjectUI.SetActive(false);        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && activate == true)
        {
            //opens the book shelf ui over here
            OpenUI();
        }
        else if (Input.GetKey(KeyCode.Escape))
        {
            // closes the Book shelf UI over here
            CloseUI();
        }
    }

    public void CloseUI()
    {
        ObjectUI.SetActive(false);
        Player.GetComponent<PlayerScript>().enabled = true;
        UIEnabling(false);
    }
    public void OpenUI()
    {
        ObjectUI.SetActive(true);
        Player.GetComponent<PlayerScript>().enabled = false;
        UIEnabling(true);
    }
    private void FixedUpdate()
    {
        SphereCheck();
    }
    // this thing is bloody dumb that you should have a different text object for different object or might possibly different scripts 
    // but the quickest solution was this and also the naive one
    void SphereCheck()
    {
        Collider[] collidingObjects = Physics.OverlapSphere(transform.position, 3f);
        foreach (Collider col in collidingObjects)
        {
            if (col.transform.name == "PlayerLevel2")
            {
                PlayerControlSuggestionText.transform.GetChild(0).GetComponent<Image>().enabled = true;
                PlayerControlSuggestionText.transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = true;
                PlayerControlSuggestionText.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "press e to interact with BookShelf";
                activate = true;
            }
            else
            {
                PlayerControlSuggestionText.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "\0";
                PlayerControlSuggestionText.transform.GetChild(0).GetComponent<Image>().enabled = false;
                PlayerControlSuggestionText.transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = false;
                
                activate = false;
            }
        }
    }

    void UIEnabling(bool status)
    {
        try
        {
            BackgroundImage.GetComponent<Image>().enabled = status;
            UItitle.GetComponent<TextMeshProUGUI>().enabled = status;
            BookContents.GetComponent<TextMeshProUGUI>().enabled = status;
            BookTitle.GetComponent<TextMeshProUGUI>().enabled = status;
            NextPage.GetComponent<Button>().enabled = status;
            PreviousPage.GetComponent<Button>().enabled = status;
            CloseButton.GetComponent<Button>().enabled = status;
            isUIactive = false;
        }
        catch (Exception e)
        {
            print("is the Source:- " + e.Message);
        }
    }
    void ConnectUIElements()
    {
        BackgroundImage = ObjectUI.transform.GetChild(0).GetComponent<Image>();
        UItitle = ObjectUI.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        BookContents = ObjectUI.transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        BookTitle = ObjectUI.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        NextPage = ObjectUI.transform.GetChild(4).GetComponent<Button>();
        PreviousPage = ObjectUI.transform.GetChild(5).GetComponent<Button>();
        CloseButton = ObjectUI.transform.GetChild(9).GetComponent<Button>();
    }

}
