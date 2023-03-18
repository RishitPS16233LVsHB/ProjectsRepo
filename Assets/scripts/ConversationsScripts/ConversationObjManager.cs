//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DialoguesAndConversationDatastructures;
public class ConversationObjManager : MonoBehaviour
{
    private static Sprite[] CharacterImages;
    private GameObject DialogueSpace;
    private GameObject CharacterName;
    private GameObject CharacterImage;
    private Sprite DefaultImage;
    // Start is called before the first frame update
    void Start()
    {
        if(CharacterImages == null)
            SetImages();
        // got the child references for the object 
        // now just need a method that will just nicely display whatever dialogue i want to display along with the image and the correct character name
        DefaultImage = Resources.Load<Sprite>("/ButtonSprite/ButtonDefaultSprite");
        CharacterImage = gameObject.transform.GetChild(1).gameObject;
        DialogueSpace = gameObject.transform.GetChild(2).gameObject;
        CharacterName = gameObject.transform.GetChild(3).gameObject;
        
        CharacterImage.GetComponent<Image>().sprite = DefaultImage;
    }

    public void ManageConversationObject(string name,string CharacterDialogue,Sprite CharacterPicture)
    {
        if (DialogueSpace != null || CharacterName != null)
        {
            gameObject.SetActive(true);
            // this method will surely load up the Assets and the dialogues that i want
            CharacterName.GetComponent<TextMeshProUGUI>().text = name;
            DialogueSpace.GetComponent<TextMeshProUGUI>().text = CharacterDialogue;
            CharacterImage.GetComponent<Image>().sprite = CharacterPicture;
        }
        else
        {
            CharacterName.GetComponent<TextMeshProUGUI>().text = null;
            DialogueSpace.GetComponent<TextMeshProUGUI>().text = null;
            CharacterImage.GetComponent<Image>().sprite = DefaultImage;
            gameObject.SetActive(false);
        }
    }

    public void ManageConversationObject(Dialogue quote,Sprite image)
    {
        if (quote.CharacterName != null && quote.dialogue != null && image != null)
        {
            gameObject.SetActive(true);
            // this method will surely load up the Assets and the dialogues that i want
            CharacterName.GetComponent<TextMeshProUGUI>().text = quote.CharacterName;
            DialogueSpace.GetComponent<TextMeshProUGUI>().text = quote.dialogue;
            CharacterImage.GetComponent<Image>().sprite = image;
        }
        else
        {
            CharacterName.GetComponent<TextMeshProUGUI>().text = null;
            DialogueSpace.GetComponent<TextMeshProUGUI>().text = null;
            CharacterImage.GetComponent<Image>().sprite = DefaultImage;
            gameObject.SetActive(false);
        }

    }

    public void ManageConversationObject(Dialogue quote)
    {
        if (quote.CharacterName != null && quote.dialogue != null)
        {
            gameObject.SetActive(true);
            // this method will surely load up the Assets and the dialogues that i want
            CharacterName.GetComponent<TextMeshProUGUI>().text = quote.CharacterName;
            DialogueSpace.GetComponent<TextMeshProUGUI>().text = quote.dialogue;
        }
        else
        {            
            // this method will surely load up the Assets and the dialogues that i want
            CharacterName.GetComponent<TextMeshProUGUI>().text = null;
            DialogueSpace.GetComponent<TextMeshProUGUI>().text = null;
            gameObject.SetActive(false);
        }
    }


    public static void SetImages()
    {
        CharacterImages = Resources.LoadAll<Sprite>("CharacterImages");
    }

    // if any scene demands any kind of conversation whether it be blank subtitles or with character images
    // they in there statr methods have to call the Get image method to hold all the Images for characters 
    public static Sprite[] GetImage()
    {
        return CharacterImages;
    }
}
