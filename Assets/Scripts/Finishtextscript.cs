using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finishtextscript : MonoBehaviour
{
    bool isseen;
    Text textscript;
    [Header("テキストの色")] public Color color;
    [Header("テキストが現れ出すタイミング")] public float starttime;

    // Start is called before the first frame update
    void Start()
    {
        textscript = GetComponent<Text>();
        textscript.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if (Gamemanager.instance.FinishedTimer > starttime && !isseen)
        {
            textscript.color += new Color(0, 0, 0, Time.deltaTime);

            if (Gamemanager.instance.FinishedTimer > 6)
            {
                isseen = true;
            }
        }
        
    }
}
