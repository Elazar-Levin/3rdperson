using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class respawn : MonoBehaviour {
	public static int LevelNo=0;
	private Vector3 v;
	private Quaternion q;
	// Use this for initialization
	void Start () 
	{
			v=transform.position;
			q=transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void nextLevel()
	{
		LevelNo++;
		if(LevelNo>1)
		{
			LevelNo=0;
		}
		//Application.LoadLevel(LevelNo);
		SceneManager.LoadScene(LevelNo);
	}
	void OnTriggerEnter(Collider trig)
	{
		if(trig.tag=="death")
		{
			transform.position=v;
			transform.rotation=q;
			GetComponent<Animator>().Play("LOSE00",-1,0f);
			GetComponent<Rigidbody>().velocity=new Vector3(0f,0f,0f);
			GetComponent<Rigidbody>().angularVelocity=new Vector3(0f,0f,0f);
		}
		if(trig.tag=="checkpoint")
		{
			v=trig.transform.position;
			q=trig.transform.rotation;
			Destroy(trig.gameObject);
		}
		if(trig.tag=="goal")
		{
			GetComponent<Animator>().Play("WIN00",-1,0f);
			Invoke("nextLevel",2f);
			
		}
	}
}
