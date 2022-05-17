using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement2 : MonoBehaviour
{
    public GameObject character;
    public float speed = 5f;
    public Rigidbody rb;
    public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = character.GetComponent<Rigidbody>();
        character.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if(timer >= 96)
        {
            character.SetActive(true);
            rb.velocity = new Vector3(0,0,-50)*speed;
            rb.drag = 100;
        }
    }
}
