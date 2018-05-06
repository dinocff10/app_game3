using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MonsterData : MonoBehaviour {
    public Image img;
    public Text Introduce;
    public Text Ability;
    public Text Name;
    Sprite[] pictures;
    MonsterDatatxt txt;
    public GameObject Data;
    int index = 0;
    int maxmonster=9;

    // Use this for initialization
    void Start() {
        Data.AddComponent<MonsterDatatxt>();
        txt = Data.GetComponent<MonsterDatatxt>();
        pictures = Resources.LoadAll<Sprite>("Mymonster");
        img.sprite = pictures[index];
        Introduce.text = txt.introtxt2[index];
        Ability.text =txt.abilitxt2[index];
        Name.text = txt.nametxt2[index];
        
    }

    // Update is called once per frame
    void Update() {

    }

    public void Pressleft()
    {
        if(index==0)
        {
            index = maxmonster;
        }
        else
        {
            index--;
        }
        Changedata();


    }
    public void PressRight()
    {
        if (index == maxmonster)
        {
            index = 0;
        }
        else
        {
            index++;
        }
        Changedata();
       
    }
    public void Presshome()
    {
        SceneManager.LoadScene("Menu");
    }

    private void Changedata()
    {
        img.sprite = pictures[index];
        //Introduce.text = introtxt[index];
        Introduce.text = txt.introtxt2[index] ;
        Ability.text = txt.abilitxt2[index];
        Name.text = txt.nametxt2[index];
    }
}
