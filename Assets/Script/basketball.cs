using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class basketball : MonoBehaviour {
	
	public Text score;
	public int currentscore=0;
	public Vector3 initialposition;
	public Vector3 initialrotation;
	private Touchmanager touchmanager;


	void Start()
	{
		touchmanager = FindObjectOfType<Touchmanager> ();
		initialposition = this.transform.position;


	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag== "ring")
		{
			scoreupdate();
		}
	}




	private void scoreupdate()
	{
		currentscore++;
		score.text = currentscore.ToString ();
		resetposition ();

	}

	public void resetposition()
	{
		this.GetComponent<Rigidbody> ().useGravity = false;
		this.GetComponent<Rigidbody> ().velocity = Vector3.zero;
		this.transform.position = initialposition;
		this.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		touchmanager.canswipe = true;
	}


	}

