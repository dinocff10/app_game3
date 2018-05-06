using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaterAttack : MonoBehaviour {
    NavMeshAgent nav;
    public Transform target;
    Health targethealth;
    public float Ballattack = 35;
    // Use this for initialization
    void Start () {
        nav = GetComponent<NavMeshAgent>();
        targethealth = target.GetComponent<Health>();
    }
	
	// Update is called once per frame
	void Update () {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        nav.SetDestination(target.position);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == target.gameObject)
        {
            targethealth.GetDamage(Ballattack);
            if (col.name == "05(Clone)" || col.name == "05")  //判斷是否為果然翁
            {
                gameObject.GetComponent<Health>().GetDamage(Ballattack);
            }

            Destroy(gameObject);
        }
    }

}
