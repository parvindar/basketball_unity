using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class replay : MonoBehaviour {


	private basketball basketball;
	private timer timer;
	private Touchmanager touchmanager;


	void Start () {
		basketball = FindObjectOfType<basketball> ();
		timer = FindObjectOfType<timer> ();


			}
	

	public void reset()
	{
		timer.time = 0;
		basketball.resetposition ();
	}

	void Update () {
		
	
	}


}
