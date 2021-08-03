using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Written By Noah Johanson

public class NoahPlayerController : MonoBehaviour
{
    private NoahBezCurve NoahBezCurve;
    private Rigidbody rb;
    public float speed;
    public Camera ThirdPerson;
    public Camera EagleEye;
    public bool camSwap;
    public int rotSpeed;
    private Animator anim;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        NoahBezCurve = new NoahBezCurve();
        rb = GetComponent<Rigidbody>();
        ThirdPerson.gameObject.SetActive(true);
        EagleEye.gameObject.SetActive(false);
        camSwap = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Run Forward", true);
        if (Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetBool("Run Forward", true);
            transform.Translate(0, 0, 1 * speed * Time.deltaTime, Space.Self);
            //anim.SetBool("Run Forward", true);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("Run Forward", true);
            transform.Translate(0, 0, -1 * speed * Time.deltaTime, Space.Self);
            //anim.SetBool("Run Forward", true);
        }
       /* if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(1 * speed * Time.deltaTime, 0, 0, Space.Self);
            //anim.SetBool("Run Forward", true);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-1 * speed * Time.deltaTime, 0, 0, Space.Self);
            //anim.SetBool("Run Forward", true);
        }*/
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * rotSpeed);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * rotSpeed);
        }
        else if(anim.GetBool("Run Forward") == true)
        {
            anim.SetBool("Run Forward", false);
        }

        /*if (Input.GetKeyDown(KeyCode.C))
        {
            camSwap = !camSwap;
        }
        if (camSwap == true)
        {
            ThirdPerson.gameObject.SetActive(false);
            EagleEye.gameObject.SetActive(true);
        }
        else
        {
            ThirdPerson.gameObject.SetActive(true);
            EagleEye.gameObject.SetActive(false);
        }*/
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("ToxicCan"))
        {
            this.gameObject.SetActive(false);
            canvas.SetActive(true);
        }
        if (other.CompareTag("Finish"))
        {
            SceneManager.LoadScene("NJTransition");
        }
        if (other.CompareTag("Human"))
        {
            this.gameObject.SetActive(false);
            canvas.SetActive(true);
        }

    }
}
