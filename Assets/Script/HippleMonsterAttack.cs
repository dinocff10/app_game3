using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HippleMonsterAttack :Attack {

	// Use this for initialization
	void Start () {
        ani = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        Searchtargetfar();
        DetectAttack();
    }

    public void Searchtargetfar() //找尋最遠的目標
    {
      

            if (gameObject.tag == "Friend")
            {
                targets = GameObject.FindGameObjectsWithTag("Enyme");
            }
            else if (gameObject.tag == "Enyme")
            {
                targets = GameObject.FindGameObjectsWithTag("Friend");
            }
            float mindistance = 0f;

            if (targets.Length == 0)
            {
                targetTransform = null;
                return;
            }

            foreach (GameObject target in targets)
            {
                if (Vector3.Distance(target.transform.position, transform.position) > mindistance)
                {

                    targetTransform = target.transform;
                    mindistance = Vector3.Distance(target.transform.position, transform.position);
                }

            }

        
    }
}
