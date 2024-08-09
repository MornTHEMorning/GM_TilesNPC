using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Textbox appears when player gets close to npc
public class AppearingTextBox : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [Tooltip("At what distance should the textbox appear?")]
    [SerializeField] private float range;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
