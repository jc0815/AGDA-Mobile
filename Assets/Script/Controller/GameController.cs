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
    private GameObject backGroundPrefab;
    private GameObject blockPrefab;
    private GameObject groundBlock;
    private GameObject stack;
    private GameObject ground;

    // Start is called before the first frame update
    void Start()
    { 
        blockPrefab = Resources.Load<GameObject>("Prefab/GroundBlock");
        playerPrefab = Resources.Load<GameObject>("Prefab/Player");
        backGroundPrefab = Resources.Load<GameObject>("Prefab/Background");

        SpawnBackGround();
        SpawnPlayer();
        SpawnStack();

        // Set up auto-generating ground:
        // 1) Uncomment SpawnGround, comment SpawnGroundDefault
        // 2) Attach GroundGenerator script to Game Scene
        // 3) Change GroundBlock prefab from static to kinematic
        // SpawnGround();
        SpawnGroundDefault(); 
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
    public void SpawnGroundDefault()
    {
        ground = new GameObject("Ground");
        for (int i = 0; i < 18; i++)
        {
            groundBlock = Instantiate(blockPrefab);
            groundBlock.transform.position = new Vector3(i, 0, 0);
            groundBlock.transform.parent = ground.transform;
        }
    }

    public void SpawnGround()
    {
        this.GetComponent<GroundGenerator>().genFirstSet();
    }
}
