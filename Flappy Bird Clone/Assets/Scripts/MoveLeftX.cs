using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftX : MonoBehaviour
{
    [SerializeField] private float speed;
    private float leftBound = -15;

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
