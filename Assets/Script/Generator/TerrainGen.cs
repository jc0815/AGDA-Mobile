using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGen : MonoBehaviour
{
    public GameObject[] terrain;
    private GameObject grassBlock; //remove in the future?
    public float speed = 10.0f;
    private Vector2 screenBounds;
    private float whenToDissappear;
    private float xSpawnPoint;
    private GameObject nextPiece;

    void Awake()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        xSpawnPoint = screenBounds.x + 5f;

        grassBlock = Resources.Load<GameObject>("Prefab/SpawnBlock");
        float xGB = 0;
        while (xGB < xSpawnPoint)
        {
            Instantiate(grassBlock,new Vector3(xGB, 0, 0), Quaternion.identity);  //replacement for block generator, remove in the future?
            xGB += grassBlock.GetComponent<BoxCollider2D>().size.x;

        }


        GameObject[] ter = GameObject.FindGameObjectsWithTag("terrain");
        for (int i = 0; i < ter.Length; i++)
            ter[i].GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);

    }
    void Start()
    {
        
        whenToDissappear = -0.4f*screenBounds.x;        
        nextPiece = PieceToSpawn();

    }

    void Update()
    {
        if (TimeToSpawn())
        {
            SpawnLand(nextPiece);
            nextPiece = PieceToSpawn();
        }
        Destroy();
    }

    public bool TimeToSpawn() //check if okay to spawn
    {
        float SpaceforNPiece = xSpawnPoint - ClosestTerrain().transform.position.x; //Space available for next piece
        float SpaceNeeded = nextPiece.GetComponent<SpriteRenderer>().size.x / 2 + ClosestTerrain().GetComponent<SpriteRenderer>().size.x / 2; // space we need  

        if (SpaceforNPiece >= SpaceNeeded)               
                return true;
        else
            return false;

    }

    public GameObject PieceToSpawn() //select piece to spawn
    {
        int index = Random.Range(0, terrain.Length);
        return terrain[index];
    }


    public void SpawnLand(GameObject a)
    {
        GameObject b = Instantiate(a) as GameObject;
        b.transform.position = new Vector2(xSpawnPoint, screenBounds.y - screenBounds.y);  //create it and set location
        b.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0); //set velocity

    }


    public GameObject ClosestTerrain()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("terrain"); //terrain was the tag I used but feel free to change it
        float xpos;
        float dcloseObj = xSpawnPoint; 
        int objInd = -1;

        for (int i = 0; i < obj.Length; i++)
        {
            xpos = obj[i].transform.position.x;
            if (xSpawnPoint - xpos < dcloseObj) //find terrain closeset to spawn point
            {
                dcloseObj = xSpawnPoint - xpos; //difference between closest piece and spawn point    
                objInd = i;
            }

        }
        return obj[objInd];

    }


    public void Destroy() //destroy object after it passes a certian point
    {
        GameObject[] toDestroy = GameObject.FindGameObjectsWithTag("terrain");
        for (int i = 0; i < toDestroy.Length; i++)
        {
            float x = toDestroy[i].transform.position.x;
            if (x <= whenToDissappear)
                Destroy(toDestroy[i]);
        }
    }
}
