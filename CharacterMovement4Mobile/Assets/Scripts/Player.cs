using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public MovementJoystick movementJoystick;
    public float playerSpeed;
    private Rigidbody2D rb;

    // Animations and states
    private Animator anim;
    string currentState;
    const string PLAYER_IDLE = "Player_Idle";
    const string PLAYER_WALK_LEFT = "Player_Walk_Left";
    const string PLAYER_WALK_RIGHT = "Player_Walk_Right";
    const string PLAYER_WALK_UP = "Player_Walk_Up";
    const string PLAYER_WALK_DOWN = "Player_Walk_Down";

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (movementJoystick.joystickVec.x > movementJoystick.joystickVec.y)
        {
            //if player moves joystick right
            if (movementJoystick.joystickVec.x > 0)
            {
                ChangeAnimationState(PLAYER_WALK_RIGHT);
            }
            //if player moves joystick left
            else if (movementJoystick.joystickVec.x < 0)
            {
                ChangeAnimationState(PLAYER_WALK_LEFT);
            }
        }
        else
        {
            //if player moves joystick up
            if (movementJoystick.joystickVec.y > 0)
            {
                ChangeAnimationState(PLAYER_WALK_UP);
            }
            //if player moves joystick down
            else if (movementJoystick.joystickVec.y < 0)
            {
                ChangeAnimationState(PLAYER_WALK_DOWN);
            }
        }
    }


    void FixedUpdate()
    {
        if (movementJoystick.joystickVec.y != 0 || movementJoystick.joystickVec.x != 0)
        {
            if (movementJoystick.joystickVec.y < movementJoystick.joystickVec.x)
            {
                rb.velocity = new Vector2(movementJoystick.joystickVec.x * playerSpeed, 0);
            }
            else
            {
                rb.velocity = new Vector2(0, movementJoystick.joystickVec.y * playerSpeed);
            }
            // kunin mo Vector2(x, 0) kapag left and right
            // vector2(y,0); up down

            // eto kase (x,y) kaya may diagonal

        }
        else
        {
            rb.velocity = Vector2.zero;
            ChangeAnimationState(PLAYER_IDLE);
        }
    }


    // Animation state changer
    void ChangeAnimationState(string newState)
    {
        // Stop animation from interrupting itself
        if (currentState == newState) return;

        // Play new animation
        anim.Play(newState);

        //Update current state
        currentState = newState;
    }

}
