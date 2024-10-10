using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] float speed= 20f; //toc do di chuyen
    private float horizontalInput; //bien luu gia tri di chuyen ngang
    //Jump
    [SerializeField] float jumpForce = 100f; // luc nhay
    private bool isGrounded = false; // kiem tra co cham dat hay khong
    private Animation animation;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();// lay thong tin cua Rigidbody
        animation = gameObject.GetComponentInChildren<Animation>();
        animator = gameObject.GetComponentInChildren<Animator>();
        animation = gameObject.GetComponentInChildren<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            Jump();
        }
    }

    private void FixedUpdate(){
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + horizontalMove + forwardMove);
    }
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Ground")){
            isGrounded = true;
        }
        }
    private void OnCollisionStay(Collision collision){
        if(collision.gameObject.CompareTag("Ground")){
            isGrounded = true;
    }
    }
    private void OnCollisionExit(Collision collision){
        if(collision.gameObject.CompareTag("Ground")){
            isGrounded = false;
        }
    }
    void Jump(){
        animator.SetTrigger("Jump");
        rb.AddForce(Vector3.up * jumpForce);
    }
}