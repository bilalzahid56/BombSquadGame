using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Enemy_Movement_TO_Player : MonoBehaviour
{
    private float RotationSpeed = 0.1f;
    public GameObject bombSticky;
    public float speed =3f;
    private   GameObject player;
    public CharacterController controller;
    private float _gravity = -9.81f;
    [SerializeField] private float gravityMultiplier = 3.0f;
    private float _velocity;
    private Vector3 lookDIrection;
    void Start()
    {
        controller = GetComponent<CharacterController>();
        player = GameObject.Find("Player");
    }


    void Update()
    {
         lookDIrection = (player.transform.position - transform.position).normalized;
        controller.Move(lookDIrection * speed*Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookDIrection), RotationSpeed);
        if(transform.position.y>-0.66)
        {
            transform.position = new Vector3(transform.position.x, -0.645f, transform.position.z);
        }
    }
    private void ApplyGravity()
    {
        if (controller.isGrounded && _velocity < 0.0f)
        {
            _velocity = -1.0f;
        }
        else
        {
            _velocity += _gravity * gravityMultiplier * Time.deltaTime;
        }

        lookDIrection.y = _velocity;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bomb"))
        {

            Destroy(gameObject);

        }
      

    }

}
