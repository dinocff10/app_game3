using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Movement : MonoBehaviour {
    Animator ani;
    NavMeshAgent nav;                                 // Use this for initialization
    Attack attack;
    public int moveoffset = 0; //攻擊距離和停止移動距離的差值  //不可大於ATTACK RANGE
    private float mindistance = 1.5f;//最近的距離

    void Start () {
        
        nav = GetComponent<NavMeshAgent>();
        attack = GetComponent<Attack>();
        ani = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {

        if (attack.targetTransform == null)
        {
            return;
        }
        

        if (Vector3.Distance(transform.position,attack.targetTransform.position)>attack.attackrange)
        {
            nav.SetDestination(attack.targetTransform.position);
            ani.Play("Walk");
        }

        if (Vector3.Distance(transform.position, attack.targetTransform.position) <= mindistance)
        {
            
            nav.velocity = Vector3.zero;
        }

        

        transform.LookAt(attack.targetTransform.transform);
    }

  
}
