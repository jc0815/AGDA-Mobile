using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// -------------------------
// Bottom Obstacle Generator:
// - Controls the top obstacle
// -------------------------
public class ObstacleGenerator : MonobehaviorSingleton<ObstacleGenerator>
{
    // Update is called once per frame
    // TODO: Instantiate obstacle blocks on the view ceiling
    // TODO: Checks bottom obstacle to make sure the total view height > obstacle height
    // TODO: Implement algorithm to spawn different obstacles at different times
    private Vector2 screenBounds;
    private GameObject block;
    private GameObject blocktwo;
    private GameObject screenBlock;
    private GameObject detector;

    private GameObject car_blue;
    private GameObject car_red;
    private GameObject car_yellow;

    private int width = 0;
    private int height = 0;
    public bool[,] blocks = new bool[21, 13];
    public bool[,] topBlocks = new bool[21, 13];
    private float whenToDissappear;
    private float placeToDestoryDector;
    private float speed = 3f;
    // Start is called before the first frame update

    void Awake()
    {
        //Generate();
        block = Resources.Load<GameObject>("Prefab/ground-individual");
        blocktwo = Resources.Load<GameObject>("Prefab/ObstacleBlock");
        detector = Resources.Load<GameObject>("Prefab/detector");

        car_blue = Resources.Load<GameObject>("Prefab/car-blue");
        car_red = Resources.Load<GameObject>("Prefab/car-red");
        car_yellow = Resources.Load<GameObject>("Prefab/car-yellow");

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        whenToDissappear = -1.2f * screenBounds.x;
        placeToDestoryDector = screenBounds.x;
        width = (int)(screenBounds.x) + 1;
        height = (int)(screenBounds.y);
        screenBlock = GameObject.FindGameObjectWithTag("Obstacle");
        // Debug.Log("found screenBlock?" + screenBlock);
    }
    GameObject getBlock(int x, int offset, int y)
    {
        int number = Random.Range(1, 4);
        switch (number)
        {
            case 1:
                return Instantiate(car_blue, new Vector3(x + offset, y, 0), Quaternion.identity);
            case 2:
                return Instantiate(car_red, new Vector3(x + offset, y, 0), Quaternion.identity);
            case 3:
                return Instantiate(car_yellow, new Vector3(x + offset, y, 0), Quaternion.identity);
        }

        return Instantiate(block, new Vector3(x + offset, y, 0), Quaternion.identity);
    }
    // Start is called before the first frame update
    void Generate()
    {
        int offset = width;
        //from boottom to up
        //Debug.Log("the width" + width);
        for (int y = 0; y < height; ++y)
        {
            for (int x = 0; x < width; ++x)
            {

                blocks[x, y] = false;
                //Debug.Log("the x is " + x + " the y is " + y);
                bool isGenerate = Random.Range(0.5f, 2 - 0.23f * y) > 1 ? true : false;
                if (y == 0 && isGenerate)
                {
                    // GameObject childBlock = Instantiate(block, new Vector3(x + offset, y, 0), Quaternion.identity);
                    GameObject childBlock = Instantiate(block, new Vector3(x + offset, y, 0), Quaternion.identity);
                    blocks[x, y] = true;
                    childBlock.transform.SetParent(screenBlock.transform);
                }
                if (y != 0 && hasNeighborBottom(x, y) && isGenerate)
                {
                    //Debug.Log("the y is " + y);
                    GameObject childBlock = getBlock(x, offset, y);
                    blocks[x, y] = true;
                    childBlock.transform.SetParent(screenBlock.transform);
                }
            }
        }
        //from up to bottom
        for (int y = height - 1; y > 0; y--)
        {
            for (int x = width - 1; x > 0; x--)
            {
                topBlocks[x, y] = false;
                //Debug.Log("the x is " + x + " the y is " + y);
                bool isGenerate = Random.Range(0.5f, 2 - 0.23f * (Mathf.Abs(y - height))) > 1 ? true : false;
                if (y == height - 1 && isGenerate)
                {
                    GameObject childBlock = Instantiate(blocktwo, new Vector3(x + offset, y + 1, 0), Quaternion.identity);
                    topBlocks[x, y] = true;
                    childBlock.transform.SetParent(screenBlock.transform);
                }
                if (y != 0 && hasNeighborUp(x, y) && isGenerate)
                {
                    //Debug.Log("the y is " + y);
                    GameObject childBlock = Instantiate(blocktwo, new Vector3(x + offset, y + 1, 0), Quaternion.identity);
                    topBlocks[x, y] = true;
                    childBlock.transform.SetParent(screenBlock.transform);
                }
            }
        }
        Instantiate(detector, new Vector3(width * 2, height, 0), Quaternion.identity);
    }

    public void Destroy() //destroy object after it passes a certian point
    {
        GameObject[] toDestroy = GameObject.FindGameObjectsWithTag("Ground");
        for (int i = 0; i < toDestroy.Length; i++)
        {
            float x = toDestroy[i].transform.position.x;
            if (x <= whenToDissappear)
                Destroy(toDestroy[i]);
        }
        GameObject detector = GameObject.FindGameObjectWithTag("detector");
        float detectorPosition = detector.transform.position.x;
        if (detectorPosition <= placeToDestoryDector)
            Destroy(detector);
    }



    bool hasNeighborUp(int x, int y)
    {
        if (hasNeighborBottom(x, y))
        {
            return false;
        }
        if (y >= 2 && blocks[x, y - 2] == true)
        {
            return false;
        }
        if (topBlocks[x, y + 1] == true)
        {
            return true;
        }
        else if (x == 0)
        {
            return false;
        }
        else if (topBlocks[x - 1, y] == true)
        {
            return true;
        }
        return false;
    }
    bool hasNeighborBottom(int x, int y)
    {
        if (blocks[x, y - 1] == true)
        {
            return true;
        }
        else if (x == 0)
        {
            return false;
        }
        else if (blocks[x - 1, y] == true)
        {
            return true;
        }
        return false;
    }
    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.G))
        // {
        //     Debug.Log("G is pressed");
        //     this.Generate();
        // }
        if (Input.GetKeyDown(KeyCode.C))
        {
            blocks = new bool[21, 13];
        }
        // screenBlock.GetComponent<Rigidbody2D>().velocity += new Vector2(speed, 0);
        // screenBlock.transform.localPosition = new Vector2(width, 0);
        if (!hasDetector())
        {
            this.Generate();
        }
        move();
        Destroy();
    }
    void move()
    {
        GameObject[] ter = GameObject.FindGameObjectsWithTag("Ground");
        GameObject detector = GameObject.FindGameObjectWithTag("detector");
        detector.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
        for (int i = 0; i < ter.Length; i++)
            ter[i].GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);

        // whenToDissappear = -1.2f * screenBounds.x;
    }
    bool hasDetector()
    {
        GameObject detector = GameObject.FindGameObjectWithTag("detector");
        if (detector == null)
        {
            return false;
        }
        return true;
    }
}
