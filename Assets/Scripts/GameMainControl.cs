using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMainControl : MonoBehaviour {

    void Awake()
    {

    }

    public void Reset()
    {
        Debug.Log("RESET");
        for (int i = 0; i < GlobalValue.CurrentOrgData.Length; i++)
        {
            GameObject.Find(GlobalValue.TILE_PREFIX + i).GetComponent<Image>().color = Color.white;
            GameObject.Find(GlobalValue.TILE_PREFIX + i).GetComponent<Image>().sprite = null;
            GlobalValue.CurrentUsrData[i] = Color.white;
        }
        NumsReset("TopNum");
        NumsReset("LeftNum");
    }


    private void NumsReset(string ComponentName)
    {
        Text[] Nums = GameObject.Find(ComponentName).GetComponentsInChildren<Text>();
        for(int i=0; i<Nums.Length; i++)
        {
            Nums[i].color = Color.black;
        }
    }

    public void Hint()
    {
        //string AnswerData = GlobalValue.CurrentData;
        //string UserData = GetUserCheckedData();
        /*
		if(IsEqualsNotWhiteData(AnswerData, UserData)){
			return;
		}
		List<int> AnswerNotWhiteList = new List<int> ();	


		string TmpAsnwerData = "";
		for (int i = 0; i < GlobalValue.TileCellCnt; i++) {
			TmpAsnwerData = AnswerData.Substring (i * GlobalValue.RGB_LENGTH, GlobalValue.RGB_LENGTH);
			if (!TmpAsnwerData.Equals (GlobalValue.WHITE)) {
				AnswerNotWhiteList.Add (i);
			}	
		}
		Debug.Log ("AnswerNotWhiteList length : " + AnswerNotWhiteList.Count);
		int findIdx = 0;
		while(true){
			findIdx = Random.Range (0, AnswerNotWhiteList.Count);
			Debug.Log ("idx value : " + AnswerNotWhiteList [findIdx]);
			if (UserData.Substring (AnswerNotWhiteList[findIdx] * 7, 7).Equals (GlobalValue.WHITE)) {
				GameObject.Find (GlobalValue.TILE_PREFIX + AnswerNotWhiteList[findIdx]).GetComponent<Image> ().color = Color.black;
				break;
			}
		}
        */
    }

        // Use this for initialization
        void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
