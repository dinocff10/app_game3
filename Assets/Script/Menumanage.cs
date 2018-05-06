using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menumanage : MonoBehaviour {
    SelectLevel sel;
	// Use this for initialization
	void Start () {
        sel = (SelectLevel)FindObjectOfType(typeof(SelectLevel));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Tolevelselect()
    {
        SceneManager.LoadScene("Levelselect");

    }
    public void ToSelectmonster()
    {
        SceneManager.LoadScene("SelectMonster");

    }
    public void Tolevel()
    {
        SceneManager.LoadScene(sel.selectlv);

    }

    public void ToMonsterdata()
    {
        SceneManager.LoadScene("Monsterdata");

    }


    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");

    }
}
