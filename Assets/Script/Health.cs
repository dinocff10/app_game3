using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {

    public float maxhealth;
    public float currenthealth;
    public Transform healthForegroundtrans;
    Image img;

    private Vector3 initrans;
    private Vector3 transoffset;
    private float baroffset = -3.21f;
	// Use this for initialization
	void Start () {
        healthForegroundtrans = transform.GetChild(1).GetChild(0).GetChild(0).GetChild(0).GetComponent<Transform>();
        img = healthForegroundtrans.GetComponent<Image>();
        initrans = healthForegroundtrans.parent.transform.position;
        transoffset = initrans - transform.position;
        currenthealth = maxhealth;
        
    }
	
	// Update is called once per frame
	void Update () {

        


    }
    public void GetDamage(float damage)
    {
        
        currenthealth = currenthealth - damage;
        if(currenthealth>maxhealth)
        {
            AdjustHealthBar(damage + (currenthealth - maxhealth));
            currenthealth = maxhealth;
            
        }
        else
        {
            AdjustHealthBar(damage);
        }
        
        if(currenthealth<=0)
        {
            Dead();
        }
        
    }

    void Dead()
    {
        Destroy(gameObject);
    }

    void AdjustHealthBar(float hp)  ///(-4.9) = 0%   (0) = 100%
    {

        healthForegroundtrans.Translate(baroffset * (hp/maxhealth),0,0);



        
       
            if ((currenthealth / maxhealth) * 100 <= 60 && (currenthealth / maxhealth) * 100 > 30)
            {
                img.color = Color.yellow;  //yello
            }
            else if ((currenthealth / maxhealth) * 100 <= 30)
            {
                img.color = Color.red; //red
            }
            else
            {
                img.color = Color.green; //green

            }
        
                
    }
}
