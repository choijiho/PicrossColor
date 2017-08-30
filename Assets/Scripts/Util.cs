using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour {

    public static int GetTileNum(string TileName)
    {
        TileName = TileName.Replace(GlobalValue.TILE_PREFIX, "");
        return int.Parse(TileName);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
