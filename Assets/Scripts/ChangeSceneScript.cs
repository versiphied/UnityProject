using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //allows script to use scene manager to talk to other scenes
using UnityEngine.UI;
public class ChangeSceneScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)){//changes to game scene if space key is pressed
            SceneManager.LoadScene(1);

        }
	}
}
