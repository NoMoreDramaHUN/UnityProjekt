using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D theRB;
    public float moveSpeed;

    public Animator myAnim;

    public static PlayerController instance;

    public string areaTransitionName;
    
    // Use this for initialization
    void Start () {
        if (instance == null) {
            instance = this;
            Debug.Log("PlayerController instance set.");
        } else {
            Debug.Log("Duplicate PlayerController instance found. Destroying.");
            Destroy(gameObject);
        }
            
        DontDestroyOnLoad(gameObject);
    }
    
    // Update is called once per frame
    void Update () {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Debug.Log("Move Input: " + moveInput);
        theRB.velocity = moveInput * moveSpeed;
        Debug.Log("Velocity: " + theRB.velocity);

        myAnim.SetFloat("moveX", theRB.velocity.x);    
        myAnim.SetFloat("moveY", theRB.velocity.y);

        if (moveInput.x != 0 || moveInput.y != 0) {
            myAnim.SetFloat("lastMoveX", moveInput.x);
            myAnim.SetFloat("lastMoveY", moveInput.y);
            Debug.Log("Last Move: (" + moveInput.x + ", " + moveInput.y + ")");
        }
    }
}