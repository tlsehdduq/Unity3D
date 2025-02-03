using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private GameObject playerObject;
    private float moveSpeed = 3.0f;
    private int maxHP = 100;
    private int currentHP;
    private bool isDead = false;

    private Animator m_animator;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        gameObject.tag = ("Enemy");
        playerObject = GameObject.Find("Player");

        m_animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (isDead)
            return;

        float dis = Vector3.Distance(transform.position, playerObject.transform.position);
        if (dis < 20)
        {

            m_animator.SetBool("Walking", true);
            Vector3 moveDir = (playerObject.transform.position - transform.position).normalized;
            moveDir.y = 0;

            transform.LookAt(playerObject.transform); 

            transform.rotation = Quaternion.Euler(-90f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        }
        else
        {
            m_animator.SetBool("Walking", false);
            transform.rotation = Quaternion.Euler(-90f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);

        }

    }
    public void TakeDamage(int damage)
    {

        if (isDead)
            return;

        currentHP -= damage;
        if (currentHP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        Destroy(gameObject);
    }
}
