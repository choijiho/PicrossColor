using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameListManager : MonoBehaviour {

	public class Item{
		public string img_name;
		public int type;
		public string is_complete_yn;
		public string data;
		public Item(string _img_name, int _type, string _is_complete_yn, string _data){
			img_name = _img_name;
			type = _type;
			is_complete_yn = _is_complete_yn;
			data = _data;

		}
	}


	private List<Item> Items = new List<Item>();
	private GameObject Grid;
	private GameObject square;
	private GameObject[] Tiles;
	private const int TILE_SIDE = 16;

	void Awake(){
		/*
		Grid = GameObject.Find ("Grid");
		square = (GameObject)Resources.Load ("prefabs/ListTile");
		Tiles = new GameObject[36];
		GameObject.Find ("Page").GetComponent<Text> ().text = GlobalValue.CurrentPage.ToString();
		LoadGridItems ();
*/
		dispatchImages ();
	}

	void dispatchImages(){
		Grid = GameObject.Find ("Grid");

		GameObject.Find ("Page").GetComponent<Text> ().text = GlobalValue.CurrentPage.ToString();
		string fileName = string.Format ("data/16_{0:D2}", GlobalValue.CurrentPage);
		Debug.Log ("Filename : " + fileName);
		Texture2D img = (Texture2D)Resources.Load (fileName);

		for (int y = img.height-TILE_SIDE; y >= 0; y -= TILE_SIDE) {
			for (int x = 0; x < img.width; x += TILE_SIDE) {
				Texture2D make = new Texture2D (TILE_SIDE, TILE_SIDE);
				make.SetPixels (img.GetPixels (x, y, TILE_SIDE, TILE_SIDE));
				make.Apply ();
				GameObject NewObj = new GameObject (); //Create the GameObject
				Image GridImg = NewObj.AddComponent<Image> (); //A
                Button GridBt = NewObj.AddComponent<Button>();
//                EventTrigger et = NewObj.AddComponent<EventTrigger>();

//                NewObj.ev   
//                et.OnPointerClick.
				//GridImg.name = x+", "+y;
				GridBt.name = x+", "+y;
                //Debug.Log("NAME : " + GridBt.name);
                 
                // TODO
                // if tilecomplete ? y or n 
				GridImg.sprite = Sprite.Create (make, new Rect (0, 0, TILE_SIDE, TILE_SIDE), new Vector2 ());
				//GridImg.color = Color.yellow;

                GridBt.image = GridImg;

                GridBt.onClick.AddListener(() => TileClicked(GridBt.name));
				//NewObj.transform.SetParent (Grid.transform, false);
				GridBt.transform.SetParent (Grid.transform, false);
			}
		}
	}

    /**
     *  Move Game scene 
     */
    void TileClicked(string TileName)
    {
        Debug.Log("Tileclicked name : "+TileName);
        string[] cooldinate = TileName.Split(',');
        if (cooldinate.Length != 2) return;
        GlobalValue.X = int.Parse(cooldinate[0]);
        GlobalValue.Y = int.Parse(cooldinate[1]);
		SceneManager.LoadScene ("Main");
    }

	void LoadGridItems(){
		StartCoroutine (LoadCoroutine ());
	}


	IEnumerator LoadCoroutine(){

		Debug.Log ("GlovalCurrentPage: " + GlobalValue.CurrentPage.ToString());
		string fileName = string.Format ("16x16_{0:D2}.json", GlobalValue.CurrentPage);
		Debug.Log ("filename : " + fileName);
		string ItemsJsonString = File.ReadAllText (Application.dataPath + "/Resources/data/"+fileName);
		JsonData itemData = JsonMapper.ToObject (ItemsJsonString);

		ParsingJsonStringToItems (itemData);

		yield return null;
	}

	public void MovePlay(){
		SceneManager.LoadScene ("Main");

	}

	void ParsingJsonStringToItems(JsonData _JsonData){
		Item tmpItem;
		for (int i = 0; i < _JsonData.Count; i++) {
			tmpItem = new Item ("",0,"","");
			tmpItem.img_name = (string)_JsonData [i] ["img_name"];
			tmpItem.type = (int)_JsonData [i] ["type"];
			tmpItem.is_complete_yn = (string)_JsonData [i] ["is_complete_yn"];
			tmpItem.data = (string)_JsonData [i] ["data"];
			Items.Add (tmpItem);
		}
		AddItemsToGrid ();
		//DebugCurrentItems ();
	}

	void DebugCurrentItems(){
		for (int i = 0; i < Items.Count; i++) {
			Debug.Log ("img_name : " + Items [i].img_name);
			Debug.Log ("type : " + Items [i].type);
			Debug.Log ("is_complete_yn : " + Items [i].is_complete_yn);
			Debug.Log ("data : " + Items [i].data );
		}
	}

	void AddItemsToGrid(){
		GameObject grid = GameObject.Find ("Grid");
		for (int i = 0; i < Items.Count; i++) {
			Tiles[i] = (GameObject)Instantiate (square, Grid.transform); 
			if(Items[i].is_complete_yn.Equals("N")){
				Tiles[i].GetComponent<Image>().color = Color.black;
				Tiles [i].name = Items [i].img_name;
			}
		}
	}

	public Item GetItem(string _img_name){
		for (int i = 0; i < Items.Count; i++) {
			if (Items [i].img_name.Equals (_img_name)) {
				return Items [i];
			}
		}
		return null;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
