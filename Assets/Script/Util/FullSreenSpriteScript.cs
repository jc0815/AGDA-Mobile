using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullSreenSpriteScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        SpriteRenderer spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        float cameraHeight = Camera.main.orthographicSize * 2;
        Vector2 cameraSize = new Vector2(Camera.main.aspect * cameraHeight, cameraHeight);
        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;
    }
}
