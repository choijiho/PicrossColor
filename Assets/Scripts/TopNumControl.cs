using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopNumControl : MonoBehaviour {


    public void CheckColLineOfTopNum(int col)
    {
		string TopNumName = "";
		int[] ColNumList = GameObject.Find("GameManager").GetComponent<GameInitialize>().GetColsTopNumList(col);
		string TopNum = "";

		for (int i = 0; i < GlobalValue.TOP_NUM_MAX; i++) {

			TopNumName = GlobalValue.TOP_NUM_PREFIX + (GlobalValue.CurrentTileSide * i + col).ToString ();
			Debug.Log ("TOPNU<NAME : " + TopNumName);
			TopNum = GameObject.Find (TopNumName).GetComponent<Text> ().text;
			Debug.Log ("TOPNUM[" + i + "] : " + TopNum);

			//GameObject.Find(TopNumName)


			//GetColsTopNumList
		}

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
