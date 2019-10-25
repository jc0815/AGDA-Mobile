using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{ 
    private GameObject playerPrefab;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        playerPrefab = Resources.Load<GameObject>("Prefab/Player");
        player = Instantiate(playerPrefab);
        player.transform.position = new Vector3(0, 5, 0);
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
}
