using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Const;



public class GameTitle : MonoBehaviour
{
    GameMainGenerator aaaa;

    private Text text_start;
    private Text text_ranking;
    private Text text_end;

    int choice = 0;     //0:GameMain    1:GameRanking   2:GameEnd

    // Use this for initialization
    void Start()
    { 



        text_start = GameObject.Find("Text_start").GetComponent<Text>();
        text_ranking = GameObject.Find("Text_ranking").GetComponent<Text>();
        text_end = GameObject.Find("Text_end").GetComponent<Text>();

        

        //StringSplitOptions.RemoveEmptyEntries
        //System.StringSplitOptions.RemoveEmptyEntries


        //Debug.Log(("12345").PadLeft(10));
        //Debug.Log(("12345").PadRight(10) + ":" + "a");
        //Debug.Log("    あいうえお　　かきくけこ　　");
        ////　前後の空白を取り除く
        //Debug.Log("    あいうえお　　かきくけこ　　".Trim());
        ////　前の空白を取り除く
        //Debug.Log("    あいうえお　　かきくけこ　　".TrimStart());
        ////　後ろの空白を取り除く
        //Debug.Log("    あいうえお　　かきくけこ　　".TrimEnd());
    }

    // Update is called once per frame
    void Update()
    {

        //float button=Input.GetAxisRaw("Vertical");


        if (Input.GetButtonDown("Up"))
        {
            if (--choice < 0)
                choice = 2;
        }
        else if (Input.GetButtonDown("Down"))
        {
            if (++choice > 2)
            {
                choice = 0;
            }
        }

        switch (choice)
        {
            case 0:    //GameMain
                //text_start.color = new Color(255 / 255, 0, 0);
                text_start.fontSize = 70;
                text_ranking.fontSize = 50;
                text_end.fontSize = 50;
                if (Input.GetButtonDown("Decision"))
                {
                    SceneManager.LoadScene("GameMain");
                }
                break;
            case 1:     //GameRanking
                text_start.fontSize = 50;
                text_ranking.fontSize = 70;
                text_end.fontSize = 50;
                if (Input.GetButtonDown("Decision"))
                {
                    SceneManager.LoadScene("GameRanking");
                }

                break;
            case 2:     //GameEnd
                text_start.fontSize = 50;
                text_ranking.fontSize = 50;
                text_end.fontSize = 70;
                if (Input.GetButtonDown("Decision"))
                {
                    SceneManager.LoadScene("GameEnd");
                }

                break;
        }



    }
}