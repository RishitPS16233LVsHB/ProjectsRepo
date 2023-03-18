//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class UpDownButtonScroller : MonoBehaviour
{
    public GameObject BookList;
    private float UpLimit = 1225f;
    private float DownLimit = 424f;
    public void ScrollUp()
    {
        Vector3 ListPosition = BookList.GetComponent<RectTransform>().position;
        if (ListPosition.y <= UpLimit)
            ListPosition += new Vector3(0,25f,0);
        BookList.GetComponent<RectTransform>().position = ListPosition;
        print("Y position:- " + BookList.GetComponent<RectTransform>().position.y);
    }
    public void ScrollDown()
    {
        Vector3 ListPosition = BookList.GetComponent<RectTransform>().position;
        if (ListPosition.y >= DownLimit)
            ListPosition -= new Vector3(0, 25f, 0);
        BookList.GetComponent<RectTransform>().position = ListPosition;
        print("Y position:- " + BookList.GetComponent<RectTransform>().position.y);
    }
}
