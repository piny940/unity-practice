using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Targetmakerscript : MonoBehaviour
{
    GameObject Itembox;
    GameObject Target;
    Targetscript targetscript;
    [Header("黄金の的が現れる確率（％)")] public float goldrate;
    [Header("アイテムが生成される確率（％/s)")] public float itemrate;
    SpriteRenderer targetsp;


    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        if(Gamemanager.instance.time > 0 && Gamemanager.instance.started)
        {
            //アイテムボックスの生成
            if (Random.value < Time.deltaTime * itemrate / 100f && !Gamemanager.instance.isitem && GameObject.Find("ItemBox(Clone)") == null)
            {
                GameObject itembox_prefab = Resources.Load<GameObject>("ItemBox");
                Itembox = Instantiate(itembox_prefab);
            }

            //的の生成
            if (GameObject.Find("Target(Clone)") == null && Gamemanager.instance.time > 0)
            {
                //的を生成する
                GameObject target_prefab = Resources.Load<GameObject>("Target");
                Target = Instantiate(target_prefab);
                targetscript = Target.GetComponent<Targetscript>();
                targetsp = Target.GetComponent<SpriteRenderer>();

                if (Random.value < goldrate / 100f)
                {
                    targetscript.pointscale = 2;
                    targetsp.color = targetscript.goldcolor;

                }


            }
        }
        

    }
}
