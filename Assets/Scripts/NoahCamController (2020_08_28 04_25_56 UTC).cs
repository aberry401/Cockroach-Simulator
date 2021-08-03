using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//written by Noah Johanson

public class NoahCamController : MonoBehaviour
{
    public GameObject Player;
    private AudioSource BM;
    public AudioClip Music;
    public AudioClip deathSound;

    private void Awake()
    {
        BM = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        BM.clip = Music;
        BM.Play();
        //Ppos = new Vector3(Player.transform.position.x, Player.transform.position.y + 2, Player.transform.position.z - 2);
        //this.gameObject.transform.position = Ppos;
    }

    void Update()
    {
        if(Player.activeSelf == false)
        {
            BM.Stop();
            BM.clip = deathSound;
            BM.Play();
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        this.gameObject.transform.rotation = Player.transform.rotation;
        this.gameObject.transform.position = Player.transform.position;
    }
}
