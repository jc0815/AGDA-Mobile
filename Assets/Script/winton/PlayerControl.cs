using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Animator animator;
    public Transform firePoint;
    public GameObject bullet;
    bool isShoot;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isShoot = Input.GetButtonDown("shoot");
        if(isShoot) {
            animator.SetBool("shoot", true);
            shoot();
        }
        if(Input.GetButtonUp("shoot")) {
            animator.SetBool("shoot", false);
        }
    }
    void shoot () {
        Instantiate(bullet, firePoint.position, Quaternion.identity); 
    }
}
