using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talk : MonoBehaviour
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
        talkData.Add(1000, new string[] { "뭘봐", "쥮ㅎㅋㅋ" });
        talkData.Add(100, new string[] {"평범해보이는 나무다"}
        talkData.Add(200, new string[] {"나무다"}
    }
}
