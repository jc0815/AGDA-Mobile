using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGen : MonoBehaviour
{
    public GameObject[] terrain;
    public float speed = 10.0f;
    private Vector2 screenBounds;
    private float whenToDissappear;
    private GameObject nextPiece;

    void Awake()
    {
        GameObject[] ter = GameObject.FindGameObjectsWithTag("terrain");
        for (int i = 0; i < ter.Length; i++)
            ter[i].GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);

    }
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        whenToDissappear = -1 * screenBounds.x * 1.5f;
        nextPiece = PieceToSpawn();
        

    }

    void Update()
    {
        if (TimeToSpawn())
        {
            print("called");
            SpawnLand(nextPiece);
            nextPiece = PieceToSpawn();

        }
        Destroy();
    }

    public bool TimeToSpawn() //check if okay to spawn
    {
        float SpaceforNPiece = (screenBounds.x + 10f) - ClosestTerrain().transform.position.x; //Space available for next piece
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
        b.transform.position = new Vector2(screenBounds.x + 10f, -1 * screenBounds.y);  //create it and set location
        b.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0); //set velocity

    }


    public GameObject ClosestTerrain()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("terrain"); //terrain was the tag I used but feel free to change it
        float xpos;
        float dcloseObj = 50f;
        int objInd = -1;

        for (int i = 0; i < obj.Length; i++)
        {
            xpos = obj[i].transform.position.x;
            if (xpos > 0 && ((screenBounds.x + 10f) - xpos) < dcloseObj) //find terrain closeset to spawn point
            {
                dcloseObj = screenBounds.x + 10 - xpos; //difference between closet piece and spawn point              
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
