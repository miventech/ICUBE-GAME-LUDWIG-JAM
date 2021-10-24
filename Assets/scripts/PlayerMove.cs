using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float velRot = 1;
    public float inpulse = 1;
    public float reloadTime = 1;
    public float _reloadTime = 0.01f;
    public float limitVel = 100;
    public float limitVelAngular = 100;
    public Rigidbody2D rb2d;

    public TextMesh countJumpText;

    public int maxJumps = 2;
    public int countJump = 2;
    Vector3 posIntial;

    public AudioSource deadSound;
    public AudioSource initialSound;
    public AudioSource JumpSound;
    public AudioSource impactWallSound;
    public AudioClip[] hitList;
    public ParticleSystem jumpUpPFX;
    public ParticleSystem jumpDownPFX;

    public ParticleSystem explosion;
    public ParticleSystem vortexParticle;

    public GameObject keyObject;
    
    public bool hasKey = false;


    void Start()
    {
        posIntial = transform.position;
        rb2d = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        float axisx = Input.GetAxis("Horizontal");
        float axisy = Input.GetAxisRaw("Vertical");
        if(axisx != 0){
            rb2d.AddTorque(velRot * Time.deltaTime * -axisx);
        }
        if(axisy != 0 && _reloadTime <= 0 && countJump > 0){
            countJump --;
            rb2d.AddForce(transform.up * axisy * inpulse , ForceMode2D.Impulse);
            _reloadTime = reloadTime;
            JumpSound.Play();
            if(axisy > 0){
                jumpUpPFX.Play();
            }else if( axisy < 0){
                jumpDownPFX.Play();
            }
        }

        if(hasKey){
            keyObject.SetActive(true);
        }else{
            keyObject.SetActive(false);
        }


        if(_reloadTime >= 0) _reloadTime -= Time.deltaTime;
        
        if(rb2d.velocity.magnitude > limitVel){
            rb2d.velocity = rb2d.velocity.normalized * limitVel;
        }
        if(rb2d.angularVelocity > limitVelAngular){
            rb2d.angularVelocity = limitVelAngular;
        }
        if(rb2d.angularVelocity < -limitVelAngular){
            rb2d.angularVelocity = -limitVelAngular;
        }
        countJumpText.text = countJump.ToString();
    }   

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "dontTouch"){
            dead();
        }
        if(other.tag == "endGame"){
            endGame();
        }
        if(other.tag == "reducer"){
            countJump = 0;

            if(rb2d.velocity.magnitude > 2){
                rb2d.velocity = rb2d.velocity.normalized * 2;
            }
        }
        if(other.tag == "key"){
            hasKey = true;
            Destroy(other.gameObject);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.collider.CompareTag("checkPoint")){
            posIntial = other.collider.GetComponent<chackpointFloor>().positionReSpawn.position;
        }
        if(!other.collider.CompareTag("noRestore")) countJump = maxJumps;
        playRamdonHit();
    }

    public void playRamdonHit(){
        impactWallSound.clip = hitList[Random.Range(0 , hitList.Length)];
        impactWallSound.Play();
    }
    public void dead(){
        Instantiate(explosion , transform.position ,Quaternion.identity ,  null);
        transform.position = posIntial;
        transform.rotation = Quaternion.identity;
        rb2d.velocity = Vector2.zero;
        rb2d.angularVelocity = 0;
        vortexParticle.Play();
        deadSound.Play();
        countJump = maxJumps;

    }

    public void endGame(){
        Instantiate(explosion , transform.position ,Quaternion.identity ,  null);
        transform.position = Vector3.one * 1000;
        transform.rotation = Quaternion.identity;
        rb2d.velocity = Vector2.zero;
        rb2d.angularVelocity = 0;
        vortexParticle.Play();
        deadSound.Play();
        countJump = maxJumps;
        FindObjectOfType<Canvas>().GetComponent<Animator>().enabled = true;
    }
}
