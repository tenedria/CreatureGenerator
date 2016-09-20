using UnityEngine;
using System.Collections;

public class BodyRenderer : MonoBehaviour 
{
// ================================================
// 		BODY RENDERER
//		*spawns the body parts and changes textures
// ================================================

//Series of numbers behaving like DNA
	[Header("SELECTOR")]
	public int HeadNumber;
	public int LegNumber;
	public int TailNumber;
	public int ManeNumber;
	public int EarNumber;
	public int HornNumber;
	public int PeltSelector;
	public int EyeSelector;

//Editable Arrays of body parts
	[Header("GAMEOBJECTS")]
	public GameObject[] Heads;
	public GameObject[] Legs;
	public GameObject[] Tails;
	public GameObject[] Manes;
	public GameObject[] Ears;
	public GameObject[] Horns;

//Object to spawn and possition relative to the base body
	private GameObject Head;
	private Vector3 HeadPos = new Vector3(0,1.43f,0.03f);
	private GameObject Leg;
	private Vector3 LegPos = new Vector3(0,0,0);
	private GameObject Tail;
	private Vector3 TailPos = new Vector3(0,0,0);
	private GameObject Mane;
	private Vector3 ManePos = new Vector3(0,1.551f,0f);
	private GameObject Ear;
	private Vector3 EarPos = new Vector3(0,1.23f,-0.1f);
	private GameObject Horn;
	private Vector3 HornPos = new Vector3(0,1.40f,0);

//temporary identifier to retrieve the spawned object after it is spawned
	//GameObjects
	private GameObject tempHead;
	private GameObject tempLeg;
	private GameObject tempTail;
	private GameObject tempMane;
	private GameObject tempEar;
	private GameObject tempHorn;


//Functions to spawn each object
	void spawnAll(GameObject tempObject, GameObject bodyPart, Vector3 bodyPos)
	{
		tempObject = Instantiate (bodyPart) as GameObject;
		tempObject.transform.parent = gameObject.transform;
		tempObject.transform.localPosition = bodyPos;
		tempObject.SetActive (true);
	}


// ================================================
// 		TEXTURES
//		*changes textures
// ================================================
	//Number to identify the materials

	private int eyeNumeral;
	private int peltNumeral;

	[Header("TEXTURES")]
	//Eyes
	public Material[] Eyes;
	private Material[] HeadTextures;
	private Material newEye;
	//Pelt
	public Material[] Pelts;
	private Material newPelt;

	//function renames gameobjects to their tag's name
	void RenameBody(string BodyParttoRename)
	{
		GameObject[] bodyparts = GameObject.FindGameObjectsWithTag (BodyParttoRename);
		foreach (GameObject bodypart in bodyparts) 
		{
			bodypart.name = BodyParttoRename;
		}
	}


	// ** Essential BugFixing Code
	//this code identifies the order of the materials linked on the head (because there is 2)
	void materialTest()
	{
		RenameBody("Head");
		tempHead = gameObject.transform.FindChild ("Head").gameObject;
		//Debug.Log ("material 0 is : " + tempHead.transform.GetComponent<MeshRenderer> ().materials [0].mainTexture.name);
		if (tempHead.transform.GetComponent<MeshRenderer> ().materials [0].mainTexture.name == "Pelt_test") 
		{
			PeltSwitch (1,0);
		}

		else 
		{
			PeltSwitch (0,1);
		}
	}
	//This code switches the current materials to the appropriate ones
	void PeltSwitch(int eyeno, int peltno)
	{
		//EYE SWITCH
		newEye = Eyes [EyeSelector];
		HeadTextures = tempHead.transform.GetComponent<MeshRenderer>().materials;
		HeadTextures[eyeno].mainTexture = newEye.mainTexture;

		//PElT SWITCH
		newPelt = Pelts [PeltSelector];
		HeadTextures[peltno].mainTexture = newPelt.mainTexture;
		gameObject.transform.GetComponent<MeshRenderer> ().materials[0].mainTexture = newPelt.mainTexture;

		//findLeg
		RenameBody("Feet");
		tempLeg = gameObject.transform.FindChild("Feet").gameObject;
		tempLeg.transform.GetComponent<MeshRenderer> ().material.mainTexture = newPelt.mainTexture;


		if(Ear.gameObject.tag == "Ear")
		{
			RenameBody("Ear");
			tempEar = gameObject.transform.FindChild("Ear").gameObject;
			tempEar.transform.GetComponent<MeshRenderer> ().materials[0].mainTexture = newPelt.mainTexture;
		}

		if(Mane.gameObject.tag == "Mane")
		{
			RenameBody("Mane");
			tempMane = gameObject.transform.FindChild("Mane").gameObject;
			tempMane.transform.GetComponent<MeshRenderer> ().materials[0].mainTexture = newPelt.mainTexture;
		}

		if(Tail.gameObject.tag == "Tail")
		{
			RenameBody("Tail");
			tempTail = gameObject.transform.FindChild("Tail").gameObject;
			tempTail.transform.GetComponent<MeshRenderer> ().materials[0].mainTexture = newPelt.mainTexture;
		}
		if(Horn.gameObject.tag == "Horn")
		{
			RenameBody("Horn");
			tempHorn = gameObject.transform.FindChild("Horn").gameObject;
			//can change horn texture using code bellow
			//tempHorn.transform.GetComponent<MeshRenderer> ().materials[0].mainTexture = newPelt.mainTexture;
		}
	}

	void peltbodySwitch(GameObject bodyPelt)
	{
		bodyPelt.transform.GetComponent<MeshRenderer> ().material.mainTexture = newPelt.mainTexture;
	}




	public void generateBody()
	{
		//spawns all the body parts
		spawnAll (tempHead,Head,HeadPos);
		spawnAll (tempLeg, Leg, LegPos);
		spawnAll (tempTail, Tail, TailPos);
		spawnAll (tempMane, Mane, ManePos);
		spawnAll (tempEar, Ear, EarPos);
		spawnAll (tempHorn, Horn, HornPos);

		//changes the material on the body parts
		materialTest ();
	}

	// Use this for initialization
	void Start () 
	{
		//identifies body parts
		Head = Heads[HeadNumber];
		Leg = Legs[LegNumber];
		Tail = Tails[TailNumber];
		Mane = Manes[ManeNumber];
		Ear = Ears[EarNumber];
		Horn = Horns [HornNumber];

		generateBody ();
	}


	void Update()
	{
		;
	}
}
