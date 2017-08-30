using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameInitialize : MonoBehaviour {
    // TODO : check tile side
    private int TILE_SIDE;
    private int[] TopNums;
    private int[] LeftNums;


    void Awake()
    {
        TILE_SIDE = GlobalValue.CurrentTileSide;
        GlobalValue.CurrentData = new Color[TILE_SIDE*TILE_SIDE];
	    TopNums = new int[TILE_SIDE * GlobalValue.TOP_NUM_MAX];
	    LeftNums = new int[TILE_SIDE * GlobalValue.LEFT_NUM_MAX];

        GenerateTile();
        SetTopNum();
        SetLeftNum();
    }

    void GenerateTile()
    {
        GameObject TileZone = GameObject.Find("TileZone");
        string fileName = string.Format("data/16_{0:D2}", GlobalValue.CurrentPage);
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
                GlobalValue.CurrentData[idx++] = make.GetPixel(x, y);
				Button GridTile = NewObj.AddComponent<Button>();
				Image GridTileImg = NewObj.AddComponent<Image> ();
                TileControl TileControl = NewObj.AddComponent<TileControl>();
				ImageManager ImgMng = NewObj.AddComponent<ImageManager> ();
				GridTileImg.color = make.GetPixel (x, y);
				GridTile.image = GridTileImg;
                //GridTile.onClick.AddListener(() => TileControl.TileClicked(NewObj.name));
                //GridTile.onClick.AddListener(() => TileControl.TileClicked());
                NewObj.transform.SetParent(TileZone.transform, false);
            }
        }
    }


    void SetTopNum()
    {
		GameObject TopNum = GameObject.Find ("TopNum");
		int[] result = new int[GlobalValue.TOP_NUM_MAX];	
        for (int colIdx = 0; colIdx < TILE_SIDE; colIdx++)
        {
			result = GetColsTopNumList (colIdx);
			for (int i = 0; i < result.Length; i++) {
				TopNums [(i * TILE_SIDE) + colIdx] = result [i];
			}
        }
		for (int i = 0; i < TopNums.Length; i++) {
			GenerateNumTile(TopNums[i]).transform.SetParent (TopNum.transform, false);
		}
    }


    private int[] GetColsTopNumList(int col)
    {
        int[] result = new int[GlobalValue.TOP_NUM_MAX];
        int resultIdx = GlobalValue.TOP_NUM_MAX - 1;
        int repeatNum = 0;

		for(int rowIdx=TILE_SIDE-1; rowIdx>=0; rowIdx--)
        {
            if (GlobalValue.CurrentData[rowIdx * TILE_SIDE + col].Equals(Color.white)){
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

	void SetLeftNum(){
		GameObject LeftNum = GameObject.Find ("LeftNum");
		int[] result = new int[GlobalValue.LEFT_NUM_MAX];	
		for (int rowIdx = 0; rowIdx < TILE_SIDE; rowIdx++)
        {
			result = GetRowsLeftNumList(rowIdx);
			for (int i = 0; i < result.Length; i++) {
				LeftNums[rowIdx*GlobalValue.LEFT_NUM_MAX+i] = result [i];
			}
        }
		for (int i = 0; i < LeftNums.Length; i++) {
			GenerateNumTile(LeftNums[i]).transform.SetParent (LeftNum.transform, false);
		}
	}

	int[] GetRowsLeftNumList(int row){
        int[] result = new int[GlobalValue.LEFT_NUM_MAX];
        int resultIdx = GlobalValue.LEFT_NUM_MAX - 1;
        int repeatNum = 0;

		for(int colIdx=TILE_SIDE-1; colIdx>=0; colIdx--)
        {
			if (GlobalValue.CurrentData[row * TILE_SIDE + colIdx].Equals(Color.white)){
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


	GameObject GenerateNumTile(int num){
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
