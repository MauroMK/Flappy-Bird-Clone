using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftX : MonoBehaviour
{

    public float speed;
    private float leftBound = -15;

    private PlayerMovement playerMovementScript;

    void Start()
    {
        // Está sendo setado neste script que: a variável playerControllerScript nada mais é do que o PlayerController.cs
        // Ou seja, está fazendo uma referência
    }

    
    void Update()
    {
        // Ou seja, ta pegando o gameOver do Player.cs, e verificando ela
        // Se for verdadeira, toca ficha, se for falso (no caso bater em um obstaculo), ai para

        transform.Translate(Vector3.left * Time.deltaTime * speed * Time.deltaTime);
        

        // Se a posição em X for menor que o leftBound, e a tag do objeto for "Obstacle, exclui ele caso passe dos -15 em X
        if (transform.position.x < leftBound && gameObject.layer == 6)
        {
            Destroy(gameObject);
        }
    }
}
