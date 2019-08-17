﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{
    public GameObject quadGameObject;
    private Renderer quadRenderer;

    public float scrollSpeed = 0.5f;

    void Start()
    {
        quadRenderer = quadGameObject.GetComponent<Renderer>();
    }

    void Update()
    {
        Vector2 textureOffset = new Vector2(Time.time * scrollSpeed, 0);
        quadRenderer.material.mainTextureOffset = textureOffset;
    }
}
