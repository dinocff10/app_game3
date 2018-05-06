using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Dropable : MonoBehaviour , IDropHandler , IPointerEnterHandler , IPointerExitHandler {
    Color initColar;
    public void OnDrop(PointerEventData eventData)
    {

        
        Dragable d = eventData.pointerDrag.GetComponent<Dragable>();
        SelectMonsterManager sel = (SelectMonsterManager)FindObjectOfType(typeof(SelectMonsterManager));
        MonsterDatatxt dat = (MonsterDatatxt)FindObjectOfType(typeof(MonsterDatatxt));
        

        
        if(eventData.pointerDrag.GetComponent<Image>().tag=="Dragable" && this.GetComponent<Image>().tag=="TRASH")
        {
            return;   //什麼事都不用做
        }
        else if(eventData.pointerDrag.GetComponent<Image>().tag != "Dragable" && this.GetComponent<Image>().tag == "TRASH")  //丟到垃圾桶
        {
            sel.money = sel.money + dat.Returncost(eventData.pointerDrag.GetComponent<Image>().sprite.name);
            eventData.pointerDrag.GetComponent<Image>().sprite = null;
            eventData.pointerDrag.GetComponent<Image>().color =new Color(71/255,71/255,71/255,162/255);
            Debug.Log("trash");

        }
        else if (d!=null && sel.money-dat.Returncost(eventData.pointerDrag.GetComponent<Image>().sprite.name) >=0) //代表餘額還足夠
        {
            if(this.GetComponent<Image>().sprite !=null)  //代表已經被放置其他角色
            {
                sel.money = sel.money + dat.Returncost(this.GetComponent<Image>().sprite.name); //加上本身物件的錢
                sel.money = sel.money - dat.Returncost(eventData.pointerDrag.GetComponent<Image>().sprite.name); //扣掉物件的錢
                this.GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<Image>().sprite;
                this.GetComponent<Image>().color = Color.white;
            }

            else
            {
                sel.money = sel.money - dat.Returncost(eventData.pointerDrag.GetComponent<Image>().sprite.name); //扣掉物件的錢
                this.GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<Image>().sprite;
                this.GetComponent<Image>().color = Color.white;
            }
            

           /* SaveData sav = (SaveData)FindObjectOfType(typeof(SaveData));
            if (sav)
                Debug.Log("GUITexture object found: " + sav.name);
            else
                Debug.Log("No GUITexture object could be found");*/
                
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
      
    }

    // Use this for initialization
    void Start () {
        initColar = this.GetComponent<Image>().color;

        if(this.tag!="TRASH")
        {
            this.GetComponent<Image>().color = new Color(71 / 255, 71 / 255, 71 / 255, 162 / 255);
        }
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
