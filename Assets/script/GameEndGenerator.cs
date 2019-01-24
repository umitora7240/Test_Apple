using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndGenerator : MonoBehaviour {


    float endTime = 3;
    float endCountTime=0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        endCountTime += Time.deltaTime;
        if (endCountTime >= endTime)
            UnityEditor.EditorApplication.isPlaying = false;
    }
}
