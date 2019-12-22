using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// -------------------------
// Ground Generator:
// - Controls the ground generation
// -------------------------
public class GroundGenerator : MonobehaviorSingleton<GroundGenerator>
{
    //public GameObject[] terrain;
    private GameObject groundPrefab;
    private List<GameObject> spawnItems;
    private Vector2 screenBounds;
    private int listLen;

    private float speed = 10.0f;
    private float whenToDissappear;
    public float spawnPoint = 0;
    private bool called = false;
    // no terrain every k-th block
    private int k = 4;
    private float gap_width;

    void Awake()
    {
        groundPrefab = Resources.Load<GameObject>("Prefab/GroundBlock");
        groundPrefab.GetComponent<BoxCollider2D>().enabled = true;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        listLen = (int)(((2 * screenBounds.x) + 4) / (groundPrefab.GetComponent<BoxCollider2D>().size.x));
        listLen += (k - 1 - (listLen % k));
        spawnPoint = (screenBounds.x + 2 + groundPrefab.GetComponent<BoxCollider2D>().size.x);

    }

    void Start()
    {
        GameObject[] ter = GameObject.FindGameObjectsWithTag("Ground");
        for (int i = 0; i < ter.Length; i++)
            ter[i].GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);

        whenToDissappear = -1.2f * screenBounds.x;
    }

    void FixedUpdate()
    {
        if (this.transform.position.x <= screenBounds.x + 2)
        {
            setTer();
            if (!called) // only generate ground set once
                genTer();
        }
        Destroy();
    }

    private void setTer()
    {
        spawnItems = new List<GameObject>();
        for (int i = 0; i < listLen; i++)
        {
            GameObject ground = Instantiate(groundPrefab, new Vector3(spawnPoint, 0, 0), Quaternion.identity);
            spawnItems.Add(ground);
            Destroy(ground);
            spawnItems[i].GetComponent<BoxCollider2D>().enabled = true;

            if (i == listLen - 1)
                spawnItems[i].AddComponent<GroundGenerator>();
        }
    }

    private void genTer()
    {
        for (int i = 0; i < listLen; i++)
        {
            if ((i + 1) % k == 0)
            {
                spawnPoint += spawnItems[i].GetComponent<BoxCollider2D>().size.x / 2;
            }

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

    public void genFirstSet()
    {
        float startpoint = 0;
        listLen += k;
        setTer();
        int i = 0;
        while (i < listLen)
        {
            if ((i + 1) % k == 0)
            {
                startpoint += spawnItems[i].GetComponent<BoxCollider2D>().size.x / 2;
            }

            else
            {
                GameObject block = Instantiate(spawnItems[i], new Vector3(startpoint, 0, 0), Quaternion.identity);
                block.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
                startpoint += spawnItems[i].GetComponent<BoxCollider2D>().size.x / 2;
            }
            i++;
        }

    }

}
