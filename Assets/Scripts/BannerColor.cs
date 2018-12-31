using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BannerColor : MonoBehaviour {
    private UISprite banner;
    private UISprite content_bg;
    private UISprite upgrade_btn;
    private UILabel bottomTitle;
    private UILabel bottomContent;
    private tab currentTab;
    private GameObject collectBtn;
    private enum tab
    {
        power,
        frequency,
        offline,
        money
    }

    private GameObject toggleParent;


    // Use this for initialization
    void Start () {
        
        toggleParent = GameObject.Find("UI Root/bottom/toggle/button");

        collectBtn =GameObject.Find("UI Root/OffLine/Container/collect_button");
        banner = GameObject.Find("UI Root/bottom/banner").GetComponent<UISprite>();
        content_bg = GameObject.Find("UI Root/bottom/Container/content_bg").GetComponent<UISprite>();
        upgrade_btn = GameObject.Find("UI Root/bottom/Container/upgrade_btn").GetComponent<UISprite>();
        bottomTitle = GameObject.Find("UI Root/bottom/Container/describe/title_label").GetComponent<UILabel>();
        bottomContent = GameObject.Find("UI Root/bottom/Container/describe/content_label").GetComponent<UILabel>();

        for(int i = 0; i < toggleParent.transform.childCount; i++)
        {
            UIEventListener.Get(toggleParent.transform.GetChild(i).gameObject).onClick = ChangeBottomItem;
        }

        TweenPosition twp = collectBtn.transform.parent.GetComponent<TweenPosition>();
        EventDelegate.Add(twp.onFinished, closeOfflinePanel);
        
    }
	
	// Update is called once per frame
	void Update () {


	}

    void closeOfflinePanel()
    {
        collectBtn.transform.parent.parent.gameObject.SetActive(false);
    }


    


    public void ChangeBottomItem(GameObject button)
    {
        Color c1 = new Color();
        Color c2 = new Color();
        string title = "";
        string content = "";
        if(button.name== "money_button")
        {
            currentTab = tab.money;
            title = "金币";
            content = "100%";
            c1 = new Color((float)10 / 255, (float)122 / 255, 1, 1);
            c2 = new Color((float)146 / 255, (float)196 / 255, 1, 1);
        }
        else if(button.name == "offline_button")
        {
            currentTab = tab.offline;
            title = "离线收入";
            content= "110%";
            c1 = new Color(1, (float)220 / 255, (float)6 / 255, 1);
            c2 = new Color((float)1, (float)240 / 255, (float)148 / 255, 1);
        }
        else if (button.name == "power_button")
        {
            currentTab = tab.power;
            title = "火力";
            content = "120%";
            c1 = new Color((float)202 / 255, (float)6 / 255,(float)232 / 255, 1);
            c2 =  new Color((float)205 / 255, (float)137 / 255, (float)215 / 255, 1);
        }
        else
        {
            currentTab = tab.frequency;
            title = "开火速度";
            content = "130%";
            c1 = new Color(1, (float)89 / 255, 0, 1);
            c2 = new Color(1, (float)142 / 255, (float)81 / 255, 1);
            
        }

        setBottomColor(c1, c2);
        setWord(title, content);
    }

    void setBottomColor(Color _c1,Color _c2)
    {
        banner.color = _c1;
        content_bg.color = _c2;
        upgrade_btn.color = _c1;
    }

    void setWord(string _title,string _content)
    {
        bottomTitle.text = _title;
        bottomContent.text = _content;
    }

    void Upgrade(GameObject button)
    {
        switch (currentTab)
        {
            case tab.frequency:
                Debug.Log("frequency up");
                break;
            case tab.money:
                Debug.Log("money up");
                break;
            case tab.offline:
                Debug.Log("offline up");
                break;
            case tab.power:
                Debug.Log("power up");
                break;
            default:
                break;
        }
    }
}
