using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* handles the spawning of groups without overlap and teleporting trail & spawn effect. */
public class TeleportCharacter : MonoBehaviour
{
    public GameObject charactership;
    public ParticleSystem teleportEffect;
    public GameObject ps;
    public float timeBetweenSpawn = .2f;
    public float spawnEffectScale = 3f;
    public float timer = 0;

    public void Start()
    {
        
    }
    public void Update()
    {
        timer += Time.deltaTime;
        if(timer > 95)
        {
            teleportEffect.Play();

        }
        if(timer > 97.5f)
        {
            charactership.SetActive(true);
        }
        if(timer > 98.5f)
        {
            ps.SetActive(false);
        }
    }
}
