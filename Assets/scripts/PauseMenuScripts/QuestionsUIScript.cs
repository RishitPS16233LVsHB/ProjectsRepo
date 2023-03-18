//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class QuestionsUIScript : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Button YesButton;
    public Button NoButton;

    private void Awake()
    {

    }
    public void ShowQuestion(string message, Action YesAction, Action NoAction)
    {
        YesButton.onClick.RemoveAllListeners();
        NoButton.onClick.RemoveAllListeners();
        text.text = message;
        YesButton.onClick.AddListener(new UnityEngine.Events.UnityAction(YesAction));
        NoButton.onClick.AddListener(new UnityEngine.Events.UnityAction(NoAction));

    }
}
