using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonobehaviorSingleton<Player>
{
    public ArrayList blocks;
    public GameObject block;
    public static readonly int MAX_BLOCKS = 10;
    // Start is called before the first frame update
    void Start()
    {
        blocks = new ArrayList();
        block = Resources.Load<GameObject>("Prefab/SpawnBlock");
    }

    public void CreateBlock()
    {
        if (blocks.Count <= MAX_BLOCKS)
        {
            GameObject generatedBlock = block;
            Instantiate(generatedBlock);
            generatedBlock.name = "Block" + blocks.Count.ToString();
            blocks.Add(generatedBlock);
            generatedBlock.transform.position = new Vector3(0, blocks.Count, 0);
        }
    }

    public void DeleteBlock()
    {
        foreach (GameObject b in blocks)
        {
            Debug.Log("Enter");
            if(b.name.CompareTo("Block" + blocks.Count + "(Clone)") == 0)
            {
                Debug.Log("Running");
                blocks.Remove(b);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
