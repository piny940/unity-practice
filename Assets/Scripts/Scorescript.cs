using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorescript : MonoBehaviour
{
    Text textcomponent;
    // Start is called before the first frame update
    void Start()
    {
        textcomponent = GetComponent<Text>();//コンポーネントを取得
        
    }

    // Update is called once per frame
    void Update()
    {
        textcomponent.text = "Score:" + Gamemanager.instance.score;//スコアを表示
    }
}
