using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Written by Andrew Berry

public class AndrewPlayerController : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public int rotSpeed;
    public Camera thirdperson;
    public bool inCover = false;
    public AudioSource munch, alert, damage, death;
    private AB_StatsManager stats;
    private Vector3 returnTo;
    private Quaternion begRotation;
    private bool horizontal = false;
    private string direction;
    private Animator anim;
    public Material myShader = null;

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<AB_StatsManager>();
        returnTo = transform.position;
        begRotation = transform.rotation;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
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

        if (!horizontal)
        {
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
    }

    public void ToggleHoriz(bool h)
    {
        horizontal = h;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("NextLevelTrigger"))
        {
            stats.Victory();
        }

        if(other.CompareTag("Good Crumb"))
        {
            stats.CrumbGet();
            munch.Play();
        }

        else if(other.CompareTag("Bad Crumb"))
        {
            stats.MoldyCrumbGet();
            munch.Play();
        }

        if (other.CompareTag("Shadow"))
        {
            inCover = true;
            IsEscaping();
        }

        if (other.CompareTag("CameraTrigger"))
        {
            if(transform.position.z <= other.transform.position.z)
            {
                direction = "forwards";
                IsEscaping();
            }
            else
            {
                direction = "backwards";
                IsNotEscaping();
            }
            thirdperson.GetComponent<AndrewCameraMover>().Move(direction);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Shadow"))
        {
            inCover = false;
        }

        if (other.CompareTag("CameraTrigger"))
        {
            if (direction == "forwards" && transform.position.z <= other.transform.position.z)
            {
                direction = "backwards";
                IsNotEscaping();
            }
            else if(direction == "backwards" && transform.position.z >= other.transform.position.z)
            {
                direction = "forwards";
                IsEscaping();
            }
            thirdperson.GetComponent<AndrewCameraMover>().Move(direction);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Human"))
        {
            if (stats.health > 20)
                damage.Play();
            else
            {
                death.Play();
                GameObject.Find("BGM").GetComponent<AudioSource>().Stop();
                Time.timeScale = 0;
            }
            GetComponent<Rigidbody>().freezeRotation = true;
            stats.GetHurt();
            transform.position = returnTo;
            transform.rotation = begRotation;
            GetComponent<Rigidbody>().freezeRotation = false;
        }
    }

    private void IsEscaping()
    {
        myShader.DisableKeyword("_EMISSION");
    }

    public void IsNotEscaping()
    {
        alert.Play();
        myShader.EnableKeyword("_EMISSION");
    }
}
