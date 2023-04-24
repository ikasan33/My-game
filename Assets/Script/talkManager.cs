using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    // Start is called before the first frame update
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        talkData.Add(1000, new string[] { "Hello", "hell" });
        talkData.Add(100, new string[] { "tree" });
        talkData.Add(200, new string[] { "water" });
    }
    public string GetTalk(int id, int talkIndex)
    {
        return talkData[id][talkIndex];
    }
}
