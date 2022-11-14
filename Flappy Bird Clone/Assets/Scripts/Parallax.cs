using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float animSpeed = 1f;
    
    private MeshRenderer meshRender;

    void Awake()
    {
        meshRender = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        meshRender.material.mainTextureOffset += new Vector2(animSpeed * Time.deltaTime, 0);
    }
}
