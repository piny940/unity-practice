using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waitingscript1 : MonoBehaviour
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
        if (Gamemanager.instance.waiting)
        {
            image.color = new Color(1, 1, 1, AppearCurve.Evaluate(Gamemanager.instance.waitingtime));
        }
        if (Gamemanager.instance.started)
        {
            gameObject.SetActive(false);
        }
    }
}
