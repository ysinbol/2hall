using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour {

    private float speed = 0.1f;     //透明化速度
    private float alpha = 2.5f;                    //α値操作
    float red, green, blue = 0;         //RGB操作
    public float next;

    // Use this for initialization
    void Start()
    {
        //Panelの色取得
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
    }

    // Update is called once per frame
    void Update()
    {
        next += Time.deltaTime;

        //フェードイン処理
        if (next < 2.5f)
        {

            GetComponent<Image>().color = new Color(red, green, blue, alpha);
            alpha -= speed;
        }

        //フェードアウト処理
        else if (next >= 2.5f)
        {
            GetComponent<Image>().color = new Color(red, green, blue, alpha);
            alpha += speed;
        }

        if (next >= 5)
        {
            next = 5;
        }
    }
}
