using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //private Camera _camera;
    public Transform FollowObject; //El objeto al que sigue la camara 
    public Vector2 FollowOffset; // La distancia en la que el personaje se puede mover hasta que la camara se mueve 
    public float FollowSpeed;
    private Vector2 Threshold; // Crea los limites de la camara 
    private Rigidbody2D RB;

    void Start()
    {
        Threshold = CalculateThreshold();
        //_camera = GetComponent<Camera>();
        RB = FollowObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (!hitWall)
        {
            Vector3 position = new Vector3(FollowObject.position.x, transform.position.y, transform.position.z);
            //Solamente sigue la posicion del personaje en el eje X
            transform.position = position;
        }
    }
    private Vector3 CalculateThreshold() // Calcula el tama�o del Threshold 
    {
        Rect aspect = Camera.main.pixelRect;
        Vector2 t = new Vector2(Camera.main.orthographicSize * aspect.width/ aspect.height, Camera.main.orthographicSize); // Sacar las dimensiones de la camara
        t.y -= FollowOffset.y;
        return t;
    }

    private void OnDrawGizmos() //Dibujar un Gizmo para mostrar el tama�o del Threshold 
    {
        Gizmos.color = Color.red;
        Vector2 border = CalculateThreshold();
        Gizmos.DrawWireCube(transform.position, new Vector3(border.x * 2, border.y * 2, 1));
    }

    private void FixedUpdate()
    {
        Vector2 follow = FollowObject.transform.position; // la posicion del jugador en cada frame 
        float YDifference = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * follow.y); // Mantiene un resgrito de la posicion del jugador en el eje Y

        Vector3 newPosition = transform.position;
        if(Mathf.Abs(YDifference) >= Threshold.y) //Si la diferencia en el eje Y es mayor o igual al tama�o del Threshold 
                                                  //Mathf.Abs para que el valor obtenida siempre sea positivo
        { 
            newPosition.y = follow.y;
        }
        float moveSpeed = RB.velocity.magnitude > FollowSpeed ? RB.velocity.magnitude : FollowSpeed;
               // un valor de float que es igual al valor maximo de velocidad 
        //transform.position = newPosition;
        transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);
    }
}
