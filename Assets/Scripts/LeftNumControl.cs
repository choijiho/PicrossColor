using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftNumControl : MonoBehaviour {


    public void CheckRowLineOfLeftNum(int row)
    {
        string NumName = "";
        int[] ColNumOrgList = GameObject.Find("GameManager").GetComponent<GameInitialize>().GetRowsLeftNumList(GlobalValue.CurrentOrgData, row);
        int[] ColNumUsrList = GameObject.Find("GameManager").GetComponent<GameInitialize>().GetRowsLeftNumList(GlobalValue.CurrentUsrData, row);

        for (int i = 0; i < GlobalValue.LEFT_NUM_MAX; i++)
        {
            NumName = GlobalValue.LEFT_NUM_PREFIX + (row * GlobalValue.LEFT_NUM_MAX + i).ToString();
            Debug.Log("LeftNumName : " + NumName);

            if (ColNumOrgList[i] == ColNumUsrList[i])
            {
                GameObject.Find(NumName).GetComponent<Text>().color = Color.red;
            }
            else
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
