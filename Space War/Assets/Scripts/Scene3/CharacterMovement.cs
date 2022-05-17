using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CharacterMovement : MonoBehaviour
{
    public Transform target;
    public float currentspeed;
    public ParticleSystem ParticleSystem;
    public ParticleSystem ParticleSystem2;
    public GameObject PS1;
    public GameObject PS2;
    public GameObject spaceship;
    public Transform camerapoint;
    //public GameObject cam;
    //public CinemachineVirtualCamera cinemachine;
    
    public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        //camerafollow = cam.GetComponent<CameraFollow>();
        //cinemachine = gameObject.AddComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        ParticleSystem.Pause();
        ParticleSystem2.Pause();
        if(timer >= 79)
        {
            ParticleSystem.Play();
            ParticleSystem2.Play();
            transform.position = Vector3.MoveTowards(transform.position, target.position,currentspeed);
            if(timer >= 84)
            {
            //cinemachine.Follow = camerapoint;
            //camerafollow.camerapoint = camerapoint;
                spaceship.transform.position += new Vector3(0,0, +1f);
                CloseParticleSystem();
            }
        }
    }
    void CloseParticleSystem()
    {
        if(transform.position == target.transform.position)
        {
            PS1.SetActive(false);
            PS2.SetActive(false);
            spaceship.SetActive(false);
        }
    }
    
}
