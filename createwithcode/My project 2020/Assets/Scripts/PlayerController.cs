using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //gaming
    private float speed = 5.0f;
    private float turnSpeed = 60.0f;
    private float horizontalInput;
    private float forwardInput;

    // Start is called before the first frame update
    void Start()
    {
        //bruh i dun got teh minecraft gone :sob: i am literally crying and shaking and crying and like wtf now i need to set up a proxy to get around this
        //which is going to be annoying im literally going to be bored as shit the entire FUCKING PERIOD OH MY GOD WHY ms hansen i am going to kill
        //you you litearlly RUINED minecraft FOR AN ENTIER PERIOD! I CANT EVEN FUCKKKING GET AROUND IT SINCE I CANT SET UP A PROXY ON MY FONE
        //WHY DID YOU DO THIS MIS HANSIN WHY DO U THINK BLOCKING MINE CRAF T WILL STOP ME>>>>???????? i am more pwoerful than you can possibry 
        //imagine you dont even KNOW like what thed fuck wer you thinking i am litearlly the smartest human being alive and am better then 
        //everyone else fr and you just DELETE MY FUCKING MINECRAFT?! FUCK YOU FUCK YOU FUCK YOU I HATE YOU!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        //now i have to listen to this dumb ass bitch asian say a bunch of dumb shit i dont care anbout i want to jill him too!! i am sucha  
        //gangster 
    }

    // Update is called once per frame
    void Update()
    {
        //this is where you play video gamnes crazy
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        
        // we wont move the vehicle ever it will take too long i will literally collapse and die before i can ever do anything in this class
        // nvm!!!
        // this is literally so crazyyyyyyyyyyyyyyyyy it like MOVE WTF
        // transform.Translate(0, 0, 1);
        //vehicle go croom veoom here CRAZY
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        //veuhile go turny
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
    }
}
