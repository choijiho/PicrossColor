using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;


public class TileControl : MonoBehaviour {
    public enum TILE_STATE
    {
        check
    , none
    , x
    }

    public TILE_STATE ts;

    private Image img;

    void Awake()
    {
        ts = TILE_STATE.none;
        img = GetComponentInParent<Image>();
        AddEventTrigger();
    }

    void AddEventTrigger()
    {
        gameObject.AddComponent<EventTrigger>();

        EventTrigger.Entry DownEntry = new EventTrigger.Entry();
        DownEntry.eventID = EventTriggerType.PointerDown;
        DownEntry.callback.AddListener((eventdata) => { Down(); });
        GetComponent<EventTrigger>().triggers.Add(DownEntry);

        EventTrigger.Entry EnterEntry = new EventTrigger.Entry();
        EnterEntry.eventID = EventTriggerType.PointerEnter;
        EnterEntry.callback.AddListener((eventdata) => { Enter(); });
        GetComponent<EventTrigger>().triggers.Add(EnterEntry);

        EventTrigger.Entry UpEntry = new EventTrigger.Entry();
        UpEntry.eventID = EventTriggerType.PointerUp;
        UpEntry.callback.AddListener((eventdata) => { Up(); });
        GetComponent<EventTrigger>().triggers.Add(UpEntry);
    }

    void Down()
    {
        GlobalValue.IsDown = true;
        TileClicked();
    }

    void Enter()
    {
        if (GlobalValue.IsDown == true)
        {
            TileClicked();
        }
    }

    void Up()
    {
        GlobalValue.IsDown = false;
    }


    /**
     * OnClick event for cell click
     */
    public void TileClicked()
    {
        string _tilename = gameObject.name;

        Debug.Log("TILE NAME : " + _tilename);

        if(GlobalValue.ClickMode == GlobalValue.ClickState.Check)
        {
            if (img.color.Equals(Color.black))
            {
                ts = TILE_STATE.none;
            }else
            {
                ts = TILE_STATE.check;
            }
        }else if(GlobalValue.ClickMode == GlobalValue.ClickState.X)
        {
            if(img.sprite == null)
            {
                ts = TILE_STATE.x;
            }else
            {
                ts = TILE_STATE.none;
            }
        }
    


        ChangeTileVisual();
		Debug.Log ("col name : " + Util.GetTileNum (_tilename));
		GameObject.Find ("TopNum").GetComponent<TopNumControl> ().CheckColLineOfTopNum (Util.GetTileNum (_tilename));
		//(FindObjectOfType (TopNumControl) as TopNumControl).CheckColLineOfTopNum (Util.GetTileNum (_tilename)); 
        /*
        CheckVerticalNum();
        CheckComplete();
        */
    }


    void ChangeTileVisual()
    {
        Sprite SpriteX = Resources.Load<Sprite>("Images/x_icon");
        Debug.Log("TILE_STATE : " + ts.ToString());
        switch (ts)
        {
            case TILE_STATE.none:
                img.sprite = null;
                img.color = Color.white;
                break;
            case TILE_STATE.check:
                img.sprite = null;
                img.color = Color.black;
                break;
            case TILE_STATE.x:
                img.sprite = SpriteX;
                img.color = Color.black;
                break;
        }
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
