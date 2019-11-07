using System.Collections;
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
    private GameObject blockPrefab;
    private GameObject groundBlock;

    // Start is called before the first frame update
    void Start()
    {
        SpawnTiles();
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

    public void SpawnPlayer()
    {
        playerPrefab = Resources.Load<GameObject>("Prefab/Player");
        player = Instantiate(playerPrefab);
        player.transform.position = new Vector3(0, 5, 0);
    }
    public void SpawnTiles()
    {
        blockPrefab = Resources.Load<GameObject>("Prefab/GroundBlock");
        for (int i = 0; i < 10; i++)
        {
            groundBlock = Instantiate(blockPrefab);
            groundBlock.transform.position = new Vector3(0, i, 0);
        }
       
    }
}
