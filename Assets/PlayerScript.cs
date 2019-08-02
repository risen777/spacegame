using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour


{
    public float speed;
    public float xMin, xMax, zMin, zMax;
    public float tilt;
    public GameObject shot;
    public Transform gunPosition;

    public float shotDelay;
    public float nextShot;
    // Start is called before the first frame update
    void Start()
    {
       


        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Jump") && Time.time > nextShot)
        {
            nextShot = Time.time + shotDelay;



            Instantiate(shot, gunPosition.position, Quaternion.identity);

        
        }

   float moveHorizontal= Input.GetAxis("Horizontal");
   float moveVertical= Input.GetAxis("Vertical");
     Rigidbody Player= GetComponent<Rigidbody>();

        Player.velocity = new Vector3(moveHorizontal, 0, moveVertical)*speed;

     float newX=   Mathf.Clamp(Player.position.x, xMin, xMax);

        float newz = Mathf.Clamp(Player.position.z, zMin, zMax);
        float newY = Player.position.y;
        Player.position = new Vector3(newX, newY, newz);
        Player.rotation = Quaternion.Euler(Player.velocity.z*tilt,0,-Player.velocity.x*tilt);



    }
}
