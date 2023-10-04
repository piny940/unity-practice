using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hitnumscript : MonoBehaviour
{
    Text textcomponent;
    GameObject finishbackground;
    Finishbackgroundscript finishbackgroundscript;
    bool isseen;

    // Start is called before the first frame update
    void Start()
    {
        isseen = false;
        textcomponent = GetComponent<Text>();
        finishbackground = GameObject.Find("Finish Background");
        finishbackgroundscript = finishbackground.GetComponent<Finishbackgroundscript>();
        textcomponent.color = new Color(0, 0, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        //テキストの処理
        textcomponent.text = "弾を当てた数：" + Gamemanager.instance.hitnum + "回";

        

        //フェイドインの処理
        if (Gamemanager.instance.FinishedTimer > finishbackgroundscript.resulttime + 2 && !isseen)
        {
            textcomponent.color = new Color(0, 0, 0, Gamemanager.instance.FinishedTimer - finishbackgroundscript.resulttime - 2);
            if (Gamemanager.instance.FinishedTimer - finishbackgroundscript.resulttime > 3)
            {
                isseen = true;
            }
        }

        //フェイドアウトの処理
        if (finishbackgroundscript.buttontime - Gamemanager.instance.FinishedTimer < 1)
        {
            textcomponent.color = new Color(0, 0, 0, finishbackgroundscript.buttontime - Gamemanager.instance.FinishedTimer);
        }
    }
}
