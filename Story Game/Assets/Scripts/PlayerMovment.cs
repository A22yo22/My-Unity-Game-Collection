using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

public class PlayerMovment : MonoBehaviour
{
    public float crouchSpeed = 1f;
    public float walkSpeed = 2.1f;
    public float runSpeed = 3f;

    public float jumpHight = 1;
    public float movmentSpeed = 2.1f;
    public Animator animator;
    public Animator camerShake;
    public GameObject player;
    public Rigidbody rb;
    public bool isCutScene;

    void Update()
    {
        //pr�ft ob es gerade eine Cut scene gibt wenn ja kann man sich nicht bewegen
        if (!isCutScene)
        {
            //Laufe nach Links
            if (Input.GetKey(KeyCode.A))
            {
                camerShake.SetBool("shake", true);

                //Rotiert spieler in die richt wo er hinl�uft
                player.transform.localRotation = Quaternion.Euler(0, -90, 0);

                //Setzt Idle animaton zu false
                animator.SetBool("zuIdle", false);

                //Pr�ft ob Shift gedr�gt ist und startet die run animation
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    animator.SetBool("zuWalk", false);
                    animator.SetBool("zuSlowRun", false);
                    animator.SetBool("zuRun", true);
                    movmentSpeed = runSpeed;
                }
                //Pr�ft ob Control/Steuerung gedr�gt ist und startet die crouch animation
                else if (Input.GetKey(KeyCode.LeftControl))
                {
                    animator.SetBool("zuWalk", false);
                    animator.SetBool("zuRun", false);
                    animator.SetBool("zuSlowRun", true);
                    movmentSpeed = crouchSpeed;
                }
                //Pr�ft ob kein von beiden tasten gedr�ckt ist und startet die walk animation
                else
                {
                    animator.SetBool("zuSlowRun", false);
                    animator.SetBool("zuRun", false);
                    animator.SetBool("zuWalk", true);
                    movmentSpeed = walkSpeed;
                }

                //bewegt den spieler nach rechts nur wen es ein neues vaue gibt
                float y = rb.velocity.y;
                rb.velocity = new Vector3(-movmentSpeed, y, 0);
            }
            //Wenn D nicht gedr�ckt starte Idle animation
            else if (!Input.GetKey(KeyCode.D))
            {
                animator.SetBool("zuWalk", false);
                animator.SetBool("zuRun", false);
                animator.SetBool("zuSlowRun", false);
                //starte Idle animation
                animator.SetBool("zuIdle", true);

                camerShake.SetBool("shake", false);

                //setze velocity auf 0
                float y = rb.velocity.y;
                rb.velocity = new Vector3(0, y, 0);
            }

            //Laufe nach Rechts
            if (Input.GetKey(KeyCode.D))
            {
                camerShake.SetBool("shake", true);

                //Rotiert spieler in die richt wo er hinl�uft
                player.transform.localRotation = Quaternion.Euler(0, 90, 0);

                //Setzt Idle animaton zu false
                animator.SetBool("zuIdle", false);

                //Pr�ft ob Shift gedr�gt ist und startet die run animation
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    animator.SetBool("zuWalk", false);
                    animator.SetBool("zuSlowRun", false);
                    animator.SetBool("zuRun", true);
                    movmentSpeed = runSpeed;
                }
                //Pr�ft ob Control/Steuerung gedr�gt ist und startet die crouch animation
                else if (Input.GetKey(KeyCode.LeftControl))
                {
                    animator.SetBool("zuWalk", false);
                    animator.SetBool("zuRun", false);
                    animator.SetBool("zuSlowRun", true);
                    movmentSpeed = crouchSpeed;
                }
                //Pr�ft ob kein von beiden tasten gedr�gt ist und startet die walk animation
                else
                {
                    animator.SetBool("zuSlowRun", false);
                    animator.SetBool("zuRun", false);
                    animator.SetBool("zuWalk", true);
                    movmentSpeed = walkSpeed;
                }

                //bewegt den spieler nach links
                float y = rb.velocity.y;
                rb.velocity = new Vector3(movmentSpeed, y, 0);
            }
            //Wenn A nicht gedr�ckt starte Idle animation
            else if (!Input.GetKey(KeyCode.A))
            {
                animator.SetBool("zuWalk", false);
                animator.SetBool("zuRun", false);
                animator.SetBool("zuSlowRun", false);
                //starte Idle animation
                animator.SetBool("zuIdle", true);

                camerShake.SetBool("shake", false);

                //setze velocity auf 0
                float y = rb.velocity.y;
                rb.velocity = new Vector3(0, y, 0);
            }

            //Springt nach oben
            if (Input.GetKey(KeyCode.Space))
            {
                animator.SetBool("zuJump", true);
            }
            else
            {
                animator.SetBool("zuJump", false);
            }
        }
        //Wenn eine Cut Scene gespielt wird state Idle animation
        else
        {
            animator.SetBool("zuWalk", false);
            animator.SetBool("zuRun", false);
            animator.SetBool("zuSlowRun", false);
            animator.SetBool("zuIdle", true);

            camerShake.SetBool("shake", false);
        }
    }
}
