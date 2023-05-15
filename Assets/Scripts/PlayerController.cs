using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private CharacterController cc;
    //Variable d�placement
    public float moveSpeed;
    public float jumpForce;
    public float gravity;
    private Vector3 moveDir;
    private Animator anim;
    bool isWalking = false;
    private void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        //Calcule direction
        moveDir = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDir.y, Input.GetAxis("Vertical") * moveSpeed);
        
        //Check touche espace
        if(Input.GetButtonDown("Jump") && cc.isGrounded)
        {
            moveDir.y = jumpForce;
        }

        //Applique gravit�
        moveDir.y -= gravity * Time.deltaTime;

        //Check si mouvement
        if(moveDir.x != 0 || moveDir.z != 0)
        {
            isWalking = true;
            //Tourne regard dans dir�ction
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(moveDir.x, 0, moveDir.z)), 0.15f);
        }
        else
        {
            isWalking = false; // On arrete de marcher
        }

        anim.SetBool("isWalking", isWalking); //indique � l'animator si l'on marche

        //Applique d�placement
        cc.Move(moveDir * Time.deltaTime);
    }
}
