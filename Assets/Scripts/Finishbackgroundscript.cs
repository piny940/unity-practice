using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finishbackgroundscript : MonoBehaviour
{
    Image image;
    [Header("幕が下りる速さ")]public float downspeed;
    [Header("ボタンを入れる")] public GameObject[] buttons;
    [Header("ResultTextが表示されるタイミング")] public float resulttime;
    [Header("ボタンが表示されるタイミング")] public float buttontime;
    GameObject result;
    Text resulttext;
    bool isbutton;
    bool isresult;
    bool resultisseen;


    // Start is called before the first frame update
    void Start()
    {
        resultisseen = false;
        isresult = false;
        isbutton = false;
        image = GetComponent<Image>();
        image.fillAmount = 0;
        for(int i = 0; i< 2; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }

        //ResultTextを取得する
        result = GameObject.Find("Result Text");

        //ResultTextの色を設定する
        resulttext = result.GetComponent<Text>();
        resulttext.color = new Color(0, 0, 0, 0);

        //ResultTextを非アクティブにする
        if (result == null)
        {
            Debug.Log("ResultTextをActiveにしてください");
        }
        else
        {
            result.gameObject.SetActive(false);

        }



    }

    // Update is called once per frame
    void Update()
    {
        //幕を下ろす
        image.fillAmount = Gamemanager.instance.FinishedTimer * downspeed / 10;

        //結果を表示する
        if (Gamemanager.instance.FinishedTimer > resulttime && !isresult)
        {
            result.gameObject.SetActive(true);
            isresult = true;

        }

        //ResultTextのフェイドインの処理
        if (Gamemanager.instance.FinishedTimer > resulttime && !resultisseen)
        {
            resulttext.color = new Color(0, 0, 0, Gamemanager.instance.FinishedTimer - resulttime);
            if(Gamemanager.instance.FinishedTimer - resulttime > 1)
            {
                resultisseen = true;
            }
        }

        //ボタンを表示する
        if (Gamemanager.instance.FinishedTimer > buttontime && !isbutton)
        {
            result.gameObject.SetActive(false);
            for (int i = 0; i < 2; i++)
            {
                buttons[i].gameObject.SetActive(true);
            }
            isbutton = true;
        }

        //ResultTextのフェイドアウトの処理
        if (buttontime - Gamemanager.instance.FinishedTimer < 1)
        {
            resulttext.color = new Color(0, 0, 0, buttontime - Gamemanager.instance.FinishedTimer);
            
        }
    }
}
