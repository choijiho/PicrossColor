using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ButtonManager : MonoBehaviour {

    public initialize ini;

    public void ChangeColor()
    {
        Debug.Log("Buttonmanager changeCOlor");
        ini.ChangeColor();
    }

    public void Complete()
    {
        Debug.Log("Buttonmanager complete");
        ini.Complete();
    }

	public void Pre(){
		if (GlobalValue.CurrentPage > 1) {
			GlobalValue.CurrentPage--;
			SceneManager.LoadScene( SceneManager.GetActiveScene ().name);
		}

	}
	public void Next(){
		if (GlobalValue.CurrentPage < GlobalValue.Files16x16.Length) {
			GlobalValue.CurrentPage++;
			SceneManager.LoadScene( SceneManager.GetActiveScene ().name);
		}

	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
