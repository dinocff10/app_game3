using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectLevelManager : MonoBehaviour {
    public GameObject levelselectPanel;
    
	// Use this for initialization
	void Start () {
        int count = levelselectPanel.transform.childCount-1;

        for(int x=0;x<=count;x++)
        {
            if((PlayerPrefs.GetInt("CompleteLv") & 1 << x) == 1 << x)  //代表此關已過
            {
                levelselectPanel.transform.GetChild(x).GetChild(1).gameObject.SetActive(true); //打開星星
                Debug.Log(levelselectPanel.transform.GetChild(x).GetChild(1).gameObject.name);
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
