using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    public GameObject block;
    public static int width = 20;
    public static int height = 10;
    public GameObject[,] blocks = new GameObject[width,height];
    // Start is called before the first frame update
    void Generate(){
        
        for (int y=0; y<height; ++y)
       {
           for (int x=0; x<width; ++x)
           {
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
    bool hasNeighbour(int x , int y){
        
        return false;
    }
    void Start()
    {
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
