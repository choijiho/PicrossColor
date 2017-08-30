using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInitialize : MonoBehaviour {
    private const int TILE_SIDE = 16;
    private Color[] data = new Color[TILE_SIDE*TILE_SIDE];
    private GameObject[] tiles;
	private int[] TopNums = new int[TILE_SIDE * GlobalValue.TOP_NUM_MAX];
	private int[] LeftNums = new int[TILE_SIDE * GlobalValue.LEFT_NUM_MAX];
    private GameObject TopNum;
    private GameObject LeftNum;
    

    void Awake()
    {
        GameObject TileZone = GameObject.Find("TileZone");
		TopNum = GameObject.Find ("TopNum");
		LeftNum = GameObject.Find ("LeftNum");
        string fileName = string.Format("data/16_{0:D2}", GlobalValue.CurrentPage);
        Debug.Log("Filename : " + fileName);
        Debug.Log("X : " + GlobalValue.X.ToString());
        Debug.Log("Y : " + GlobalValue.Y.ToString());

        Texture2D img = (Texture2D)Resources.Load(fileName);

        Texture2D make = new Texture2D(TILE_SIDE, TILE_SIDE);
        make.SetPixels(img.GetPixels(GlobalValue.X, GlobalValue.Y, TILE_SIDE, TILE_SIDE));
        make.Apply();

        int idx = 0;
        for (int y = make.height - 1; y >= 0; y -= 1)
        {
            for (int x = 0; x < make.width; x += 1)
            {
                GameObject NewObj = new GameObject(); //Create the GameObject
				NewObj.name = GlobalValue.TILE_PREFIX+idx.ToString();
                //NewObj.name = x + ", " + y;
                data[idx++] = make.GetPixel(x, y);
				Button GridCell = NewObj.AddComponent<Button>();
				Image GridCellImg = NewObj.AddComponent<Image> ();
				ImageManager ImgMng = NewObj.AddComponent<ImageManager> ();
				GridCellImg.color = make.GetPixel (x, y);
				GridCell.image = GridCellImg;
				GridCell.onClick.AddListener(()=>GridTileClick(NewObj.name));
                NewObj.transform.SetParent(TileZone.transform, false);
            }
        }
        setTopNum();
        setLeftNum();
    }

	/**
	 * OnClick event for cell click
	 */
	void GridTileClick(string TileName){
		GameObject tile = GameObject.Find (TileName);
		Image img = tile.GetComponent<Image> ();
		ImageManager mng = gameObject.GetComponent<ImageManager>();


		if(GlobalValue.ClickMode == GlobalValue.ClickState.Check)
		{
			if (tile.GetComponent<Image>().color.Equals(Color.black)){
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


    Color[] GeneratorDataFromImage()
    {
        Color[] result = null;
        GameObject TileZone = GameObject.Find("TileZone");

        string fileName = string.Format("data/16_{0:D2}", GlobalValue.CurrentPage);
        Debug.Log("Filename : " + fileName);
        Debug.Log("X : " + GlobalValue.X.ToString());
        Debug.Log("Y : " + GlobalValue.Y.ToString());

        Texture2D img = (Texture2D)Resources.Load(fileName);

        Texture2D make = new Texture2D(TILE_SIDE, TILE_SIDE);
        make.SetPixels(img.GetPixels(GlobalValue.X, GlobalValue.Y, TILE_SIDE, TILE_SIDE));
        make.Apply();

        int idx = 0;
        for(int i=0; i<TILE_SIDE; i++)
        {
            for(int j=0; j<TILE_SIDE; j++)
            {
                data[idx++] = make.GetPixel(i, j);
                GameObject NewObj = new GameObject(); //Create the GameObject
                Image GridImg = NewObj.AddComponent<Image>(); //A
                GridImg.sprite = Sprite.Create(make, new Rect(i, j, 1, 1), new Vector2());
                NewObj.transform.SetParent(TileZone.transform, false);
            }
        }
                //GridImg.color = Color.yellow;
               // NewObj.transform.SetParent(Grid.transform, false);
        return result;
    }

    void setTopNum()
    {
		int[] result = new int[GlobalValue.TOP_NUM_MAX];	
        for (int colIdx = 0; colIdx < TILE_SIDE; colIdx++)
        {
			result = getColsTopNumList (colIdx);
			for (int i = 0; i < result.Length; i++) {
				TopNums [(i * TILE_SIDE) + colIdx] = result [i];
			}
        }
		for (int i = 0; i < TopNums.Length; i++) {
			generateNumTile(TopNums[i]).transform.SetParent (TopNum.transform, false);
		}
    }


    private int[] getColsTopNumList(int col)
    {
        int[] result = new int[GlobalValue.TOP_NUM_MAX];
        int resultIdx = GlobalValue.TOP_NUM_MAX - 1;
        int repeatNum = 0;

		for(int rowIdx=TILE_SIDE-1; rowIdx>=0; rowIdx--)
        {
            if (data[rowIdx * TILE_SIDE + col].Equals(Color.white)){
                if (repeatNum != 0)
                {
                    result[resultIdx--] = repeatNum;
                    repeatNum = 0;
                }
            }else
            {
                repeatNum++;
                if(rowIdx == 0)
                {
                    result[resultIdx] = repeatNum;
                }
            }
        }
        return result;
    }

	void setLeftNum(){
		int[] result = new int[GlobalValue.LEFT_NUM_MAX];	
		for (int rowIdx = 0; rowIdx < TILE_SIDE; rowIdx++)
        {
			result = getRowsLeftNumList(rowIdx);
			for (int i = 0; i < result.Length; i++) {
				LeftNums[rowIdx*GlobalValue.LEFT_NUM_MAX+i] = result [i];
			}
        }
		for (int i = 0; i < LeftNums.Length; i++) {
			generateNumTile(LeftNums[i]).transform.SetParent (LeftNum.transform, false);
		}
	}

	int[] getRowsLeftNumList(int row){
        int[] result = new int[GlobalValue.LEFT_NUM_MAX];
        int resultIdx = GlobalValue.LEFT_NUM_MAX - 1;
        int repeatNum = 0;

		for(int colIdx=TILE_SIDE-1; colIdx>=0; colIdx--)
        {
			if (data[row * TILE_SIDE + colIdx].Equals(Color.white)){
                if (repeatNum != 0)
                {
                    result[resultIdx--] = repeatNum;
                    repeatNum = 0;
                }
            }else
            {
                repeatNum++;
				if(colIdx == 0)
                {
                    result[resultIdx] = repeatNum;
                }
            }
        }
        return result;

	}



	GameObject generateNumTile(int num){
		GameObject NumCell = new GameObject ();
		NumCell.name = num.ToString ();
		Text NumCellText = NumCell.AddComponent<Text> ();
		NumCellText.text = num==0?"":num.ToString();
		NumCellText.color = Color.black;
		NumCellText.fontSize = 27;
		NumCellText.resizeTextForBestFit = false;
		NumCellText.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
		NumCellText.alignment = TextAnchor.MiddleCenter;

		return NumCell;
	}



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
