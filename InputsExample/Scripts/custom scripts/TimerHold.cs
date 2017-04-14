using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerHold : MonoBehaviour {

	public float targetTime = 60.0f;

	void Update(){

		targetTime -= Time.deltaTime;

		if (targetTime <= 0.0f)
		{
			this.GetComponent<nodeIndex>().active = true;
			//timerEnded();
		}

	}

	void timerEnded()
	{
	}
}
