using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour
{
    public GameObject talkPanel;
    public Text talkText;
    public GameObject scanObject;
    public bool isAction;

    public void Action(GameObject scanObj)
    {
        if (isAction)
        {
            isAction = false;
            
        }
        else
        {
            isAction = true;
            scanObject = scanObj;
            talkText.text = "this name is" + scanObj.name;
        }
        talkPanel.SetActive(isAction);
    }
}
