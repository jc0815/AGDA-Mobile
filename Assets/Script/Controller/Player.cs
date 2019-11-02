using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// -------------------------
// Player Class:
// - Controls the player
// TODO: Add Winton's code
// TODO: 
// -------------------------
public class Player : MonobehaviorSingleton<Player>
{
    private int playerLife;
    private int reloadTime;
    // Start is called before the first frame update
    void Start()
    {
        playerLife = GameConstants.PLAYER_LIFE;
        reloadTime = GameConstants.LOAD_WEAPON_TIME;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // When character dies lmao
    void Dead()
    {
        // TODO: Calls UI functions (not implemented yet)
        Destroy(this);
    }

    // When character gets hit
    void Hit()
    {
        // TODO: Decrease life, or game ends (calls Dead)
        // TODO: Destroy block in front of character
    }


    // Updates game score
    void UpdateScore()
    {
        // TODO: Calls UI (TBA)
    }

    // Shoot 
    void Shoot()
    {
        // TODO: When collider w/ bullet tag and 
        //       collider w/ obstacle tag hit: destroy obstacle
    }

    // Generates block below the player
    void Stack()
    {
        // TODO: stack blocks
    }
}
