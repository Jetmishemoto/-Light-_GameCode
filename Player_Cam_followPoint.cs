using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Cam_followPoint : MonoBehaviour
{

    [SerializeField]
    Transform player;



    // Start is called before the first frame update
    void Update()
    {
        this.transform.position = player.position;
    }

}
