using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	//Access modifier so we can change text value in Unity
	public Text text; 

	// Use this for initialization
	void Start () {
		text.text = "Hello World.";
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			text.text = "Space key pressed.";
		}
	}
}
