using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class GameManager : MonoBehaviour {


	private GameObject CanvasMenu;
	private GameObject CanvasGame;

	void Awake(){
		DirectoryInfo dir = new DirectoryInfo ("Assets/Resources/data/");
		FileInfo[] info = dir.GetFiles ("*.png");
		GlobalValue.Files16x16 = new string[info.Length];
		for (int i = 0; i < info.Length; i++) {
			GlobalValue.Files16x16 [i] = info [i].Name;
		}
        /*
		foreach (FileInfo f in info) {
			Debug.Log ("File : " + int.Parse(f.Name.Substring(6,2)));
		}
        */
		//GlobalValue.CurrentPage = 1;

		CanvasMenu = GameObject.Find ("CanvasMenu");
		CanvasGame = GameObject.Find ("CanvasGame");
	}

	public void StartGame(){
		Debug.Log ("GameManager.StartGame");
		SceneManager.LoadScene ("Main");

        //GetComponentInParent<Canvas>().enabled = false;
		//CanvasGame.GetComponent<Canvas>().enabled = true;
		//GameObject.FindGameObjectWithTag ("CanvasGame").GetComponent<Canvas> ().enabled = true;
	}

	public void QuitGame(){
		Application.Quit ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
