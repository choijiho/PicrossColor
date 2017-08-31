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

    public void SetClickModeToX()
    {
        GlobalValue.ClickMode = GlobalValue.ClickState.X;
    }

    public void SetClickModeTocheck()
    {
        GlobalValue.ClickMode = GlobalValue.ClickState.Check;

    }

    public void Hint()
    {
		List<int> HintTargetList = new List<int> ();	

        for(int i=0; i<GlobalValue.CurrentOrgData.Length; i++)
        {
            if(GlobalValue.CurrentOrgData[i] != Color.white && 
                GlobalValue.CurrentUsrData[i] != Color.black)
            {
                HintTargetList.Add(i);
            }
        }
		int findIdx = Random.Range (0, HintTargetList.Count);
        GameObject.Find(GlobalValue.TILE_PREFIX + HintTargetList[findIdx]).GetComponent<TileControl>().TileClicked();
    }

    public void AnswerCheck()
    {
        Reset();
        for(int i=0; i<GlobalValue.CurrentOrgData.Length; i++)
        {
            if(GlobalValue.CurrentOrgData[i] != Color.white)
            {
                GameObject.Find(GlobalValue.TILE_PREFIX + i).GetComponent<Image>().color = Color.black;
            }
        }
    } 

    public void AnswerCheckColor()
    {
        Reset();
        for(int i=0; i<GlobalValue.CurrentOrgData.Length; i++)
        {
            if(GlobalValue.CurrentOrgData[i] != Color.white)
            {
                GameObject.Find(GlobalValue.TILE_PREFIX + i).GetComponent<Image>().color = GlobalValue.CurrentOrgData[i];
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
