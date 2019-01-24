using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Const;

public class kagoController : MonoBehaviour
{

    private const float speed = 15;

    GameMainGenerator gameMainGeneratorScript;

    // Use this for initialization
    void Start()
    {

        gameMainGeneratorScript = GameObject.Find("GameMainGenerator").GetComponent<GameMainGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.position = new Vector2(Mathf.Clamp(transform.position.x + horizontal * speed * Time.deltaTime, CO.SCREEN_X_MIN, CO.SCREEN_X_MAX), transform.position.y);
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Red":
                gameMainGeneratorScript.AddScore(CO.RED);
                break;

            case "Green":
                gameMainGeneratorScript.AddScore(CO.GREEN);
                break;

            case "Poison":
                gameMainGeneratorScript.AddScore(CO.POISON);
                break;
        }
        Destroy(collision.gameObject);

    }
}
