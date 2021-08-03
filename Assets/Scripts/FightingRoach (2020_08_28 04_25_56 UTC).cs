using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightingRoach : MonoBehaviour
{
    public Camera thirdperson;
    public GameObject player;
    public float speed;
    public float rotSpeed;
    private AB_StatsManager stats;
    private Animator anim;

    void Start()
    {
        stats = GetComponent<AB_StatsManager>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        else
        {
            thirdperson.transform.LookAt(player.transform);
            if (Input.GetKey(KeyCode.UpArrow))
            {
                anim.SetBool("Run Forward", true);
                player.transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * speed);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                anim.SetBool("Run Backward", true);
                player.transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * speed);
            }
            else
            {
                anim.SetBool("Run Forward", false);
                anim.SetBool("Run Backward", false);
            }
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("Strafe Right", true);
            player.transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * rotSpeed);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("Strafe Left", true);
            player.transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * rotSpeed);
        }
        else
        {
            anim.SetBool("Strafe Right", false);
            anim.SetBool("Strafe Left", false);
        }

    }


    public void Attack()
    {
        anim.SetTrigger("Stab Attack");

    }
}
