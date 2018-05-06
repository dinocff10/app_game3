using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMonsterManager : MonoBehaviour {
    Sprite[] pictures;
    Image[] Droptablearray;
    Image[] img;
    SelectLevel sellv;
    MonsterDatatxt dat;
    public GameObject DragPanel;
    public GameObject DropPanel;
    public Text Remainmoney;
    public Text Abilitytxt;
    public int money = 0;
    int index = 0;
    int currentvalue = 0;
    // Use this for initialization
    void Start () {
        sellv = (SelectLevel)FindObjectOfType(typeof(SelectLevel));
        money = sellv.money;  //設置關卡初始金額
        dat = (MonsterDatatxt)FindObjectOfType(typeof(MonsterDatatxt));


        pictures = Resources.LoadAll<Sprite>("Mymonster");
        img = DragPanel.GetComponentsInChildren<Image>();
        Droptablearray = DropPanel.GetComponentsInChildren<Image>();
        for (int x=1;x<7;x++)
        {
            img[x].sprite = pictures[x-1];
        }
        Remainmoney.text = "餘額:"+money.ToString();
        Abilitytxt.text =dat.nametxt2[0]+"\n" + dat.abilitxt2[0]+"\n花費:"+dat.cost2[0];
    }
	
	// Update is called once per frame
	void Update () {
        
        for(int x=2;x<=36;x=x+2)
        {
            if(Droptablearray[x].sprite!=null)
            {
                SaveData sav = (SaveData)FindObjectOfType(typeof(SaveData));
                sav.selectmonster[(x/2)-1] = Droptablearray[x].sprite.name;
            }
            else
            {
                SaveData sav = (SaveData)FindObjectOfType(typeof(SaveData));
                sav.selectmonster[(x / 2) - 1] = null;
            }
        }

       

        Remainmoney.text = "餘額:" + money.ToString();  //定時更新餘額
    }

    public void PressLeft()
    {
        index--;
        if (index < 0) index = 9;
        currentvalue = index+1;
        for (int x = 1; x < 7; x++)
        {

            img[x].sprite = pictures[currentvalue- 1];
            currentvalue++;
            if (currentvalue > 10) currentvalue = 1;

        }
        updatetxt();
    }

    public void PressRight()
    {
        index++;
        if (index > 9) index = 0;
        currentvalue = index+1;
        for (int x = 1; x < 7; x++)
        {
            img[x].sprite = pictures[currentvalue - 1];
            currentvalue++;
            if (currentvalue > 10) currentvalue = 1;
        }

        updatetxt();
    }

    public void updatetxt()
    {

        Abilitytxt.text = dat.nametxt2[index] + "\n" + dat.abilitxt2[index] + "\n花費:" + dat.cost2[index];
    }
}
