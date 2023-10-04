using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitingscriptS : MonoBehaviour
{
    public AnimationCurve AppearCurve;
    Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        image.color = new Color(1, 1, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Gamemanager.instance.started)
        {
            image.color = new Color(1, 1, 1, AppearCurve.Evaluate(Gamemanager.instance.limittime - Gamemanager.instance.time));
        }

        if (Gamemanager.instance.limittime - Gamemanager.instance.time > 3)
        {
            gameObject.SetActive(false);
        }
    }
}
