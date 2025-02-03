using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveSpeed = 5.0f;
    private float turnSpeed = 100.0f;
    private float distance = 5.0f;
    private float playerHeight = 2.5f;
    private float gravity = 9.8f;
    private float jumpSpeed = 8.0f;
    private Camera mainCamera;
    public GameObject bulletPrefab;

    public Transform bulletSpawnPoint;
    public CharacterController characterController;
    public Animator m_animator;

    private Vector3 moveDirection;

    private bool canShoot = true; // 총알 발사 가능한 상태인지 여부
    public float shootInterval = 0.2f; // 발사 간격 (초)

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        characterController = GetComponent<CharacterController>();
        m_animator = GetComponent<Animator>();
    }
    private void LateUpdate()
    {
        Vector3 cameraPosition = transform.position + transform.up * playerHeight - transform.forward * distance;
        mainCamera.transform.position = cameraPosition;

        Vector3 lookAtPosition = transform.position + transform.up * playerHeight;
        mainCamera.transform.LookAt(lookAtPosition);
    }
    // Update is called once per frame
    void Update()
    {
        float H = Input.GetAxis("Horizontal");
        float V = Input.GetAxis("Vertical");

        moveDirection = new Vector3(H, 0f, V);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= moveSpeed;

        player_Gravity();
        characterController.Move(moveDirection * Time.deltaTime);

        if (Input.GetMouseButton(0) && canShoot)
        {
            FireBullet();
            StartCoroutine(ShootCooltime());
        }

        float rotationInput = Input.GetAxis("Mouse X");
        transform.Rotate(Vector3.up, rotationInput * turnSpeed * Time.deltaTime);


        //if (H == 0 && V == 0) m_animator.SetBool("Idle", false);
        //else m_animator.SetBool("Idle",true);

        m_animator.SetFloat("moveX", H);
        m_animator.SetFloat("moveZ", V);

        //bool isWalking = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D);
        //m_animator.SetBool("Walking", isWalking);

        //bool isShooting = Input.GetMouseButton(0);
        //m_animator.SetBool("Shoot", isShooting);
    }
    IEnumerator ShootCooltime()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootInterval);
        canShoot = true;
    }

void player_Gravity()
{
    if (!characterController.isGrounded)
    {
        moveDirection.y -= gravity ;
       
    }
}

    void FireBullet()
    {
        GameObject bulletObject = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);


        Destroy(bulletObject, 2.0f);
    }
}


