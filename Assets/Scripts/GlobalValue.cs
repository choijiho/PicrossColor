using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalValue : MonoBehaviour {

	public static bool IsDown = false;

	public enum ClickState
	{
		Check
		,X
	}
	public static ClickState ClickMode = ClickState.Check;


	//public static string CurrentData = "";
	public static string CurrentImgName = "";

    // Set tile side from user request
    public static int CurrentTileSide = 16; 
	public static int CurrentPage=1;
    public static Color[] CurrentData;

    // CROP coordinate X, Y
    public static int X;
    public static int Y;

	public static string[] Files16x16;

	// Tile total count
	public static int TileCellCnt = 0;

	// One side tile count
	public static int TileSideCellCnt = 0;

	// RGB LENGTH ex) #fffffff
	public const int RGB_LENGTH = 7;

	// TOP number row count 
	public const int TOP_NUM_MAX = 5;
	// LEFT number col count 
	public const int LEFT_NUM_MAX = 5;

	// RGB CODE
	public const string WHITE = "#ffffff";
	public const string BLACK = "#000000";

	// Tile, Top number, Left number cell name prefix
	public const string TILE_PREFIX = "TILE_";
	public const string LEFT_NUM_PREFIX = "LNUM_";
	public const string TOP_NUM_PREFIX = "TNUM_";

	public const int PREFIX_LENGTH = 5;

}
