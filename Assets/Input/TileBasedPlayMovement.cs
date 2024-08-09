using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace RobotPlayer{
public class TileBasedPlayMovement : MonoBehaviour
{
    //Based on vid: https://www.youtube.com/watch?v=YnwOoxtgZQI 

    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tilemap foregroundTilemap;

    private PlayerInputManager controls; 

    private void Awake(){
        controls = new PlayerInputManager();
    }

    private void OnEnable(){
        controls.Enable();
    }

    private void OnDisable(){
        controls.Disable();
    }


    // Start is called before the first frame update
    public void Start()
    {
        //in my input control, Player action map > Action Move > when it happens, get the context (ctx) and call func Move()
        controls.Player.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
        //short: controls blah blah is listening to whenever it's preformed; think like The Bear talk before resturant opens
    }

    private void Move(Vector2 direction){
        if(CanMove(direction)){
            transform.position += (Vector3)direction; //direction is only 1/0/-1 so add to world position is oki 
        }
        
    }

    //can we move to our tile? 
    private bool CanMove(Vector2 direction){
            //(player's current world) transform.position + direction = destination of player in world
        Vector3Int gridPosition = groundTilemap.WorldToCell(transform.position + (Vector3)direction); //???
        
        //if there even is a ground there OR if there's an obstacle, don't go
        if((!groundTilemap.HasTile(gridPosition)) || (foregroundTilemap.HasTile(gridPosition)))
        {
            return false;
        }
        return true;

    }

}
}