using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour {
    
         private CharacterController charController;
         private CharacterAnimations playerAnimations;
         
         public float movement_speed = 3f;
         public float gravity = 9.8f;
         public float rotation_speed = 0.15f;
         public float rotateDegresPerSecond = 180f;
         
    

         void Awake() {
            charController = GetComponent<CharacterController>();
            playerAnimations = GetComponent<CharacterAnimations>();
         }

         void Update () {
            move();
            Rotate();
            AnimateWalk();

         }
         void move() {

             if(Input.GetAxis(Axis.VERTICAL_AXIS)>0) {
                Vector3 moveDirection = transform.forward;
                moveDirection.y -= gravity* Time.deltaTime;

                charController.Move(moveDirection * movement_speed * Time.deltaTime);

             } else if(Input.GetAxis(Axis.VERTICAL_AXIS)<0){
                Vector3 moveDirection = -transform.forward;
                moveDirection.y -= gravity* Time.deltaTime;

                charController.Move(moveDirection * movement_speed * Time.deltaTime);

             }  else {

                charController.Move(Vector3.zero);
             }
                


           }
               void Rotate() {
                    Vector3 rotation_Direction = Vector3.zero;
                    if(Input.GetAxis(Axis.HORIZONTAL_AXIS)<0) {
                           rotation_Direction = transform.TransformDirection(Vector3.left);
                    }
                     if(Input.GetAxis(Axis.HORIZONTAL_AXIS)>0) {
                       rotation_Direction = transform.TransformDirection(Vector3.right);
                    }

                    if(rotation_Direction != Vector3.zero) {

                        transform.rotation = Quaternion.RotateTowards(
                            transform.rotation, Quaternion.LookRotation(rotation_Direction),
                            rotateDegresPerSecond * Time.deltaTime);
                        
                    }
               }
                    void AnimateWalk() {

                        
                        if(charController.velocity.sqrMagnitude != 0f) {
                            playerAnimations.Walk(true);
                        } else {
                            playerAnimations.Walk(false);
                        }
                    }
             }

         
