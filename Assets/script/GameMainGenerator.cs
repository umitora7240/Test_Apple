using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using Const;

public class GameMainGenerator : MonoBehaviour
{

    [SerializeField] GameObject[] applePrefab; //プレハブ

    private float intervalTime = 0;

    private static int score = 0;
    private float timeLimit=30;

    private Text scoreText;
    private Text timeLimitText;


    // Use this for initialization
    void Start()
    {
        score = 0;

        scoreText = GameObject.Find("Score").GetComponent<Text>();
        timeLimitText = GameObject.Find("TimeLimit").GetComponent<Text>();
        scoreText.text = score.ToString();
        timeLimitText.text = timeLimit.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        intervalTime += Time.deltaTime;
        if (intervalTime > 0.05f)
        {
            float randomWidth = Random.Range(-8.4f, 8.4f);
            float randomHeight = Random.Range(1.3f, 5f);

            int randomApple = Random.Range(0, 110);
            if (randomApple < 20)
                randomApple = CO.RED;
            else if (randomApple < 80)
                randomApple = CO.GREEN;
            else if (randomApple < 100)
                randomApple = CO.POISON;
            else
                randomApple = CO.KIYOHITO;

            GameObject instanceApple= Instantiate(applePrefab[randomApple], new Vector3(randomWidth, randomHeight, 0), Quaternion.identity);
            instanceApple.GetComponent<FallApple>().SetAppleType(randomApple);

            intervalTime = 0;
        }


        scoreText.text = score.ToString();
        timeLimitText.text = timeLimit.ToString("F1");

        if (timeLimit <= 0)
        {
                SceneManager.LoadScene("GameResult");

        }
        timeLimit -= Time.deltaTime;
        



        //scoreText.
        
        //.GetComponent<Text>().text = score.ToString()


        //Debug.Log("score" + score);
    }

    public void AddScore(int type)
    {
        switch (type)
        {
            case CO.RED:
                score += 30;
                break;
            case CO.GREEN:
                score += 10;
                break;
            case CO.POISON:
                score += -20;
                break;
            case CO.KIYOHITO:
                score += -50;
                break;
        }
    }


    public static int GetScore()
    {
        return score;
    }
}