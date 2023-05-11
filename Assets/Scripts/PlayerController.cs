using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Variable déplacement
    public CharacterController cc;
    public float moveSpeed;
    public float jumpForce;
    public float gravity;
    private Vector3 moveDir;

    // Update is called once per frame
    void Update()
    {
        //Calcule direction
        moveDir = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDir.y, Input.GetAxis("Vertical") * moveSpeed);
        
        //Check touche espace
        if(Input.GetButtonDown("Jump"))
        {
            moveDir.y = jumpForce;
        }

        //Applique gravité
        moveDir.y -= gravity * Time.deltaTime;

        //Check si mouvement
        if(moveDir.x != 0 || moveDir.z != 0)
        {
            //Tourne regard dans diréction
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(moveDir.x, 0, moveDir.z)), 0.15f);
        }

        //Applique déplacement
        cc.Move(moveDir * Time.deltaTime);
    }
}
