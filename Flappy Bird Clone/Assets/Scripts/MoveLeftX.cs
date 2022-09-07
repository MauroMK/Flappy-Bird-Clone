using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftX : MonoBehaviour
{

    public float speed;
    private float leftBound = -15;

    void Start()
    {
        // Está sendo setado neste script que: a variável playerControllerScript nada mais é do que o PlayerController.cs
        // Ou seja, está fazendo uma referência
    }

    
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
        
        // Se a posição em X for menor que o leftBound, e a tag do objeto for "Tube", exclui ele caso passe dos -15 em X
        if (transform.position.x < leftBound && gameObject.tag == "Tube")
        {
            Destroy(gameObject);
        }
    }
}
