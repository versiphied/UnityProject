using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonContent : MonoBehaviour {

    public Text buttonContent;

	// Use this for initialization
	void Start () {
		if(buttonContent == null)
        {
            Debug.LogError("There is no button text reference!");
        }
        else
        {
            buttonContent.transform.parent.GetComponent<RectTransform>();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
