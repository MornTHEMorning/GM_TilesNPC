using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RobotPlayer{
//Textbox appears when player gets close to npc
public class AppearingTextBox : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [Tooltip("At what distance should the textbox appear? 2 is minimum value given 32x32 tile")]
    [SerializeField] private float range = 2.0f;

    [Tooltip("Put Gameobject that will appear/dissappear")]
    public GameObject textbox;

    //checks if everything is present before checking stuff
    private bool diagnosticsOkay;

    // Start is called before the first frame update
    public void Start()
    {
        textbox.SetActive(false);

        if(!player){
            Debug.Log("No Player reference; put player prefab into inspector");
            diagnosticsOkay = false;
        }

        if(!textbox){
            Debug.Log("No Textbox reference; put npc's textbox into inspector");
            diagnosticsOkay = false;
        }

        if(range < 2.0){
            Debug.Log("Comparing distance (aka Range) must exist and be 2>=");
            diagnosticsOkay = false;
        }

        diagnosticsOkay = true;
    }

    public void FixedUpdate()
    {
        if(diagnosticsOkay){
            CheckDistance();
        }

    }
    private void CheckDistance(){
        //if the distance between the two is greater or equal, then set active or deactivate
        textbox.SetActive((Vector3.Distance((Vector3)this.transform.position, player.transform.position) <= range));
    }

    //todo: add gizmos for debugging purposes, make it a collider instead? 

}
}
