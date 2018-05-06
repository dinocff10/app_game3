using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
    SaveData sav;
    GameObject[] PrefabList;
    Transform[] respawn;
    SelectLevel sellv;
    public Transform Friend;
    public Transform Enyme;
    public GameObject respawnpoint;
    public GameObject EndMenu;
    public Text mysurvied;
    public Text Enymesurvied;
    public int completelv;
    // Use this for initialization
    void Start () {
        completelv = PlayerPrefs.GetInt("CompleteLv");
        sellv = (SelectLevel)FindObjectOfType(typeof(SelectLevel));
        sav = (SaveData)FindObjectOfType(typeof(SaveData));
         PrefabList = Resources.LoadAll<GameObject>("MonsterPrefab");
         respawn = respawnpoint.GetComponentsInChildren<Transform>();
        for (int x=0;x<sav.selectmonster.Length;x++)
        {
            if(sav.selectmonster[x]!=null)
            {
                int num = int.Parse(sav.selectmonster[x])-1;
                GameObject go =GameObject.Instantiate(PrefabList[num], respawn[x + 1].position, respawn[x + 1].rotation);
                go.transform.SetParent(Friend);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {

        mysurvied.text = "我方存活:" + Friend.childCount.ToString();
        Enymesurvied.text = "敵方存活:" + Enyme.childCount.ToString();


        if (Friend.childCount==0)
        {
            EndMenu.gameObject.SetActive(true);
            EndMenu.transform.GetChild(1).GetComponent<Text>().text = "Defeat";    //失敗
        }
        if (Enyme.childCount == 0)
        {
            EndMenu.gameObject.SetActive(true);
            EndMenu.transform.GetChild(1).GetComponent<Text>().text = "Victory";   //勝利
            save();
        }
    }

    public void save()
    {

        if(PlayerPrefs.HasKey("CompleteLv"))
        {
            if((PlayerPrefs.GetInt("CompleteLv") & 1 << (sellv.selectlvint-1)) == (1 << (sellv.selectlvint-1)))  //代表之前曾經完成這關
            {
                return;
            }
            else
            {
                PlayerPrefs.SetInt("CompleteLv", PlayerPrefs.GetInt("CompleteLv")+ (1<<(sellv.selectlvint - 1)));
                Debug.Log("demo" + (PlayerPrefs.GetInt("CompleteLv") + 1 << (sellv.selectlvint - 1)).ToString());
                Debug.Log(1 << (sellv.selectlvint - 1));
            }
        }
        else
        {
            PlayerPrefs.SetInt("CompleteLv",0);
        }
    }
}
