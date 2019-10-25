using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    public GameObject grassBlock;
    GameObject temp;

    // Start is called before the first frame update
    void Start()
    {
        grassBlock = Resources.Load<GameObject>("Prefab/SpawnBlock");
        for (int i = 0; i < 30; i++)
        {
            temp = Instantiate(grassBlock);
            temp.transform.position = new Vector3(i, 0, 0);
            temp.gameObject.name = "SpawnBlock";
        }
     
    }

    // Update is called once per frame
    void Update()
    {
    }
}
