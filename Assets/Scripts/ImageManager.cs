using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour {

	public enum TILE_STATE
	{
		check 
		,none
		,x
	}

	public TILE_STATE ts;

	void Awake()
	{
		ts = TILE_STATE.none;
	}

	public void Down()
	{
		GlobalValue.IsDown = true;
		clickToggle();
	}

	public void Enter()
	{
		if(GlobalValue.IsDown == true)
		{
			clickToggle();
		}
	}

	public void Up()
	{
		GlobalValue.IsDown = false;
	}

	public void Back(){
		SceneManager.LoadScene ("GameList");
	}

	public void clickToggle()
	{
		Image img = gameObject.GetComponent<Image>();
		ImageManager mng = gameObject.GetComponent<ImageManager>();


		if(GlobalValue.ClickMode == GlobalValue.ClickState.Check)
		{
			if (img.color.Equals(Color.black)) {
				mng.ts = TILE_STATE.none;
			}else
			{
				mng.ts = TILE_STATE.check;
			}
		}else if(GlobalValue.ClickMode == GlobalValue.ClickState.X) {

			if(img.sprite == null)
			{
				mng.ts = TILE_STATE.x;
			}else
			{
				mng.ts = TILE_STATE.none;
			}  
		}

		ChangeTileVisual(mng.ts);
		CheckHorizontalNum();
		CheckVerticalNum();
		CheckComplete ();
	}

	void CheckComplete(){
		//string AnswerData = GlobalValue.CurrentData;
		string UserData = GetUserCheckedData ();
		//Debug.Log(IsEqualsData(AnswerData, UserData));
	}

	string GetUserCheckedData(){
		string result="";
		Color tmp;
		//int PivotIdx = int.Parse(gameObject.GetComponent<Image>().name.Substring(5)) / 20 * 5 ;
		for (int i = 0; i < GlobalValue.TileCellCnt; i++) {
			tmp = GameObject.Find ("TILE_" + i.ToString ()).GetComponent<Image> ().color;
			if (tmp.Equals (Color.white)) {
				result += GlobalValue.WHITE;
			} else {
				result += GlobalValue.BLACK;
			}
		}
		return result;
	}

	bool IsEqualsData(string answer, string user){
		string answerCompareColor="";

		for (int i = 0; i < GlobalValue.TileCellCnt; i++) {
			answerCompareColor = answer.Substring (i * GlobalValue.RGB_LENGTH, GlobalValue.RGB_LENGTH);
			if (!answerCompareColor.Equals (GlobalValue.WHITE)) {
				answerCompareColor = GlobalValue.BLACK;
			}
			if (!user.Substring (i * GlobalValue.RGB_LENGTH, GlobalValue.RGB_LENGTH).Equals (answerCompareColor)) {
				return false;	
			}
		}
		return true;
	}

	bool IsEqualsNotWhiteData(string answer, string user){
		string answerCompareColor="";

		for (int i = 0; i < GlobalValue.TileCellCnt; i++) {
			answerCompareColor = answer.Substring (i * GlobalValue.RGB_LENGTH, GlobalValue.RGB_LENGTH);
			if (!answerCompareColor.Equals (GlobalValue.WHITE)) {
				if (user.Substring (i * GlobalValue.RGB_LENGTH, GlobalValue.RGB_LENGTH).Equals (GlobalValue.WHITE)) {
					return false;	
				}
			}
		}
		return true;
	}

	void ChangeTileVisual(TILE_STATE _TILE_STATE)
	{
		Image img = gameObject.GetComponent<Image>();
		Sprite SpriteX = Resources.Load<Sprite>("Images/x_icon");

		switch (_TILE_STATE)
		{
		case TILE_STATE.none:
			img.sprite = null  ;
			img.color = Color.white;
			break;
		case TILE_STATE.check:
			img.sprite = null  ;
			img.color = Color.black;
			break;
		case TILE_STATE.x:
			img.sprite = SpriteX;
			img.color = Color.black;
			break;
		}
	}

	static bool ArraysEqual<T>(T[] a1, T[] a2)
	{
		if (ReferenceEquals(a1, a2))
			return true;

		if (a1 == null || a2 == null)
			return false;

		if (a1.Length != a2.Length)
			return false;

		EqualityComparer<T> comparer = EqualityComparer<T>.Default;
		for (int i = 0; i < a1.Length; i++)
		{
			if (!comparer.Equals(a1[i], a2[i])) return false;
		}
		return true;
	}

	void CheckVerticalNum()
	{
		int[] VerticalNumList;
		int[] TileCheckList;

		VerticalNumList = GetVerticalNums();
		TileCheckList = GetCheckedVerticalTileList();

		if(ArraysEqual<int>(VerticalNumList, TileCheckList))
		{
			SetVerticalNumColor(Color.red);
		}else
		{
			SetVerticalNumColor(Color.black);
		}
	}

	void SetVerticalNumColor(Color color)
	{
		int PivotIdx = int.Parse(gameObject.GetComponent<Image>().name.Substring(5)) / GlobalValue.TileSideCellCnt * GlobalValue.LEFT_NUM_MAX;
		for(int i=PivotIdx; i<PivotIdx+GlobalValue.LEFT_NUM_MAX; i++)
		{
			string HNUMname = GlobalValue.LEFT_NUM_PREFIX + i.ToString();
			Text txt = GameObject.Find(HNUMname).GetComponent<Text>();
			if (!string.IsNullOrEmpty(txt.text)) 
			{
				txt.color = color;
			}
		}
	}

	int[] GetCheckedVerticalTileList()
	{
		List<int> list = new List<int>();
		int[] result;
		bool isCheckStarted = false;
		int accumulatedCount = 0;

		int TilePivotIdx = int.Parse(gameObject.GetComponent<Image>().name.Substring(5)) / GlobalValue.TileSideCellCnt *GlobalValue.TileSideCellCnt;
		for(int i=TilePivotIdx; i<TilePivotIdx+GlobalValue.TileSideCellCnt; i++)
		{
			string TileName = GlobalValue.TILE_PREFIX + i.ToString();
			ImageManager mng = GameObject.Find(TileName).GetComponent<ImageManager>();
			if(mng.ts == TILE_STATE.check)
			{
				isCheckStarted = true;
				accumulatedCount++;
			}else
			{
				if(accumulatedCount > 0)
				{
					Debug.Log ("Check list : " + accumulatedCount.ToString ());
					list.Add(accumulatedCount);
					accumulatedCount = 0;
				}
				isCheckStarted = false;
			}
		}
		result = list.ToArray();

		return result;
	}

	int[] GetVerticalNums()
	{
		List<int> list = new List<int>();

		int[] result;

		string name = gameObject.GetComponent<Image>().name.Substring(5);
		int idx = (int.Parse(name) / GlobalValue.TileSideCellCnt) * GlobalValue.LEFT_NUM_MAX;

		GameObject[] Horizontal = new GameObject[5];
		for(int i=idx; i<idx+5; i++)
		{
			string HNUMname = GlobalValue.LEFT_NUM_PREFIX + i.ToString();
			string text = GameObject.Find(HNUMname).GetComponent<Text>().text;
			if (!string.IsNullOrEmpty(text)) 
			{
				list.Add(int.Parse(text));
			}
		}
		result = list.ToArray();
		return result;
	}


	void CheckHorizontalNum()
	{
		int[] HorizontalNumList;
		int[] TileCheckList;

		HorizontalNumList = GetHorizontalNums();
		TileCheckList = GetCheckedHorizontalTileList();

		if(ArraysEqual<int>(HorizontalNumList, TileCheckList))
		{
			SetHorizontalNumColor(Color.red);
		}else
		{
			SetHorizontalNumColor(Color.black);
		}
	}

	void SetHorizontalNumColor(Color color)
	{
		int PivotIdx = int.Parse(gameObject.GetComponent<Image>().name.Substring(5)) % GlobalValue.TileSideCellCnt;
		for(int i=PivotIdx; i<GlobalValue.TileSideCellCnt*GlobalValue.TOP_NUM_MAX; i+=GlobalValue.TileSideCellCnt)
		{
			string HNUMname = GlobalValue.TOP_NUM_PREFIX + i.ToString();
			Text txt = GameObject.Find(HNUMname).GetComponent<Text>();
			if (!string.IsNullOrEmpty(txt.text)) 
			{
				txt.color = color;
			}
		}
	}

	int[] GetCheckedHorizontalTileList()
	{
		List<int> list = new List<int>();
		int[] result;
		bool isCheckStarted = false;
		int accumulatedCount = 0;

		int TilePivotIdx = int.Parse(gameObject.GetComponent<Image>().name.Substring(5)) % GlobalValue.TileSideCellCnt;
		for(int i=TilePivotIdx; i<GlobalValue.TileCellCnt; i += GlobalValue.TileSideCellCnt)
		{
			string TileName = GlobalValue.TILE_PREFIX + i.ToString();
			ImageManager mng = GameObject.Find(TileName).GetComponent<ImageManager>();
			if(mng.ts == TILE_STATE.check)
			{
				isCheckStarted = true;
				accumulatedCount++;
			}else
			{
				if(accumulatedCount > 0)
				{
					list.Add(accumulatedCount);
					accumulatedCount = 0;
				}
				isCheckStarted = false;
			}
		}
		result = list.ToArray();

		return result;
	}

	int[] GetHorizontalNums()
	{
		List<int> list = new List<int>();

		int[] result;

		string name = gameObject.GetComponent<Image>().name.Substring(5);
		int idx = int.Parse(name) % GlobalValue.TileSideCellCnt;

		GameObject[] Horizontal = new GameObject[GlobalValue.TOP_NUM_MAX];
		for(int i=idx; i<GlobalValue.TileSideCellCnt*GlobalValue.TOP_NUM_MAX; i+=GlobalValue.TileSideCellCnt)
		{
			string HNUMname = GlobalValue.TOP_NUM_PREFIX + i.ToString();
			string text = GameObject.Find(HNUMname).GetComponent<Text>().text;
			if (!string.IsNullOrEmpty(text)) 
			{
				list.Add(int.Parse(text));
			}
		}
		result = list.ToArray();
		return result;
	}

	public void SetClickModeToX()
	{
		GlobalValue.ClickMode = GlobalValue.ClickState.X;
	}

	public void SetClickModeTocheck()
	{
		GlobalValue.ClickMode = GlobalValue.ClickState.Check;

	}

	public void HintCheck(){
		//string AnswerData = GlobalValue.CurrentData;
		string UserData = GetUserCheckedData ();
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

	public void Reset(){
        Debug.Log("LENGTH : " + GlobalValue.CurrentOrgData.Length.ToString());
		for (int i = 0; i < GlobalValue.CurrentOrgData.Length; i++) {
			GameObject.Find (GlobalValue.TILE_PREFIX+i).GetComponent<Image> ().color = Color.white;
			GameObject.Find (GlobalValue.TILE_PREFIX+i).GetComponent<Image> ().sprite = null;
		}
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
