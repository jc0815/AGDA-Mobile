using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = Resources.Load<GameObject>("Prefab/Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y <= -5)
        {
            Destroy(this.gameObject);
            GameObject temp = Instantiate(player);
            temp.transform.position = new Vector3(0, 5, 0);
        }
    }
}
