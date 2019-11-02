using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// -------------------------
// Ground Generator:
// - Controls the ground generation
// -------------------------
public class GroundGenerator : MonobehaviorSingleton<GroundGenerator>
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GenerateGroundBlock();
    }

    // Generates ground block
    // TODO: 1) Generate a block every frame
    // TODO: 2) Move block towards the left
    // TODO: 3) Implement a break every k-th block
    void GenerateGroundBlock()
    {

    }
}
