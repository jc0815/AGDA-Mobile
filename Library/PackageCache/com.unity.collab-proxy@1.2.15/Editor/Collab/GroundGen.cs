using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGen : MonoBehaviour
{
    //public GameObject[] terrain;
    private GameObject ground;
    private List<GameObject> spawnItems;
    private Vector2 screenBounds;
    private int listLen;

    private float speed = 10.0f;
    private float whenToDissappear;
    private float spawnPoint;
    private bool called = false;   
    // no terrain every k-th block
    private int k = 4;

    void Awake()
    {
        ground = Resources.Load<GameObject>("Prefab/GroundBlock");
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        listLen = (int)((screenBounds.x + 4) / (ground.GetComponent<SpriteRenderer>().size.x));
        spawnPoint = screenBounds.x + 4;
    }

    void Start()
    {
        GameObject[] ter = GameObject.FindGameObjectsWithTag("Ground");
        for (int i = 0; i < ter.Length; i++)
            ter[i].GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);

        whenToDissappear = -0.4f * screenBounds.x;
    }

    void Update()
    {
        if (this.transform.position.x <= spawnPoint)
        {
            setTer();
            if (!called)
                genTer();
        }
        Destroy();
    }

    private void setTer()
    {
        spawnItems = new List<GameObject>();
        for (int i = 0; i < listLen; i++)
        {
            spawnItems.Add(ground);
            if (i == listLen - 1)                
                if (spawnItems[i].GetComponent<GroundGenerator>() == null)
                    spawnItems[i].AddComponent<GroundGenerator>();
                           
        }
    }

    private void genTer()
    {
        for (int i = 0; i < listLen; i++)
        {
            if ((i + 1) % k == 0)
                spawnPoint += spawnItems[i].GetComponent<BoxCollider2D>().size.x/2;
            else
            {
                GameObject block = Instantiate(spawnItems[i], new Vector3(spawnPoint, 0, 0), Quaternion.identity);
                block.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
                spawnPoint += spawnItems[i].GetComponent<BoxCollider2D>().size.x / 2;                
            }
        }
        called = true;
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
    }
}