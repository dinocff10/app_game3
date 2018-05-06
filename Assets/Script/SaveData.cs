using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour {

   public string[] selectmonster;
    static SaveData sav; 
	// Use this for initialization
    void Awake()
    {
        if(sav==null)
        {
            sav = this;
            gameObject.AddComponent<MonsterDatatxt>();
            selectmonster = new string[18];
            DontDestroyOnLoad(gameObject);
        }
       
        
    }

	void Start () {
     
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
