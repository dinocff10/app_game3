using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectLevel : MonoBehaviour {
    public int money = 0;
    public string selectlv;
    public int selectlvint;
    static SelectLevel sel;
    void Awake()
    {
        if(sel==null)
        {
            sel = this;
            DontDestroyOnLoad(gameObject);
        }
       
    }
    public void selectlevel1()
    {
        FindObjectOfType<SelectLevel>().selectlv = "Level1";
        FindObjectOfType<SelectLevel>().selectlvint = 1;
        FindObjectOfType<SelectLevel>().money = 100;
        SceneManager.LoadScene("SelectMonster");
    }

    public void selectlevel2()
    {
        FindObjectOfType<SelectLevel>().selectlv = "Level2";
        FindObjectOfType<SelectLevel>().selectlvint = 2;
        FindObjectOfType<SelectLevel>().money = 130;
        SceneManager.LoadScene("SelectMonster");
    }

    public void selectlevel3()
    {
        FindObjectOfType<SelectLevel>().selectlv = "Level3";
        FindObjectOfType<SelectLevel>().selectlvint = 3;
        FindObjectOfType<SelectLevel>().money = 160;
        SceneManager.LoadScene("SelectMonster");
    }

    public void selectlevel4()
    {
        FindObjectOfType<SelectLevel>().selectlv = "Level4";
        FindObjectOfType<SelectLevel>().selectlvint = 4;
        FindObjectOfType<SelectLevel>().money = 160;
        SceneManager.LoadScene("SelectMonster");
    }

    public void selectlevel5()
    {
        FindObjectOfType<SelectLevel>().selectlv = "Level5";
        FindObjectOfType<SelectLevel>().selectlvint = 5;
        FindObjectOfType<SelectLevel>().money = 160;
        SceneManager.LoadScene("SelectMonster");
    }

    public void selectlevel6()
    {
        FindObjectOfType<SelectLevel>().selectlv = "Level6";
        FindObjectOfType<SelectLevel>().selectlvint = 6;
        FindObjectOfType<SelectLevel>().money = 180;
        SceneManager.LoadScene("SelectMonster");
    }

    public void selectlevel7()
    {
        FindObjectOfType<SelectLevel>().selectlv = "Level7";
        FindObjectOfType<SelectLevel>().selectlvint = 7;
        FindObjectOfType<SelectLevel>().money = 200;
        SceneManager.LoadScene("SelectMonster");
    }

    public void selectlevel8()
    {
        FindObjectOfType<SelectLevel>().selectlv = "Level8";
        FindObjectOfType<SelectLevel>().selectlvint = 8;
        FindObjectOfType<SelectLevel>().money = 220;
        SceneManager.LoadScene("SelectMonster");
    }

    public void selectlevel9()
    {
        FindObjectOfType<SelectLevel>().selectlv = "Level9";
        FindObjectOfType<SelectLevel>().selectlvint = 9;
        FindObjectOfType<SelectLevel>().money = 240;
        SceneManager.LoadScene("SelectMonster");
    }

    public void selectlevel10()
    {
        FindObjectOfType<SelectLevel>().selectlv = "Level10";
        FindObjectOfType<SelectLevel>().selectlvint = 10;
        FindObjectOfType<SelectLevel>().money = 260;
        SceneManager.LoadScene("SelectMonster");
    }
}
