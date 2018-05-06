using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMonsterAttack : Attack {

    // Use this for initialization
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Searchtargetfriend();
        DetectAttack();
    }

    public void Searchtargetfriend()
    {
        if (gameObject.tag == "Friend")
        {
            targets = GameObject.FindGameObjectsWithTag("Friend");
        }
        else if (gameObject.tag == "Enyme")
        {
            targets = GameObject.FindGameObjectsWithTag("Enyme");
        }
        float mindistance = 100f;

        if (targets.Length == 0)
        {
            targetTransform = null;
            return;
        }

        foreach (GameObject target in targets)
        {
            if (Vector3.Distance(target.transform.position, transform.position) < mindistance  && Vector3.Distance(target.transform.position, transform.position) !=0)
            {

                targetTransform = target.transform;
                mindistance = Vector3.Distance(target.transform.position, transform.position);
            }

        }
    }
}
