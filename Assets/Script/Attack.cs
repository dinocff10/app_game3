using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {

    public Animator ani;
    public float attackrange=0;//攻擊距離
    public float attackcd = 5; // 攻擊冷卻
    public float attack = 10f; //攻擊傷害
    public Transform targetTransform;  //攻擊目標
    private float nextattack = 0;
    public GameObject[] targets;
    // Use this for initialization
    void Start () {
        ani = GetComponent<Animator>();
        targets = null;
        nextattack = Time.time;
        targetTransform = null;
    }
	
	// Update is called once per frame
	void Update () {
        Searchtarget();
        DetectAttack();
    }
    public void DetectAttack()//確認是否開始攻擊
    {
       
        if(targetTransform == null)
        {
            return;
        }

        if (Vector3.Distance(targetTransform.transform.position,transform.position)<=attackrange)
        {
            if(Time.time > nextattack)
            {
                
                nextattack = Time.time + attackcd;
                ani.Play("Attack");
            }
            

        }
        
    }

    public void OnAttack() //由動畫EVENT呼叫   fire+cabe+ebu的
    {
        if (targetTransform == null)
        {
            return;
        }



        Health hea = targetTransform.GetComponent<Health>();

        if(hea.currenthealth<=100)
        {
            hea.GetDamage(attack);
        }
        

        if(targetTransform.name == "05(Clone)"  ||  targetTransform.name == "05")  //判斷是否為果然翁
        {
            gameObject.GetComponent<Health>().GetDamage(attack);
        }


        Debug.Log("對"+targetTransform.name+"造成"+attack.ToString()+"傷害");
    }
    public void WaterAttack() //由動畫EVENT呼叫   蝌蚪的
    {
        if (targetTransform == null)
        {
            return;
        }

       GameObject water= (GameObject)Instantiate(Resources.Load("WaterAttack"), transform.position, transform.rotation);
        water.GetComponent<WaterAttack>().target = targetTransform;
       
    }
    public void MeowAttack() //由動畫EVENT呼叫   喵喵的
    {
        if (targetTransform == null)
        {
            return;
        }
        Health hea = targetTransform.GetComponent<Health>();
        hea.GetDamage(attack);
        attack = attack + 5;
       

        if (targetTransform.name == "05(Clone)" || targetTransform.name == "05")  //判斷是否為果然翁
        {
            gameObject.GetComponent<Health>().GetDamage(attack);
        }

    }
    public void PikaAttack() //由動畫EVENT呼叫   皮卡的
    {
        if (targetTransform == null)
        {
            return;
        }


        GameObject light = (GameObject)Instantiate(Resources.Load("Ligthning"), targetTransform.position, targetTransform.rotation);  
        light.transform.rotation = Quaternion.Euler(-270, 0, 0); //旋轉生成雷電角度

    }
    public void transAttack() //由動畫EVENT呼叫   百變怪的
    {
        if (targetTransform == null)
        {
            return;
        }

        SkinnedMeshRenderer mat = targetTransform.GetChild(0).GetChild(0).GetComponent<SkinnedMeshRenderer>();
        gameObject.transform.GetChild(0).GetChild(0).GetComponent<SkinnedMeshRenderer>().material= mat.material;
        Debug.Log(mat.material.name);

    }

    public void Searchtarget()//尋找最近目標
    {
        
        if (gameObject.tag=="Friend")
        {
            targets = GameObject.FindGameObjectsWithTag("Enyme");
        }
        else if(gameObject.tag == "Enyme")
        {
            targets = GameObject.FindGameObjectsWithTag("Friend");
        }
        float mindistance = 100f;

        if(targets.Length==0)
        {
            targetTransform = null;
            return;
        }

        foreach (GameObject target in targets)
        {
            if(Vector3.Distance(target.transform.position,transform.position) < mindistance)
            {
                
                targetTransform = target.transform;
                mindistance = Vector3.Distance(target.transform.position, transform.position);
            }

        }

    }
}
