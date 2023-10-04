using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hitpercentscript : MonoBehaviour
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
        if (Gamemanager.instance.gunnum != 0f)
        {
            textcomponent.text = "命中率：" + 100f * Gamemanager.instance.hitnum / Gamemanager.instance.gunnum + "%";
        }
        else
        {
            textcomponent.text = "命中率：" + 0 + "%";
        }

        

        //フェイドインの処理
        if (Gamemanager.instance.FinishedTimer > finishbackgroundscript.resulttime + 3 && !isseen)
        {
            textcomponent.color = new Color(0, 0, 0, Gamemanager.instance.FinishedTimer - finishbackgroundscript.resulttime - 3);
            if (Gamemanager.instance.FinishedTimer - finishbackgroundscript.resulttime > 4)
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
