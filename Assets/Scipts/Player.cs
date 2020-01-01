using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private string PlayerId = "";

    void Start()
    {
        // get plyaer id from server/services
        this.PlayerId = "base_player";

        GameObject vCam = GameObject.FindGameObjectsWithTag("VirtualCamera")[0];
        var vcam = vCam.GetComponent<CinemachineVirtualCamera>();
        var currentPlayer = this.gameObject.transform;
        if (vcam != null){
            print("camera aq");

        }
        if (currentPlayer!= null){
            print("player aq");

        }
        vcam.LookAt = currentPlayer;
        vcam.Follow = currentPlayer;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
