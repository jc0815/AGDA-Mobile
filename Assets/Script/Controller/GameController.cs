﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// -------------------------
// Game Controller:
// - Controls the game
// - Initializes menu controller
// - Initializes sound manager
// -------------------------
public class GameController : MonobehaviorSingleton<GameController>
{
    private GameObject playerPrefab;
    private GameObject player;
    private GameObject backGroundPrefab;
    private GameObject blockPrefab;
    private GameObject groundBlock;
    private GameObject stack;
    private GameObject ground;
    public float speed = 10.0f;

    // Start is called before the first frame update
    void Start()
    { 
        blockPrefab = Resources.Load<GameObject>("Prefab/GroundBlock");
        playerPrefab = Resources.Load<GameObject>("Prefab/Player");
        backGroundPrefab = Resources.Load<GameObject>("Prefab/Background");
        this.GetComponent<GroundGenerator>().genFirstSet();
        SpawnBackGround();
        SpawnPlayer();
        SpawnGround();
        SpawnStack();

    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y <= -5)
        {
            Destroy(player);
            player = Instantiate(playerPrefab);
            player.transform.position = new Vector3(0, 5, 0);
        }
    }

    public void SpawnStack()
    {
        stack = new GameObject("Stack");
        Rigidbody2D r = stack.AddComponent<Rigidbody2D>();

    }

    public void SpawnPlayer()
    {

        player = Instantiate(playerPrefab);
        player.transform.position = new Vector3(0, 5, 0);
    }

    public void SpawnBackGround()
    {

        Instantiate(backGroundPrefab);
    }

    //Testing purpose
    public void SpawnGround()
    {
        ground = new GameObject("Ground");
        for (int i = 0; i < 18; i++)
        {
            groundBlock = Instantiate(blockPrefab);
            groundBlock.transform.position = new Vector3(i, 0, 0);
            groundBlock.transform.parent = ground.transform; 
        }
    }
}
