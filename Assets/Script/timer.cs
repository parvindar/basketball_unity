using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class timer : MonoBehaviour {

	public Text _timer;
	public bool gameover;
	public float time;

	public basketball basketball;

	void Start () {
		time = 0;
		gameover = false;


	}

	void timerfunc()
	{
		int min;
		float sec;
		min = (int)time / 60;
		sec = time % 60;
		_timer.text = min + ":" + sec.ToString("f2");
	}
	void FixedUpdate () {
		if(gameover==false)
		time = (time + Time.fixedDeltaTime/Time.timeScale);
		timerfunc ();
		endgame ();
		
	}
	void endgame()
	{
		if (time >= 60) {
			basketball.transform.position = basketball.initialposition;
			basketball.transform.localRotation = Quaternion.Euler (basketball.initialrotation);
			gameover = true;
		}
	}


}
