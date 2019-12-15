using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// -------------------------
// Bottom Obstacle Generator:
// - Controls the top obstacle
// -------------------------
public class ObstacleGenerator : MonobehaviorSingleton<ObstacleGenerator>
{
    // Start is called before the first frame update
    void Start()
    {
        //Generate();
        block = Resources.Load<GameObject>("Prefab/ground-individual");
        blocktwo = Resources.Load<GameObject>("Prefab/GroundBlock");

    }

    // Update is called once per frame
    // TODO: Instantiate obstacle blocks on the view ceiling
    // TODO: Checks bottom obstacle to make sure the total view height > obstacle height
    // TODO: Implement algorithm to spawn different obstacles at different times
    void FixedUpdate()
    {
        
    }
    private GameObject block;
    private GameObject blocktwo;
    private int width = 18;
    private int height = 10;
    public bool[,] blocks = new bool[21,13];
    public bool[,] topBlocks = new bool[21,13];
    // Start is called before the first frame update
    void Generate(){
        //from boottom to up
        for (int y=0; y<height; ++y)
       {
           for (int x=0; x<width; ++x)
           {
               blocks[x,y] = false;
               Debug.Log("the x is " + x +" the y is " + y);
               bool isGenerate = Random.Range(1,3) > 1 ? true : false;
               if(y == 0 && isGenerate){
                   Instantiate(block, new Vector3(x,y+1,0), Quaternion.identity);
                   blocks[x,y] = true;
               }
               if(y != 0 && hasNeighborBottom(x,y) && isGenerate ){
                   Debug.Log("the y is "+ y);
                   Instantiate(block, new Vector3(x,y+1,0), Quaternion.identity);
                   blocks[x,y] = true;
               }
           }
       } 
       //from up to bottom
       for(int y = height - 1; y >0; y --){
           for(int x = width - 1; x>0;x--){
               topBlocks[x,y] = false;
               Debug.Log("the x is " + x +" the y is " + y);
               bool isGenerate = Random.Range(1,3) > 1 ? true : false;
               if(y == height - 1 && isGenerate){
                   Instantiate(blocktwo, new Vector3(x,y+1,0), Quaternion.identity);
                   topBlocks[x,y] = true;
               }
               if(y != 0 && hasNeighborUp(x,y) && isGenerate ){
                   Debug.Log("the y is "+ y);
                   Instantiate(blocktwo, new Vector3(x,y+1,0), Quaternion.identity);
                   topBlocks[x,y] = true;
               }
           }
       }
    }
    bool hasNeighborUp(int x, int y){
        if(hasNeighborBottom(x,y)){
            return false;
        }
        if(y >= 2 && blocks[x,y -2 ] == true){
            return false;
        }
        if(topBlocks[x,y + 1] == true){
            return true;
        }else if(x == 0){
            return false;
        }else if(topBlocks[x-1,y]==true){
            return true;
        }
        return false;
    }
    bool hasNeighborBottom(int x, int y){
        if(blocks[x,y - 1] == true){
            return true;
        }else if (x == 0){
            return false;
        }else if (blocks[x-1,y]==true){
            return true;
        }
        return false;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G)){
            Debug.Log("pressed G");
            this.Generate();
        }
        if(Input.GetKeyDown(KeyCode.C)){
            blocks = new bool[21,13];
        }
    }
}
