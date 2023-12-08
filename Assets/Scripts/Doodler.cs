using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doodler : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    private float move = 0f;

    private void FixedUpdate(){
        Vector2 velocity = _rigidbody2D.velocity;
        velocity.x = move;
        _rigidbody2D.velocity = velocity;  
    }

    void Update(){
        move = Input.GetAxis("Horizontal") * moveSpeed;        
    }    
}
