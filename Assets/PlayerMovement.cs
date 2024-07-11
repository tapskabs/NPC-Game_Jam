using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;
    public float sizeIncreaseAmount = 0.1f;
    private int edibleCount;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        edibleCount = 0;
    }

    void Update()
    {
        
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }
    void FixedUpdate()
    {
        
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.gameObject.CompareTag("Edible"))
        {
            edibleCount++;
            Destroy(other.gameObject);
            Debug.Log("Food eaten" + edibleCount);
            GetBig();
            //Debug.Log("Food eaten" + edibleCount);
            
        }
       
    }
    public void GetBig()
    {
        Vector3 newSize = transform.localScale;
        newSize += new Vector3(sizeIncreaseAmount, sizeIncreaseAmount, 0); // Adjust this line for 3D scaling if needed
        transform.localScale = newSize;
    }

    public int GetEdibleCount()
    {
        return edibleCount; // Return the count of destroyed edible objects
    }
}
