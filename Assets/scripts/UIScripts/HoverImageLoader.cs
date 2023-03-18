//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

// if in future need arises of integrating UI audio then it can be done through this class also
// just dont go on its name it can do multiple things ;)    


public class HoverImageLoader : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    private static AudioClip HoverEffect;
    private static GameObject HoverSource;

    static private Sprite[] ButtonSprites = null;

    [SerializeField] private Sprite NormalUnderLining;
    //[SerializeField] private Sprite SelectedSprite;
    [SerializeField] private Sprite DefaultSprite;
    // Start is called before the first frame update

    void SetAudioVolume()
    {
        HoverSource.GetComponent<AudioSource>().volume = SettingsVariable.GetGeneralSoundsVolume();
    }
    void Start()
    {
        HoverEffect = Resources.Load<AudioClip>("UISounds/ButtonHoverSound");
        // setting the some variables
        if (HoverSource == null)
        {
            HoverSource = new GameObject();
            HoverSource.AddComponent<AudioSource>();
        }
        HoverSource.GetComponent<AudioSource>().clip = HoverEffect;
        SetAudioVolume();
        if (ButtonSprites == null)
            ButtonSprites = Resources.LoadAll<Sprite>("ButtonSprites");

        DefaultSprite = ButtonSprites[0];
        NormalUnderLining = ButtonSprites[2];
        //SelectedSprite = ButtonSprites[1];

        // will add the onclick event for image loading for each button
        //gameObject.GetComponent<Button>().onClick.AddListener(new UnityEngine.Events.UnityAction(ButtonSelected));
            
        gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        gameObject.GetComponent<Image>().sprite = DefaultSprite;
        ChangeTextColor(new Color32(255, 255, 255, 255));
    }

    // these are on mouse cursor enters/exits  the button area code 
    public void OnPointerEnter(PointerEventData e)
    {
        SetAudioVolume();
        HoverSource.GetComponent<AudioSource>().Play();
        // cursor has entered the button area and a sprite for underlining is required
        gameObject.GetComponent<Image>().sprite = NormalUnderLining;        
        ChangeTextColor(new Color32(255, 255, 255, 255));        
    }
    public void OnPointerExit(PointerEventData e)
    {
        if (HoverSource != null)
            HoverSource.GetComponent<AudioSource>().Stop();
        // cursor has exited the button so no sprite required so remove the sprite
        gameObject.GetComponent<Image>().sprite = DefaultSprite;
        ChangeTextColor(new Color32(255, 255, 255, 255));
    }

    /*
    IEnumerator DeselectButton()
    {
        yield return new WaitForSecondsRealtime(3);
        gameObject.GetComponent<Image>().sprite = DefaultSprite;
        StopCoroutine(DeselectButton());
    }
    */
    // use the below method for applying the audion for the UI

    /*
    // this is onclick event 
    void ButtonSelected()
    {
        StartCoroutine(DeselectButton());
        ChangeTextColor(new Color32(255, 255, 255, 255));
        gameObject.GetComponent<Image>().sprite = SelectedSprite;
    }
    */
        

    void ChangeTextColor(Color32 color)
    {
        // this script will be applied on almost all buttons and the buttons that it might encounter may have different child components 
        // so to handle we just have to check if the button is text or text mesh pro type button then change the color of the color accordingly
        if (gameObject.transform.GetChild(0).GetComponent<Text>() != null)
            gameObject.transform.GetChild(0).GetComponent<Text>().color = color;
        else if (gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>() != null)
            gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = color;
    }
}
