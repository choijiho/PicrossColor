using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameListTile : MonoBehaviour {


	public void MoveMain(){
		GlobalValue.CurrentImgName = gameObject.name;
		//GlobalValue.CurrentData = GameObject.Find ("Canvas").GetComponent<GameListManager> ().GetItem (GlobalValue.CurrentImgName).data;
		SceneManager.LoadScene ("Main");
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
