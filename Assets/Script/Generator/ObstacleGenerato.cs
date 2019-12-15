using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// -------------------------
// Bottom Obstacle Generator:
// - Controls the top obstacle
// -------------------------
public class BottomObstacleGenerator : MonobehaviorSingleton<BottomObstacleGenerator>
{
    // Start is called before the first frame update
    void Start()
    {
        //Generate();
        block = Resources.Load<GameObject>("Prefab/GroundBlock");
    }

    // Update is called once per frame
    // TODO: Instantiate obstacle blocks on the view ceiling
    // TODO: Checks bottom obstacle to make sure the total view height > obstacle height
    // TODO: Implement algorithm to spawn different obstacles at different times
    void FixedUpdate()
    {
        
    }
    public GameObject block;
    public int width = 5;
    public int height = 5;
    public bool[] blocks = new bool[25];
    // Start is called before the first frame update
    void Generate(){
        
        for (int y=0; y<width; ++y)
       {
           for (int x=0; x<height; ++x)
           {
               blocks[x + 5 * y] = false;
               Debug.Log("the x is " + x +" the number is " + x + 5 * y);
               bool isGenerate = Random.Range(1,3) > 1 ? true : false;
               if(y == 0 && isGenerate){
                   Instantiate(block, new Vector3(x,y,0), Quaternion.identity);
                   blocks[x + 5 * y] = true;
               }
               if(y != 0 && blocks[x + 5 * (y - 1)] == true && isGenerate){
                   Instantiate(block, new Vector3(x,y,0), Quaternion.identity);
                   blocks[x + 5 * y] = true;
               }
           }
       } 
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G)){
            Debug.Log("pressed G");
        }
    }
}
