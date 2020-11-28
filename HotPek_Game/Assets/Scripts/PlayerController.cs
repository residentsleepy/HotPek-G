using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//
//  control principal del jugador
//  siempre el jugador avanzara a adelante, utilizando la camara como referencia 
//
//
public class PlayerController : MonoBehaviour
{
    //El jugador siempre avanzara a adelante con respecto a la ubicacion de la camara.
    //Necesitamos el objeto camara para saber a donde esta apuntando
    public Transform cam;
    public float speed = 6f;
    Rigidbody rb;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    private void Start()
    {
        //Ubicamos el RigidBody del personaje para poder accesar a el mas fácil.
        rb = gameObject.GetComponent<Rigidbody>();
    }
  
    // Update is called once per frame
    void FixedUpdate()
    {
        //leemos las entradas del jugador.
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //las guadarmos en un vector 3 para poder usarlas mas adelante
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        //verificamos si esta en moviendo el control, y entramos al ciclo
        if (direction.magnitude >= 0.1f)
        {
            //Obtenemos los grados que giro el control para posicionar a nuestro jugador de frente 
            float targetAngle = Mathf.Atan2(direction.x, direction.z)* Mathf.Rad2Deg + cam.eulerAngles.y;
            //Hacemos que el giro sea suave y no salte de frame a frame.
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);

            //giramos a nuestro personaje para que siempre "viendo a dalante" 
            transform.localRotation = Quaternion.Euler(0f,angle,0f);
            //Anhadimos la fuerza de movimiento.
            rb.AddForce(transform.forward * speed);
          
            
        }
    }
}
