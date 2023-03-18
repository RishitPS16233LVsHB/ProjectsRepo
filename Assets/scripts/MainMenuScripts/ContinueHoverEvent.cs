
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using SaveData;

//using UnityEngine.UI;

public class ContinueHoverEvent : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler
{
    public TextMeshProUGUI HoverText;
    private PlayerData datas;
    private string LoadGameString;
    
    public 

    void Start()
    {
        LoadGameString = SaveFileLoader.LoadGameData();
        if (LoadGameString != null)
        {
            try
            {
                datas = JsonUtility.FromJson<PlayerData>(LoadGameString);
            } // get the json data from the retrieved string and 
            catch
            {
                print("error Occured:");
                datas = null;
            }
            finally
            {
                //print("this code will always be executed");
            }
        }


    }
    public void OnPointerExit(PointerEventData data)
    {
        HoverText.text = "\0";    
    }
    public void OnPointerEnter(PointerEventData data)
    {
        print("in continue event handler:- " + LoadGameString);
        if (LoadGameString == null)
            HoverText.text = "Sorry you dont have any saved file :(";
        else
        {
            HoverText.text = "Score:- " + datas.GameScore + "\n" + "Level Name:- " + datas.LevelName + "\n" + "Quest Name:- " + datas.QuestName + "\nNumber of Blessings Left:- " + datas.numberOfBlessingsLeft;
        }
    }


}
