using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RayCasting : MonoBehaviour {

	public int VirusKilled;
	RaycastHit hit;
	public static float speeding = 0.01f;
	public TextMesh score;
	public static int points = 0;
	public static bool gameover = false;

	// Use this for initialization
	void Start () 
	{
		VirusKilled = 0;	
	}
	
	// Update is called once per frame
	void Update () 
	{
		score.text = "Score: " + points;

		if (!gameover) 
		{
			points += 10;


		}
		Ray ray = new Ray ();

		ray.origin = GameObject.Find("ARCamera").transform.position;
		ray.direction =  GameObject.Find("ARCamera").transform.forward;

		if (Physics.Raycast (ray, out hit, 1000000f)) {
			if (hit.transform.tag == "Virus") 
			{
				Destroy (hit.transform.gameObject);
				VirusKilled++;
			}

		}

		//Killed enough viruses in current level
		if (InputExampleManager.level == 1) {
			if (VirusKilled == 2) {
				InputExampleManager.level++;
				SceneManager.LoadScene ("Level" + InputExampleManager.level);
			}
		} else if (InputExampleManager.level == 2) {
			if (VirusKilled == 12) {
				InputExampleManager.level++;
				SceneManager.LoadScene ("Level" + InputExampleManager.level);
			}
		}
		else 
		{
			if (VirusKilled == 16) {
				InputExampleManager.level = 1;
				speeding += 0.01f;
				SceneManager.LoadScene ("Level" + InputExampleManager.level);

			}
		}
	}




}
