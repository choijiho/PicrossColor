using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour {

//	public GameManager gameManager;


	public void StartGame(){
		Debug.Log ("MenuControl.StartGame");
		SceneManager.LoadScene ("GameList");
//		gameManager.StartGame ();
	}

	public void QuitGame(){
//		gameManager.QuitGame ();
	}

	// Use this for initialization
	void Start () {

		Debug.Log ("START");
	}

	// Update is called once per frame
	void Update () {
		
	}
}
