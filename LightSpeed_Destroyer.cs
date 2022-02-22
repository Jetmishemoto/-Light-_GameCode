using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpeed_Destroyer : MonoBehaviour
{

    public GameObject lightdestroyer_target;
    public Playa playa;

 

    void OnTriggerEnter (Collider otherCollider)
    {
       
            if (otherCollider.GetComponent<Playa>() && playa.lightspeed)
            {
                lightdestroyer_target.SendMessage("OnLIghtspeedKill");
                Destroy(lightdestroyer_target);
                
            }
        
    }
}
