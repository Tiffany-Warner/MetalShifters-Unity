using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	//Access modifier so we can change text value in Unity
	public Text text; 
	
	private enum States{ Intro, House_0, House_1, Hospital, Rubble, Warehouse, Basement, Battlefield };
	
	private States myState;
	private int endurance = 100;
	
	// Use this for initialization
	void Start () {
		myState = States.Intro;
	}
	
	// Update is called once per frame
	void Update () {
		if  	(myState == States.Intro) 				{intro();} 
		else if (myState == States.House_0)				{house_0();}
	}
	void intro(){
		text.text = "\nMetal Shifters : Alien Invasion " +
			"\n\nA hoard of alien creatures known by humans as Virulatrons have waged a" +
				"full force attack on earth in search of a powerful artifact known as the AlphaAtom." +
				"\n\nA group of Metal Shifters called the Automatons are trying to help humanity fight" + 
				"back, but they need your help to keep them distracted. Their leader, Optimus Jack" +
				"has asked you to locate and retrieve the AlphaAtom before Colossaltron, the leader" +
				"of the Virulatrons, can claim it.\n" +
				"\n Be wary and pay attention to your endurance...                  " +
				"       Press Space key to continue.";
		if(Input.GetKeyDown(KeyCode.Space))				{myState = States.House_0;}
	}
	void house_0(){
		text.text = "Endurance : " + endurance +
					"\nYou are standing in your house. You can hear sirens in the distance." +
					" There's no time to waste. The virulatrons are everywhere. It's time" +
					" to begin the search.";
	}
}
