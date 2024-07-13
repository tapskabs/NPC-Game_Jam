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
    public float sizeAmountOG = 0.0f;
    private int edibleCount;
    public Vector3 original;
    public float sizeUpCount;
    public int progress;
    public int requirments;
    public LevelSystem levelSystem;
    public Animator animator;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Area Colliders"))
        {
            rb.velocity = Vector2.zero;

        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        edibleCount = 0;
        sizeUpCount = 0;
 
        
    }

    void Update()
    {
        levelSystem = GetComponent<LevelSystem>();

        int progress = levelSystem.currentProgress;
        int requirments = levelSystem.currentRequirement;

        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (progress >= requirments)
        {
            sizeUpCount = 0.0f;
            GoSmall();
            Debug.Log("Size Reduced New LEVEL");
        }
    }



    void FixedUpdate()
    {

        // rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        rb.velocity = movement * moveSpeed * Time.deltaTime;
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
        sizeUpCount += 0.1f;
        Debug.Log("Size Up Float Count" + sizeUpCount);

        Vector3 newSize = transform.localScale;
        newSize += new Vector3(sizeIncreaseAmount, sizeIncreaseAmount, 0); // Adjust this line for 3D scaling if needed
        transform.localScale = newSize;
    }

    void GoSmall()
    {
        ;
        Vector3 originalSize = transform.localScale;
        originalSize -= new Vector3(sizeUpCount, sizeUpCount, 0);
        transform.localScale = originalSize;
    }

    public int GetEdibleCount()
    {
        return edibleCount; // Return the count of destroyed edible objects
    }
}
