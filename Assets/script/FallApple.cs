using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Const;

public class FallApple : MonoBehaviour
{

    private float fallSpeed;

    private float waitTime = 0;
    private bool waitFlg = false;

    private bool poisonAppleFlg = false;
    private int gimmickNumber = 0;

    private int appleType;

    //GameObject kago;//=GameObject.Find("kago");


    GameObject kago;

    // Use this for initialization
    void Start()
    {



        fallSpeed = Random.Range(0.05f, 0.4f);

        if (this.gameObject.tag == "Poison")
        {
            poisonAppleFlg = true;
            gimmickNumber = Random.Range(0, 4);
            //if (gimmickNumber == 4)
            //    kago = GameObject.Find("kago");


        }



        kago = GameObject.Find("kago");
    }

    // Update is called once per frame
    void Update()
    {
        if (waitFlg)
        {
            switch (appleType)
            {
                case CO.RED:
                case CO.GREEN:
                    transform.Translate(0, -fallSpeed, 0);
                    break;

                case CO.POISON:
                    switch (gimmickNumber)
                    {
                        case 0:
                            transform.Translate(0, -fallSpeed, 0);
                            break;
                        case 1:
                            transform.Translate(0.1f, -fallSpeed, 0);
                            break;
                        case 2:
                            transform.Translate(-0.1f, -fallSpeed, 0);
                            break;
                        case 3:
                            transform.Translate(Random.Range(-1f, 1f), -fallSpeed, 0);
                            break;
                    }
                    break;

                case CO.KIYOHITO:
                    if (transform.position.y > -1.5f)
                        transform.position = new Vector2(kago.transform.position.x, transform.position.y - fallSpeed);
                    else
                        transform.Translate(0, -fallSpeed, 0);
                    break;
            }

            if (transform.position.y < -5.5f)
            {
                Destroy(gameObject);
            }

        }
        else
        {
            waitTime += Time.deltaTime;
            if (waitTime > 1)
            {
                waitFlg = true;
            }
        }


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }


    public void SetAppleType(int type)
    {
        appleType = type;
    }
}