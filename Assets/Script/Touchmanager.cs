using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touchmanager : MonoBehaviour {

	private float initialtouchtime;
	private float finaltouchtime;
	private Vector2 initialtouchposition;
	private Vector2 finaltouchposition;
	private float Xaxisforce;  // velocity on x axis.
	private float Yaxisforce; // velocity on y axis.
	private float Zaxisforce; // velocity on z axis.
	private float yforce;
	private Vector3 requiredforce;
	public bool canswipe;

	private Vector3 initialposition;
	private timer time;


	public basketball ball;



	void Start()
	{
		ball = FindObjectOfType<basketball> ();
		initialposition = ball.transform.position;
		Time.timeScale = 3; // speed up the game by by 3 times.
		ball.GetComponent<Rigidbody>().useGravity = false;
		canswipe = true;



	}

	public void ontouchdown() // gets call when mouse is pressed.
	{
		initialtouchtime = Time.time;
		initialtouchposition = Input.mousePosition;
	}

	public void ontouchup() // gets call when mouse is released.
	{
		finaltouchtime = Time.time;
		finaltouchposition = Input.mousePosition;


		ballthrow();



	}

	private void ballthrow ()
	{
		if (canswipe) {
			Xaxisforce = finaltouchposition.x - initialtouchposition.x; // force on x axis.
			Yaxisforce = (finaltouchposition.y - initialtouchposition.y); // force on y axis.
			Zaxisforce = 40 / ((finaltouchtime - initialtouchtime) + 1);
			if (Yaxisforce < 0)
				yforce = -Mathf.Sqrt (-Yaxisforce);
			else yforce = Mathf.Sqrt (Yaxisforce);

			requiredforce = new Vector3 (-Xaxisforce/4, yforce*2.4f, -Zaxisforce);

			ball.GetComponent<Rigidbody>().useGravity = true;
			ball.GetComponent<Rigidbody>().velocity = requiredforce;

			canswipe = false;
			Invoke ("reset", 7);
		}
	

	}

	void reset()
	{
		ball.resetposition ();
	}

	void Update()
	{
		
	}







}