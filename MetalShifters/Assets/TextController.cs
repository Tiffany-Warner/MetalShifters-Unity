using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	//Access modifier so we can change text value in Unity
	public Text text; 
	
	private enum States{ Intro, House_0, House_1, Dresser, Closet,
	Bed, Glasses, Hospital, Rubble, Warehouse, Basement, Battlefield 
	};
	
	private States myState;
	private int endurance = 100;
	
	//Search Areas Status
	private bool bedChecked = false;
	private bool dresserChecked = false;
	private bool closetChecked = false;
	
	//Items status
	private bool glassesAcquired = false;
		
	// Use this for initialization
	void Start () {
		myState = States.Intro;
	}
	
	// Update is called once per frame
	void Update () {
			if  	(myState == States.Intro) 				{intro();} 
			else if (myState == States.House_0)				{house_0();}
			else if (myState == States.House_1)				{house_1();}
			else if (myState == States.Dresser)				{dresser();}
			else if (myState == States.Bed)					{bed();}
			else if (myState == States.Glasses)				{glasses();}
			else if (myState == States.Closet)				{closet();}
			else if (myState == States.Hospital)			{hospital();}
			else if (myState == States.Rubble)				{rubble();}
			else if (myState == States.Warehouse)			{warehouse();}
			else if (myState == States.Basement) 			{basement();}
			else if (myState == States.Battlefield)			{battlefield();}
			else if (endurance <= 0 )						{loseGame ();}
		
}
	
	
	#region State handler methods
	void intro(){
		text.text = "Metal Shifters : Alien Invasion " +
			"\n\nA hoard of alien creatures known by humans as Virulatrons have waged a" +
				" full force attack on earth in search of a powerful artifact known as the AlphaAtom." +
				"\n\nA group of Metal Shifters called the Automatons are trying to help humanity fight" + 
				" back, but they need your help, puny human. Their leader, Optimus Jack" +
				" has asked you to locate and retrieve the AlphaAtom before ColossalTron, the leader" +
				" of the Virulatrons, can claim it.\n" +
				"\n Be wary and pay attention to your endurance...                  " +
				"\n\n                                       Press Space key to continue.";
		if(Input.GetKeyDown(KeyCode.Space))				{myState = States.House_0;}
	}
	void house_0(){
		text.text = "Endurance : " + endurance +
					"\nYou are standing in your house. You can hear sirens in the distance." +
					" There's no time to waste. The Virulatrons are everywhere. It's time" +
					" to begin the search." +
					"\n\nPress D to search the dresser," + 
					"\nPress C to search the closet, " + 
					"\nPress B to search under the bed." +
					"\n\nPress up arrow to go to the abandoned Warehouse across the street." + 
					"\nPress down arrow to go behind your house to the deserted Hospital." +
					"\nPress <- arrow to head west towards the raging Battlefield" +
					"\nPress -> arrow to head east towards some building rubble."; 
	
		
		if(Input.GetKeyDown(KeyCode.D))							{myState = States.Dresser;}
		else if(Input.GetKeyDown(KeyCode.C))					{myState = States.Closet;}
		else if(Input.GetKeyDown(KeyCode.B))					{myState = States.Bed;}
		else if(Input.GetKeyDown(KeyCode.UpArrow))				{myState = States.Warehouse;}
		else if(Input.GetKeyDown(KeyCode.DownArrow))			{myState = States.Hospital;}
		else if(Input.GetKeyDown(KeyCode.LeftArrow))			{myState = States.Battlefield;}
		else if(Input.GetKeyDown(KeyCode.RightArrow))			{myState = States.Rubble;}
	}
	void house_1(){
		text.text = "Endurance : " + endurance +
			"\nGreat! Now you have some pretty cool glasses and a set of coordinates." +
				" It's probably time to start looking for more clues or find someone who" +
				" knows something about what those coordinates mean. The coordinates seem" +
				" indicate a direction northeast of you." +
				"\n\nPress D to search the dresser," + 
				"\nPress C to search the closet, " + 
				"\nPress B to search under the bed." +
				"\n\nPress up arrow to go to the abandoned Warehouse across the street." + 
				"\nPress down arrow to go behind your house to the deserted Hospital." +
				"\nPress <- arrow to head west towards the raging Battlefield" +
				"\nPress -> arrow to head east towards some building rubble."; 
		
		
		if(Input.GetKeyDown(KeyCode.D))							{myState = States.Dresser;}
		else if(Input.GetKeyDown(KeyCode.C))					{myState = States.Closet;}
		else if(Input.GetKeyDown(KeyCode.B))					{myState = States.Bed;}
		else if(Input.GetKeyDown(KeyCode.UpArrow))				{myState = States.Warehouse;}
		else if(Input.GetKeyDown(KeyCode.DownArrow))			{myState = States.Hospital;}
		else if(Input.GetKeyDown(KeyCode.LeftArrow))			{myState = States.Battlefield;}
		else if(Input.GetKeyDown(KeyCode.RightArrow))			{myState = States.Rubble;}
	
	}
	void dresser(){
		if (dresserChecked == true){
			text.text = "Endurance : " + endurance +
						"\n\n\n\nNope.. Nothing spontaneously appeared in here." +
						"\n\nPress Space key to continue...";

		} else {
			text.text = "Endurance : " + endurance +
						"\n\n\n\nYou rummage through the dresser. Nothing interesting..." +
						"\n\nPress Space key to continue...";
		}
					
		
		if     (Input.GetKeyDown(KeyCode.Space) && glassesAcquired == true)	{myState = States.House_1; dresserChecked = true;}
		else if(Input.GetKeyDown(KeyCode.Space))				{myState = States.House_0; dresserChecked = true;}
	
	}
	void bed(){
		if (bedChecked && glassesAcquired){
			text.text = "Endurance : " + endurance +
						"\n\nHmmm.... You probably should get going or you could keep looking at" +
						" the moldy sandwich. The fate of the entire world is in your hands." +
						" No pressure. " +
						"\n\nPress Space key to continue...";
		}
		else if(bedChecked && !glassesAcquired){
			text.text = "Endurance : " + endurance +
						"\n\nYup there's still a moldy sandwich. Hey! Maybe that sparkling object is" +
						" important." +
						"\n\nPress I to inspect sparkling object" +
						"\nPress R to forget about the sparkling object and return to room";
		} 
		else{  
	   		text.text = "Endurance : " + endurance +
						"\n\nOh look! A moldy sandwich.. How'd that get under here?! ooOoo" +
						" What's that shiny thing over there? " +
						"\n\nPress I to inspect sparkling object." +
						"\nPress R to forget about the sparkling object and return to room.";
	}
		
		if     	(Input.GetKeyDown(KeyCode.Space) && glassesAcquired)    	{myState = States.House_1;}
		else if (Input.GetKeyDown(KeyCode.I) && !glassesAcquired)			{myState = States.Glasses; bedChecked = true;}
		else if (Input.GetKeyDown(KeyCode.R) && !glassesAcquired)			{myState = States.House_0; bedChecked = true;}
		else if (Input.GetKeyDown(KeyCode.R) && glassesAcquired)			{myState = States.House_1; bedChecked = true;}
	}
	
	void glasses(){
		text.text = "Endurance : " + endurance +
					"\n\nYou've found the a pair of spectacularly shiny glasses. You fiddle with them" +
					" for a bit and just when you think it couldn't get any better, the glasses " +
					" start to glow. Suddenly, it projects a hologram with a set of " +
					" coordinates. That might be important." +
					"\n\nPress T to take the glasses." +
					"\nPress R to place the glasses back down next to the moldy sandwich" +
					" and return to your room.";

		if      (Input.GetKeyDown(KeyCode.T))				{myState = States.House_1; glassesAcquired = true;}
		else if (Input.GetKeyDown(KeyCode.R))				{myState = States.House_0;}
	}
	void closet(){
		if (closetChecked == true){
			text.text = "Endurance : " + endurance +
				"\n\n\n\nNope.. Nothing spontaneously appeared in here." +
					"\n\nPress Space key to continue...";
			
		} else {
			text.text = "Endurance : " + endurance +
				"\n\n\n\nYou realize you really need to get around to organizing things in here." +
				" You pick through a few items but there's only clothes, shoes, and some random" +
				" knick knacks." +
				"\n\nPress Space key to continue...";
		}
		if     (Input.GetKeyDown(KeyCode.Space) && glassesAcquired == true)	{myState = States.House_1; closetChecked = true;}	
		else if(Input.GetKeyDown(KeyCode.Space))				{myState = States.House_0; closetChecked = true;}
	
	}
	void hospital(){
		text.text = "You're at the hospital!";
	
	}
	void rubble(){
		text.text = "You're in some rubble!";
	}
	void warehouse(){
		text.text = "You're at the warehouse";
	}
	void basement(){
		text.text = "You're in the basement!";
	}
	void battlefield(){
		text.text = "You're at the battlefield!";
	}
	void loseGame(){
		text.text = "Oh no! Your endurance ran out.\nYou cry to Optimus Jack as you collapse" +
					" from fatigue... But it's no use... Optimus Jack is incapable of finding" +
					" the AlphaAtom without the help of his weak, fragile human friend. Suddenly, out" +
					" of nowhere, ColossalTron appears laughingly maniacally. Without your " +
					" help, Optimus Jack has lost his morale is overtaken by ColossalTron..." +
					" while you lay on the ground watching in horror.\n\nThe Virulatrons have" +
					" acquired the AlphaAtom and the World is doomed. \n\nAll hail ColossalTron. "; 
	}
	void winGame(){
		text.text = "You won!";
	}

	#endregion
}
