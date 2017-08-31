using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopNumControl : MonoBehaviour {


    public void CheckColLineOfTopNum(int col)
    {
		string NumName = "";
		int[] ColNumOrgList = GameObject.Find("GameManager").GetComponent<GameInitialize>().GetColsTopNumList(GlobalValue.CurrentOrgData, col);
		int[] ColNumUsrList = GameObject.Find("GameManager").GetComponent<GameInitialize>().GetColsTopNumList(GlobalValue.CurrentUsrData, col);

		for (int i = 0; i < GlobalValue.TOP_NUM_MAX; i++) {
			NumName = GlobalValue.TOP_NUM_PREFIX + (GlobalValue.CurrentTileSide * i + col).ToString ();

            if(ColNumOrgList[i] == ColNumUsrList[i])
            {
                GameObject.Find(NumName).GetComponent<Text>().color = Color.red;
            }else
            {
                GameObject.Find(NumName).GetComponent<Text>().color = Color.black;
            }
		}
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
