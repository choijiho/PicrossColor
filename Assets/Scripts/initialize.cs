using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class initialize : MonoBehaviour
{


	public GameObject GameField;
	public GameObject HorizontalNumberContainer;
	public GameObject VerticalNumberContainer;

	// prefabs
	public GameObject square;
	public GameObject number;

	// 김밥
	//private string dataSrc = "#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#f4ad3d#f4ad3d#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#f4ad3d#f4ad3d#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#000000#000000#000000#ffffff#ffffff#ffffff#ffffff#ffffff#f4ad3d#f4ad3d#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#000000#000000#000000#000000#000000#ffffff#ffffff#ffffff#f4ad3d#f4ad3d#f4ad3d#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ebba87#000000#000000#000000#000000#ffffff#ffffff#ffffff#f4ad3d#f4ad3d#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ebba87#000000#000000#000000#000000#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ebba87#000000#000000#000000#000000#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ee612b#ebba87#000000#000000#000000#000000#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ee612b#ebba87#000000#000000#000000#000000#000000#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ee612b#ebba87#000000#000000#000000#000000#000000#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ebba87#ebba87#000000#000000#000000#000000#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ebba87#ee612b#000000#000000#000000#000000#000000#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ebba87#ebba87#ee612b#000000#000000#000000#000000#000000#000000#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ebba87#ffffff#ee612b#ee612b#000000#000000#000000#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ee612b#ee612b#ee612b#000000#000000#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ee612b#ee612b#ee612b#ee612b#ee612b#ee612b#ee612b#ffffff#ffffff#ee612b#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ee612b#ee612b#ee612b#ee612b#ee612b#ee612b#ee612b#ee612b#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ee612b#ee612b#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff";
	// 인어공주
	//private string dataSrc = "#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#000000#000000#000000#000000#000000#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#000000#000000#000000#ffffff#ffffff#ffffff#000000#000000#000000#000000#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#000000#000000#000000#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#000000#000000#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#000000#000000#ffffff#ffffff#ffffff#ffffff#ff5500#ff5500#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#000000#000000#ffffff#ffffff#ffffff#ffffff#000000#ffffff#ffffff#ff5500#ff5500#ffaa00#ffaa00#ffaa00#ffaa00#ffaa00#aaff00#aaff00#ffffff#ffffff#ffffff#000000#ffffff#ffffff#ffffff#ffffff#000000#ffffff#ffffff#ffffff#ffaa00#ffaa00#ffaa00#ffaa00#ff5500#ff5500#aaff00#ffaa00#ffffff#ffffff#000000#000000#ffffff#ffffff#ffffff#ffffff#000000#000000#000000#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#000000#000000#000000#000000#ffffff#ffffff#ffffff#ffffff#000000#000000#000000#000000#000000#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#000000#000000#000000#000000#000000#ffffff#ffffff#ffffff#ffffff#000000#000000#000000#000000#000000#000000#000000#000000#000000#000000#000000#000000#000000#000000#000000#000000#ffffff#ffffff#ffffff#ffffff#000000#000000#000000#000000#000000#000000#000000#000000#000000#000000#000000#000000#000000#000000#000000#000000#ffffff#ffffff#ffffff#ffffff#000000#000000#000000#000000#ffffff#000000#000000#000000#000000#000000#000000#ffffff#000000#000000#000000#000000#ffffff#ffffff#ffffff#ffffff#000000#000000#000000#000000#000000#000000#000000#000000#000000#000000#000000#000000#000000#000000#000000#000000#ffffff#ffffff#ffffff#ffffff#000000#000000#000000#000000#000000#000000#000000#000000#000000#000000#000000#000000#000000#000000#000000#000000#ffffff#ffffff#ffffff#ffffff#000000#000000#000000#000000#000000#000000#ffffff#ffffff#ffffff#ffffff#000000#000000#000000#000000#000000#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#000000#000000#000000#000000#000000#000000#000000#000000#000000#000000#000000#000000#000000#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#000000#000000#000000#000000#000000#000000#000000#000000#000000#000000#000000#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff";
	// 좀비
	//private string dataSrc = "#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#000000#000000#000000#000000#000000#000000#000000#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#000000#000000#ff0055#ff0055#000000#000000#000000#000000#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#000000#000000#000000#000000#000000#000000#ff0055#000000#000000#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#000000#000000#ff0055#ff0055#000000#000000#000000#000000#000000#ff0055#000000#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#000000#000000#000000#ff0055#ff0055#000000#000000#000000#ff0055#ff0055#000000#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#000000#ff0055#000000#000000#000000#ffffff#ffffff#000000#000000#ffffff#000000#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#000000#000000#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#000000#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#000000#000000#ffffff#ffffff#ff0000#ffffff#ffffff#ffffff#ff0000#ffffff#000000#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#000000#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#000000#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#000000#ffffff#ffffff#ffffff#ff0000#ff0000#ff0000#ff0000#ff0000#ffffff#000000#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#000000#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ff0000#000000#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ff00ff#000000#000000#000000#000000#000000#000000#000000#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ff0000#ffaa00#ff0055#ff0055#ffaa00#ffaa00#ffaa00#ffaa00#ff0055#ff0055#ff0055#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ff0000#ff00ff#ffaa00#ff0055#ff0055#ff0055#ff0055#ffaa00#ffffff#ffffff#ff0055#ff0055#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ff0000#ff0000#ff00ff#ffaa00#ffaa00#ffaa00#ffaa00#ffaa00#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#5500ff#ff0000#ff0000#ff0000#ff00ff#ff00ff#ff00ff#ffaa00#ffaa00#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#393838#393838#393838#393838#5500ff#5500ff#5500ff#5500ff#ffffff#ffffff#ffffff#5500ff#5500ff#5500ff#5500ff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#393838#393838#393838#393838#393838#393838#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff";
	// 나무
	//private string dataSrc = "#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffaa00#ffaa00#ffaa00#ffaa00#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffaa00#ffaa00#ffaa00#ffaa00#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffaa00#ffaa00#ffaa00#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#00ff00#00ff00#00ff00#00ff00#00ff00#00ff00#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffaa00#ffaa00#ffffff#ffffff#ffffff#ffffff#ffffff#00ff55#00ff00#00ff00#ff0000#aaff00#aaff00#00ff55#ff0000#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#00ff55#00ffaa#ff0000#00ff00#aaff00#aaff00#ff0000#aaff00#00ff55#00ff55#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#00ffaa#00ffaa#00ff00#aaff00#aaff00#aaff00#aaff00#aaff00#ff0000#00ffaa#00ff55#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#55ff00#00ffaa#ff0000#00ff00#aaff00#ff0000#aaff00#aaff00#aaff00#aaff00#00ffaa#00ffaa#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#55ff00#00ff00#00ff00#00ff00#aaff00#00ff00#aaff00#aaff00#aaff00#00ff00#ff0000#00ff55#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#55ff00#ff0000#00ff00#00ff00#ff0000#00ff00#00ff00#ff0000#00ff00#aaff00#00ff55#00ffaa#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#55ff00#55ff00#00ff55#00ff55#00ff00#00ff00#00ff00#00ff00#00ff00#ff0000#00ff00#00ff00#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#55ff00#55ff00#ff0000#00ff55#00ff00#d18c00#00ff00#00ff00#00ff00#00ffaa#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#00ff00#00ff00#d18c00#d18c00#00ff00#00ff00#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ff5500#d18c00#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ff5500#d18c00#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#55ff00#55ff00#aaff00#55ff00#55ff00#ff5500#d18c00#55ff00#aaff00#55ff00#aaff00#aaff00#55ff00#ffffff#ffffff#ffffff#ffffff#55ff00#55ff00#aaff00#aaff00#aaff00#55ff00#55ff00#ff5500#ff5500#d18c00#d18c00#55ff00#55ff00#aaff00#55ff00#55ff00#aaff00#55ff00#aaff00#aaff00#aaff00#aaff00#55ff00#55ff00#55ff00#55ff00#474747#474747#474747#474747#55ff00#aaff00#55ff00#55ff00#aaff00#aaff00#55ff00#aaff00#55ff00#55ff00#55ff00#55ff00#55ff00#474747#474747#474747#474747#474747#55ff00#55ff00#55ff00#55ff00#55ff00#aaff00#55ff00#55ff00#55ff00#aaff00#55ff00#55ff00#55ff00#474747#474747#474747#474747#474747#474747#55ff00#55ff00#55ff00#aaff00#55ff00#55ff00#55ff00#55ff00#aaff00#aaff00#55ff00#55ff00#55ff00";
	// 마리오
	//private string dataSrc = "#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffcc00#ffffff#ffffff#ffffff#888888#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ff9900#ffcc00#ffffff#ffffff#888888#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ff9900#ffcc00#888888#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#888888#ff9900#ffcc00#ffcccc#ffffff#ffffff#ffffff#ffffff#ffffff#888888#aaaaaa#ffffff#ffffff#ffffff#ffffff#888888#000000#ffffff#ff9900#ee0000#ffffff#ffffff#ffffff#ffffff#ffffff#888888#aaaaaa#ffffff#ffffff#ffffff#ffffff#888888#ffffff#ffffff#ffffff#ee0000#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#888888#aaaaaa#ffffff#ffffff#333333#ffffff#555555#555555#888888#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#888888#aaaaaa#ffffff#333333#000000#ffffff#000000#ffcc00#cc9900#663300#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#888888#aaaaaa#333333#888888#ffffff#000000#ffcc00#ffcc00#ffcc00#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#888888#aaaaaa#333333#000000#ffffff#000000#cc9900#cc9900#663300#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#888888#333333#888888#ffffff#cccccc#555555#555555#888888#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#888888#333333#000000#ffffff#ffffff#cccccc#555555#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#ffffff#888888#333333#ffffff#ffffff#cccccc#888888#ffffff#ffffff#ffffff#ffffff#ffffff#aaaaaa#888888#888888#888888#888888#888888#aaaaaa#555555#555555#888888#555555#888888#ffffff#ffffff#ffffff#ffffff#aaaaaa#ffffff#eeeeee#eeeeee#eeeeee#eeeeee#3333ff#0000cc#000099#cc9900#ffcc00#ffcc00#ffffff#ffffff#ffffff#ffffff#ffffff#aaaaaa#ffffff#eeeeee#eeeeee#eeeeee#3333ff#0000cc#0000cc#0000cc#cc9900#ffcc00";
	private string dataSrc = "";

	private string[] dataSrcAry;
	private GameObject[] squares;
	private GameObject[] horizontalNumber;
	private GameObject[] verticalNumber;


	void Awake()
	{
        /*
		Debug.Log ("Awake currentdata = "+GlobalValue.CurrentData);
		//GlobalValue.CurrentData = dataSrc;
		dataSrc = GlobalValue.CurrentData;
		GlobalValue.TileCellCnt = dataSrc.Length / GlobalValue.RGB_LENGTH;
		GlobalValue.TileSideCellCnt = (int)Mathf.Sqrt(GlobalValue.TileCellCnt);
        */

	}

	// Use this for initialization
	void Start()
	{
        /*
		dataSrcAry = new string[GlobalValue.TileCellCnt];
		squares = new GameObject[GlobalValue.TileCellCnt];
		horizontalNumber = new GameObject[GlobalValue.TileSideCellCnt*GlobalValue.TOP_NUM_MAX];
		verticalNumber = new GameObject[GlobalValue.TileSideCellCnt*GlobalValue.LEFT_NUM_MAX];

		for (int i = 0; i < GlobalValue.TileCellCnt; i++)
		{
			squares[i] = (GameObject)Instantiate(square, GameField.transform);
			squares[i].name = GlobalValue.TILE_PREFIX + i.ToString();
		}
		init();
		generateVerticalNumber();
		generateHorizontalNumber();
		Debug.Log("Game Initialized");
        */

	}

	public void ChangeColor()
	{
		for (int i = 0; i < GlobalValue.TileCellCnt; i++)
		{
			dataSrcAry[i] = dataSrc.Substring((i * GlobalValue.RGB_LENGTH), GlobalValue.RGB_LENGTH);
			squares[i].GetComponent<Image>().color = parseRgbStringToColor(dataSrcAry[i]);
		}
	}

	public void init()
	{
		for (int i = 0; i < GlobalValue.TileCellCnt; i++)
		{
			dataSrcAry[i] = dataSrc.Substring((i * GlobalValue.RGB_LENGTH), GlobalValue.RGB_LENGTH);
		}
	}

	public void Complete()
	{


		for (int i = 0; i < GlobalValue.TileCellCnt; i++)
		{
			dataSrcAry[i] = dataSrc.Substring((i * GlobalValue.RGB_LENGTH), GlobalValue.RGB_LENGTH);
			if (!dataSrcAry[i].Equals(GlobalValue.WHITE))
			{
				squares[i].GetComponent<Image>().color = Color.black;
			}
			//squares [i].GetComponent<Image> ().color = parseRgbStringToColor(dataSrcAry [i]); 
		}
	}

	Color parseRgbStringToColor(string rgbstring)
	{
		Color myColor = new Color();
		ColorUtility.TryParseHtmlString(rgbstring, out myColor);
		return myColor;
	}

	void generateVerticalNumber()
	{
		for (int i = 0; i < GlobalValue.TileSideCellCnt*GlobalValue.LEFT_NUM_MAX; i++)
		{
			verticalNumber[i] = Instantiate(number, VerticalNumberContainer.transform);
			verticalNumber[i].name = GlobalValue.LEFT_NUM_PREFIX + i.ToString();
		}
		int[] result;

		for (int i = 0; i < GlobalValue.TileSideCellCnt; i++)
		{
			result = getNRowNumber(i * GlobalValue.TileSideCellCnt);
			for (int j = 0; j < result.Length; j++)
			{
				if (result[j] == 0)
				{
					verticalNumber[(i * GlobalValue.LEFT_NUM_MAX) + j].GetComponent<Text>().text = "";
				}
				else
				{
					verticalNumber[(i * GlobalValue.LEFT_NUM_MAX) + j].GetComponent<Text>().text = result[j].ToString();
				}
			}
		}
	}

	int[] getNRowNumber(int startIdx)
	{
		int[] result = new int[GlobalValue.LEFT_NUM_MAX];
		int resultIdx = GlobalValue.TOP_NUM_MAX-1;
		int tmpRepeatNum = 0;

		Debug.Log ("startIdx : " + startIdx.ToString ());
		for (int i = startIdx + GlobalValue.TileSideCellCnt- 1; i >= startIdx; --i)
		{
			//Debug.Log ("dataSrcAry["+i+"] = "+dataSrcAry[i]);

			if (!dataSrcAry[i].Equals(GlobalValue.WHITE))
			{
				tmpRepeatNum++;
				if (i == startIdx) {
					result[resultIdx] = tmpRepeatNum;
				}
			}
			else
			{
				if (tmpRepeatNum != 0)
				{
					Debug.Log ("startIdx : " + startIdx.ToString () + ", repeatNum = " + tmpRepeatNum.ToString ());
					result[resultIdx--] = tmpRepeatNum;
					tmpRepeatNum = 0;
				}
			}
		}
		return result;
	}


	void generateHorizontalNumber()
	{
		for (int i = 0; i < GlobalValue.TileSideCellCnt*GlobalValue.TOP_NUM_MAX; i++)
		{
			horizontalNumber[i] = Instantiate(number, HorizontalNumberContainer.transform);
			horizontalNumber[i].name = GlobalValue.TOP_NUM_PREFIX + i.ToString();

		}
		int[] result;

		for (int i = 0; i < GlobalValue.TileSideCellCnt; i++)
		{
			result = getNColNumber(i);
			for (int j = 0; j < result.Length; j++)
			{
				if (result[j] == 0)
				{
					horizontalNumber[(j * GlobalValue.TileSideCellCnt) + i].GetComponent<Text>().text = "";
				}
				else
				{
					horizontalNumber[(j * GlobalValue.TileSideCellCnt) + i].GetComponent<Text>().text = result[j].ToString();
				}
			}
		}
	}

	// 0 ~ 380
	int[] getNColNumber(int startIdx)
	{
		int[] result = new int[GlobalValue.TOP_NUM_MAX];
		int resultIdx = GlobalValue.TOP_NUM_MAX - 1;
		int tmpRepeatNum = 0;

		for (int i = GlobalValue.TileCellCnt - GlobalValue.TileSideCellCnt + startIdx; i >= startIdx; i -= GlobalValue.TileSideCellCnt)
		{
			if (!dataSrcAry[i].Equals(GlobalValue.WHITE))
			{
				tmpRepeatNum++;
				if (i == startIdx) {
					result[resultIdx] = tmpRepeatNum;
				}
			}
			else
			{
				if (tmpRepeatNum != 0)
				{
					result[resultIdx--] = tmpRepeatNum;
					tmpRepeatNum = 0;
				}
			}
		}
		return result;
	}

	// Update is called once per frame
	void Update()
	{

	}
}
