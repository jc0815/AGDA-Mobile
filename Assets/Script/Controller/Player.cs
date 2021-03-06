﻿using System.Collections;
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
    private GameObject blockPrefab;
    private GameObject groundBlock;
    private Transform stacks;
    private int count;

    // Start is called before the first frame update
    public void Start()
    {
        blockPrefab = Resources.Load<GameObject>("Prefab/StackBlock");
        playerLife = GameConstants.PLAYER_LIFE;
        reloadTime = GameConstants.LOAD_WEAPON_TIME;
        stacks = GameObject.Find("Stack").transform;
        count = 1;
    }

    // Update is called once per frame
    public void Update()
    {
        if (this.transform.position.y < -3)
        {
            Debug.Log("y pos");
            Dead();
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Obstacle") // this string is your newly created tag
        {
            Debug.Log("collision obstacle");
            Dead();
        }
    }

    // When character dies lmao
    public void Dead()
    {
        // TODO: Calls UI functions (not implemented yet)
        BattleMenuController.Instance.GameEnd();
        Destroy(this);
    }

    // When character gets hit
    public void Hit()
    {
        // TODO: Decrease life, or game ends (calls Dead)
        // TODO: Destroy block in front of character
    }


    // Updates game score
    public void UpdateScore()
    {
        // TODO: Calls UI (TBA)
    }

    // Shoot 
    public void Shoot()
    {
        // TODO: When collider w/ bullet tag and 
        //       collider w/ obstacle tag hit: destroy obstacle
    }

    // Generates block below the player
    public void Stack()
    {
        Debug.Log("Spawned " + count);
        // TODO: stack blocks
        if (count < GameConstants.MAX_STACK)
        {
            this.transform.position = new Vector3(0, count + 1);
            groundBlock = Instantiate(blockPrefab);
            groundBlock.transform.position = new Vector3(0, count, 0);
            groundBlock.transform.parent = stacks.transform;
            count++;
            SoundManager.PlayMusic(Music.Stack);
        }
    }

    
}
