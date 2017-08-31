using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour {

    public static int GetTileNum(string TileName)
    {
        TileName = TileName.Replace(GlobalValue.TILE_PREFIX, "");
        return int.Parse(TileName);
    }
    
    public static int MyIntToStr(string str)
    {
        bool isNum = false;
        int result = 0;
        isNum = int.TryParse(str, out result);
        if (!isNum)
        {
            result = 0; 
        }
        return result;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
