using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DpadMovement : MonoBehaviour
{
    [SerializeField] private CharacterDatabase charDB;

    private Rigidbody2D rb;
    [SerializeField]
    private float movSpeed;

    private Animator anim;
    string currentState;
    const string PLAYER_IDLE = "Player_Idle";
    const string PLAYER_WALK_LEFT = "Player_Walk_Left";
    const string PLAYER_WALK_RIGHT = "Player_Walk_Right";
    const string PLAYER_WALK_UP = "Player_Walk_Up";
    const string PLAYER_WALK_DOWN = "Player_Walk_Down";

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        charDB.playerPosition = gameObject.transform.position;
    }

    public void MoveUp()
    {
        rb.velocity = Vector2.up * movSpeed;
        ChangeAnimationState(PLAYER_WALK_UP);
    }

    public void MoveDown()
    {
        rb.velocity = Vector2.down * movSpeed;
        ChangeAnimationState(PLAYER_WALK_DOWN);
    }

    public void MoveLeft()
    {
        rb.velocity = Vector2.left * movSpeed;
        ChangeAnimationState(PLAYER_WALK_LEFT);
    }

    public void MoveRight()
    {
        rb.velocity = Vector2.right * movSpeed;
        ChangeAnimationState(PLAYER_WALK_RIGHT);
    }

    public void StopMoving()
    {
        rb.velocity = Vector2.zero;
        ChangeAnimationState(PLAYER_IDLE);
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
