using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    
    //public AudioSource audioBomb;
    public Animator anim;
    public float InputX;
    public float InputZ;
    public Vector3 MoveDirection;
    public Camera cam;
    public CharacterController controller ;
    public float Speed;
    public bool blockRotationPlayer;
    public float RotationSpeed = 0.1f;
    public float VerticalAnimTime = 0.2f;
    public float HorizontalAnimSmoothTime = 0.2f;
    private float _gravity = -9.81f;
    [SerializeField] private float gravityMultiplier = 3.0f;
    private float _velocity;
    private Vector3 reset = Vector3.zero;
    public GameObject simpleBomb10s;
    public GameObject bombAttackImediate;
    public GameObject stickyBomb;
    public GameObject player;
    public Transform bombArea;
  //  private Bomb2 rb;
    private int bomBoxDestoryFirst;
    private int bomBoxDestorySecond ;
    private int bomBoxDestoryThird ;
  //  private int bombFirstRepeating = 0;
   // private int bombSecondRepeating = 0;
   //private int bombThirdRepeating = 0;
    public GameObject bomBox1;
    public GameObject enemy;
    private Vector3 resetPosition = new Vector3(0, -0.65f, 0);
    public GameObject bomb1;
    public GameObject bomb2;
    public GameObject bomb3;
    //private Vector3 boundary = new Vector3();
    private void Start()
    {
        
        anim = this.GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        cam = Camera.main;
        //audioBomb = GetComponent<AudioSource>();
        
    }
    private void Update()
    {
        if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.S)) || (Input.GetKey(KeyCode.D)))
        {
            PlayerMoveAndRotation();
            anim.SetBool("Running", true);
            anim.SetBool("Punching", false);
            anim.SetBool("Throw", false);
            
        }
        else
        {
            anim.SetBool("Running", false);
        }

        //if(player.transform.position > )
        //{
    //        player.transform.position = reset;
      //  }



        PunchingAnim();
        ThrowSimpleBomb();
        ThrowBombAttackImediate();
        ApplyGravity();
        ThrowStickyBomb();
       if (transform.position.y > -0.74f)
       {
          transform.position = new Vector3(transform.position.x, -0.72f, transform.position.z);
        }
    }
    void PlayerMoveAndRotation()
    {
        InputX = Input.GetAxis("Horizontal");
        InputZ = Input.GetAxis("Vertical");

        var camera = Camera.main;
        var forward = cam.transform.forward;
        var right = cam.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        MoveDirection = forward * InputZ + right * InputX;

        if (blockRotationPlayer == false)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(MoveDirection), RotationSpeed);
           
            controller.Move(MoveDirection * Time.deltaTime * Speed);
            anim.SetBool("Running", true);
        }
       
       
    }
    public void LookAt(Vector3 pos)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(pos), RotationSpeed);
    }

    public void RotateToCamera(Transform t)
    {

        var camera = Camera.main;
        var forward = cam.transform.forward;
        var right = cam.transform.right;

        MoveDirection = forward;

        t.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(MoveDirection), RotationSpeed);
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
            MoveDirection.y = _velocity;
        }

        MoveDirection.y = _velocity;
    }
  
    private void PunchingAnim()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            anim.SetBool("Punching", true);
           /* void   OnCollisionEnter(Collision collision)
            {
                if (collision.gameObject.CompareTag("Enemy"))
                {

                    Debug.Log("Enemy");
                     Destroy(this.enemy);
                }

            }*/
        }
    }



    void ThrowSimpleBomb()
    {
        if (bomBoxDestoryFirst > 0)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                bomBoxDestoryFirst = bomBoxDestoryFirst - 1;
                anim.SetBool("Throw", true);
                StartCoroutine("WaitForBomb");
                Instantiate(simpleBomb10s, bombArea.transform.position, player.transform.rotation);


            }
            
        }
      
    }
    void ThrowBombAttackImediate()
    {
        if (bomBoxDestorySecond > 0)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                bomBoxDestorySecond = bomBoxDestorySecond - 1;
                anim.SetBool("Throw", true);
                StartCoroutine("WaitForBomb");
                Instantiate(bombAttackImediate, bombArea.transform.position, player.transform.rotation);
                //audioBomb.Play();


            }
            

        }
    }
    void ThrowStickyBomb()
    {
        if (bomBoxDestoryThird > 0)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                bomBoxDestoryThird = bomBoxDestoryThird - 1;
                anim.SetBool("Throw", true);
                StartCoroutine("WaitForBomb");
                Instantiate(stickyBomb, bombArea.transform.position, player.transform.rotation);
                Instantiate(stickyBomb, bombArea.transform.position, player.transform.rotation);
                Instantiate(stickyBomb, bombArea.transform.position, player.transform.rotation);
                //audioBomb.Play();

            }
           
        }
    }



    IEnumerator WaitForBomb()
    {
        yield return new WaitForSeconds(2.5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BombBox1"))
        {
            bomBoxDestoryFirst++;
            Debug.Log("Box1" + bomBoxDestoryFirst);
            // Destroy(this.);
        }
        if (other.gameObject.CompareTag("BombBox2"))
        {
            bomBoxDestorySecond++;
            Debug.Log("Box2"+ bomBoxDestorySecond);
            // Destroy(this.);
        }
        if (other.gameObject.CompareTag("BombBox3"))
        {
            bomBoxDestoryThird++;
            Debug.Log("Box3"+ bomBoxDestoryThird);
            // Destroy(this.);
        }
        if(other.gameObject.CompareTag("Enemy"))
        {
            player.transform.position = resetPosition;
        }


        if (other.gameObject.CompareTag("BOundary"))
        {
            player.transform.position = resetPosition;
        }
       


    }



}
