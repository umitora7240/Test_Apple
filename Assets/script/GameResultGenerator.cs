using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System;

public class GameResultGenerator : MonoBehaviour
{

    [SerializeField] private TextAsset textAsset;

    private string[] splitText;

    private Text playerScoreText;
    private Text rankingText;

    private string loadText;

    StreamWriter streamWriter;

    //FileInfo fi;

    //StreamWriter streamWriter2;

    int playerScore;
    string temp;
    int tempScore;



    private int[] rankingScore;
    private string[] rankingScoreKey;
    // Use this for initialization
    void Start()
    {
        loadText = textAsset.text;
        splitText = new string[6];
        splitText = loadText.Split(char.Parse("\n"));

        playerScore = GameMainGenerator.GetScore();

        playerScoreText = GameObject.Find("PlayerScore").GetComponent<Text>();
        playerScoreText.text = GameMainGenerator.GetScore().ToString();
        rankingText = GameObject.Find("RankingScore").GetComponent<Text>();
        rankingText.text = null;


        //foreach (var i in rankingScoreKey)
        //{
        //    int temp = int.Parse(i);
        //    if (playerScore >= temp)
        //    {

        //    }
        //}

        //for (int i = 0; i < rankingScoreKey.Length; i++)
        //{
        //    PlayerPrefs.SetInt(rankingScoreKey[i], rankingScore[i]);
        //}

        rankingScore = new int[5];
        rankingScoreKey = new string[5];
        for (int i = 0; i < rankingScore.Length; i++)
        {
            rankingScore[i] = PlayerPrefs.GetInt(rankingScoreKey[i], 0);
        }
        //foreach (var i in rankingScore)
        //{
        //    Debug.Log(i);
        //}
        //PlayerPrefs.DeleteAll();
        bool flag = false;
        for (int i = 0; i < rankingScore.Length && !flag; i++)
        {
            if (playerScore >= rankingScore[i])
            {
                Debug.Log(i);
                for (int j = rankingScore.Length - 1; j > i; j--)
                {
                    rankingScore[j] = rankingScore[j - 1];
                }
                rankingScore[i] = playerScore;
                flag = true;
            }
        }
        for (int i = 0; i < rankingScore.Length; i++)
        {
            PlayerPrefs.SetInt(rankingScoreKey[i], rankingScore[i]);
        }

        for (int i = 0; i < rankingScore.Length; i++)
        {
            rankingText.text += rankingScore[i].ToString() + "\n";

        }

        //Debug.Log(PlayerPrefs.GetInt(rankingScoreKey[2]));


        //fi = new FileInfo(Application.dataPath + "/RankingText.txt");
        //streamWriter = fi.AppendText();

        //streamWriter.WriteLine("test output");
        //streamWriter.Flush();
        //streamWriter.Close();

        //File.WriteAllLines(textAsset.text, splitText);




        //foreach(var i in splitText)
        //{
        //    Debug.Log(i);
        //}
        //streamWriter2=new StreamWriter(textAsset,)


        //splitText[2] = "bbbb";
        //File.WriteAllLines(Application.dataPath + "/RankingText.txt", splitText);


        //Compare();
        //Debug.Log(splitText.Length);








    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Decision"))
        {
            SceneManager.LoadScene("GameTitle");
        }



    }


    int Compare()
    {
        for(int i = 0; i < 5; i++)
        {
            //splitText[i].Length
            temp = splitText[i].Substring(2);
            tempScore = int.Parse(temp);
            //Debug.Log(1 + score);
            if (playerScore >= tempScore)
            {
                sort(i);
                
                return 0;
            }
        }
        return -1;
    }

    void sort(int number)
    {
        for (int i = 4; i > number; i--)
        {
            string temp = splitText[i - 1].Substring(2);
            splitText[i] = (i +1).ToString() + " " + temp;
            if (i == splitText.Length - 1)
            {
                Debug.Log("test");
                splitText[i] = splitText[i].TrimEnd();
            }
        }
        splitText[number] = (number+1).ToString() + " " + playerScore.ToString();

        File.WriteAllLines(Application.dataPath + "/RankingText.txt", splitText);

    }


}