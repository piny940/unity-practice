using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Itemcontrollerscript : MonoBehaviour
{
    #region//変数を宣言
    bool itemmade;
    float pointtime;
    GameObject pointitem;
    [Header("アイテムを入れる")] public GameObject[] Items;
    [Header("Pointitemの効果時間")] public float pointlimit;
    [Header("Pointsを入れる")] public GameObject Points;
    [Header("アイテムが消える時に点滅する時間")] public float flickertime;
    #endregion

    void Start()
    {
        //アイテムを非アクティブにする
        for (int i = 0; i < Items.Length; i++)
        {
            Items[i].SetActive(false);
        }


        pointitem = Items[0];

    }

    void Update()
    {
        //アイテムを表示・生成する
        if (Gamemanager.instance.isitem && !itemmade)
        {
            //pointitemの処理
            if (Random.value < 1f / Items.Length)
            {
                pointitem.gameObject.SetActive(true);
                Points.gameObject.SetActive(true);
                Gamemanager.instance.ispointitem = true;
            }
            else if(Random.value < 2f / Items.Length)
            {

            }


            itemmade = true;
        }

        PointItem();

    }

    /// <summary>
    /// pointitemの処理
    /// </summary>
    void PointItem()
    {
        if (Gamemanager.instance.ispointitem)
        {
            Image itemimage = pointitem.GetComponent<Image>();
            SpriteRenderer pointssp = Points.GetComponent<SpriteRenderer>();

            if (pointtime < pointlimit)
            {
                pointtime += Time.deltaTime;

                //点滅の処理
                if (pointlimit - pointtime < flickertime)
                {
                    itemimage.color = new Color(1, 1, 1, pointtime % 1);
                    pointssp.color = new Color(1, 1, 1, pointtime % 1);
                }

            }
            else
            {
                pointtime = 0f;
                itemimage.color = new Color(1, 1, 1, 1);
                pointssp.color = new Color(1, 1, 1, 1);
                pointitem.gameObject.SetActive(false);
                Points.gameObject.SetActive(false);
                Gamemanager.instance.ispointitem = false;
                Gamemanager.instance.isitem = false;
                itemmade = false;
            }

        }

    }
}
