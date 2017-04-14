using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class virusPath : MonoBehaviour {

	public GameObject[] nodeUsers;
	public Transform[] nodes;
	private int currentNode;
	public float reachDistance = 1.0f;
	public float speed;


	// Use this for initialization
	void Start () {
		currentNode = 0;
		//add indexing for individual nodes
		for (int i =0; i < nodeUsers.Length; i++)
			nodeUsers[i].AddComponent<nodeIndex>();
		nodeUsers[0].GetComponent<nodeIndex>().active = true;
	}

	// Update is called once per frame
	void Update () {
		Debug.Log(currentNode);

		Vector3 dir = new Vector3();
		for (int i =0; i < nodeUsers.Length; i++)
		{
			if (nodeUsers [i] != null) 
			{
				if (nodeUsers[i].GetComponent<nodeIndex>().active)
				{
					dir = nodes [nodeUsers[i].GetComponent<nodeIndex>().val].position - nodeUsers[i].transform.position;
					nodeUsers[i].transform.position += dir * RayCasting.speeding;// * Time.deltaTime;

					//if reached node goto next node
					if (dir.magnitude <= reachDistance) {
						nodeUsers[i].GetComponent<nodeIndex>().val++;
						Debug.Log( (nodeUsers[i].GetComponent<nodeIndex>().val - 1) +"going to next node");
					}

					//if reaches final node game over
					if (nodeUsers[i].GetComponent<nodeIndex>().val == nodes.Length-1)
					{
						nodeUsers[i].GetComponent<nodeIndex>().val = 0;
						RayCasting.gameover = true;
						SceneManager.LoadScene("Game Over Scene");
						Debug.Log("Player Lost");
					}
				}
			}
		
		}
	}

}
