using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour 
{
	// code generates random numbers for BodyRenderer to use.
	// **dependant on the presence of BodyRenderer


	private int maxHead;
	private int maxLeg;
	private int maxTail;
	private int maxMane;
	private int maxEar;
	private int maxHorn;
	private int maxPelt;
	private int maxEye;

	public int NumberHead = 0;
	public int NumberLeg = 0;
	public int NumberTail = 0;
	public int NumberMane = 0;
	public int NumberEar = 0;
	public int NumberHorn = 0;
	public int NumberPelt = 0;
	public int NumberEye = 0;

	// Use this for initialization
	void Start () 
	{
		//bellow code fetches how many body parts exist in the renderer code for each option
		//I tried to make this into a function but it wouldn't calculate it

		foreach (GameObject Head in gameObject.transform.GetComponent<BodyRenderer>().Heads) 
		{
			maxHead++;
		}

		foreach (GameObject Leg in gameObject.transform.GetComponent<BodyRenderer>().Legs) 
		{
			maxLeg++;
		}

		foreach (GameObject Tail in gameObject.transform.GetComponent<BodyRenderer>().Tails) 
		{
			maxTail++;
		}
		foreach (GameObject Mane in gameObject.transform.GetComponent<BodyRenderer>().Manes) 
		{
			maxMane++;
		}
		foreach (GameObject Ear in gameObject.transform.GetComponent<BodyRenderer>().Ears) 
		{
			maxEar++;
		}
		foreach (GameObject Horn in gameObject.transform.GetComponent<BodyRenderer>().Horns) 
		{
			maxHorn++;
		}
		foreach (Material Pelt in gameObject.transform.GetComponent<BodyRenderer>().Pelts) 
		{
			maxPelt++;
		}
		foreach (Material Eye in gameObject.transform.GetComponent<BodyRenderer>().Eyes) 
		{
			maxEye++;
		}

		//generates each number taking into account how many possibilities there is for each point
		NumberHead = (Random.Range(0,maxHead));
		NumberLeg = (Random.Range(0,maxLeg));
		NumberTail = (Random.Range(0,maxTail));
		NumberMane = (Random.Range(0,maxMane));
		NumberEar = (Random.Range(0,maxEar));
		NumberHorn = (Random.Range(0,maxHorn));
		NumberPelt = (Random.Range(0,maxPelt));
		NumberEye = (Random.Range(0,maxEye));

		//reaches into the generator code to give the random generated numbers to generate
		gameObject.transform.GetComponent<BodyRenderer>().HeadNumber = NumberHead;
		gameObject.transform.GetComponent<BodyRenderer>().LegNumber = NumberLeg;
		gameObject.transform.GetComponent<BodyRenderer>().TailNumber = NumberTail;
		gameObject.transform.GetComponent<BodyRenderer>().ManeNumber = NumberMane;
		gameObject.transform.GetComponent<BodyRenderer>().EarNumber = NumberEar;
		gameObject.transform.GetComponent<BodyRenderer>().HornNumber = NumberHorn;
		gameObject.transform.GetComponent<BodyRenderer>().PeltSelector = NumberPelt;
		gameObject.transform.GetComponent<BodyRenderer>().EyeSelector = NumberEye;

		//turns on the generator into the bodyrenderer to reload the new numbers
		gameObject.transform.GetComponent<BodyRenderer>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
