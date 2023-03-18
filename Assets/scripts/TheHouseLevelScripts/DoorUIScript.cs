//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DoorUIScript : MonoBehaviour
{
    public GameObject Player;
    public GameObject PlayerControlSuggestionText;
    public Image transitionScreen;
    private bool isNear = false;
    public bool isLevelOver = false;
    private float timer = 0f;
    
    public GameObject DoorSoundsSource;
    // Start is called before the first frame update
    void Start()
    {
        transitionScreen.GetComponent<Image>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isNear)
        {
            DoorSoundsSource.GetComponent<AudioSource>().Play();
            transitionScreen.GetComponent<Image>().enabled = true;            
            isLevelOver = true;
        }

        if (isLevelOver)
        {
            if (timer > 2f)
            {               
                timer = 0f;
                LoadingScreenLinker.recievingIndex = 3;
                LoadingScreenLinker.DestinationIndex = 2;
                LoadingScreenLinker.subLevelIndex = 3;
                BackgroundAndSpriteManager.CanChange = true;
                SceneManager.UnloadSceneAsync(3);
                SceneManager.LoadScene(1);
            }
            else
            {
                PlayerControlSuggestionText.SetActive(false);
                if (transitionScreen.color.a < 255)
                    transitionScreen.color += new Color32(0,0,0,10);
                timer += Time.deltaTime;
            }
        }


    }

    void FixedUpdate()
    {
        SphereCheck();
    }
    // to check whether tha player is touching an object do not let the player do the checking let that object make those checks
    // other wise checking from players script will delay required processing in my case i want to display a message that on touching the 
    // the interactable door you must be able to interact with it but attaching the logic over here with the player script leads to the delayed
    // message disabling
    // thus always make a collision check of player from the other objects not from the player

    void SphereCheck()
    {
        Collider[] collidingObjects = Physics.OverlapSphere(transform.position, 3f);
        foreach (Collider col in collidingObjects)
        {
            if (col.transform.name == "PlayerLevel2")
            {
                PlayerControlSuggestionText.transform.GetChild(0).GetComponent<Image>().enabled = true;
                PlayerControlSuggestionText.transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = true;
                PlayerControlSuggestionText.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "press e to interact with Door";
                isNear = true;
            }
            else
            {
                PlayerControlSuggestionText.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "\0";
                PlayerControlSuggestionText.transform.GetChild(0).GetComponent<Image>().enabled = false;
                PlayerControlSuggestionText.transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = false;
                isNear = false;
            }
        }
    }


    /*
         private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name == "PlayerLevel2")
        {
            PlayerControlSuggestionText.transform.GetChild(0).GetComponent<Image>().enabled = true;
            PlayerControlSuggestionText.transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = true;
            PlayerControlSuggestionText.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text= "press e to interact with Door";
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        PlayerControlSuggestionText.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "\0";
        PlayerControlSuggestionText.transform.GetChild(0).GetComponent<Image>().enabled = false;
        PlayerControlSuggestionText.transform.GetChild(1).GetComponent<TextMeshProUGUI>().enabled = false;
    }

        
   */


}
