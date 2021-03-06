﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

    public bool scrolling, paralax;

    public float backroundSize;

    public float paralaxSpeed;

    private Transform camerTransform;
    private Transform[] layers;
    private float viewZone = 10;
    private int leftIndex;
    private int rightIndex;

    private float lastCameraX;




    // Use this for initialization
    private void Start () {

        camerTransform = Camera.main.transform;
        lastCameraX = camerTransform.position.x;


        layers = new Transform[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
            layers[i] = transform.GetChild(i);
        
        leftIndex = 0;
        rightIndex = layers.Length-1;
	}

   
    private void Update()
    {
        if (paralax)
        {
            float deltaX = camerTransform.position.x - lastCameraX;
            transform.position += Vector3.right * (deltaX * paralaxSpeed);
        }

        lastCameraX = camerTransform.position.x;

        if (scrolling) { 
            if (Input.GetKeyDown(KeyCode.A))
                ScrollLeft();

            if (Input.GetKeyDown(KeyCode.D))
                ScrollRigth();
        }
       /* if (camerTransform.position.x < layers[leftIndex].transform.position.x + viewZone)
            ScrollLeft();
        if (camerTransform.position.x < layers[leftIndex].transform.position.x + viewZone)
            ScrollRigth();
        */

    }

    private void ScrollLeft()
    {
        int lastRight = rightIndex;
        layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - backroundSize);
        leftIndex = rightIndex;
        rightIndex--;
        if(rightIndex <0)
        
            rightIndex = layers.Length - 1;
        
    }

    private void ScrollRigth()
    {
        int lastLeft = leftIndex;
        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + backroundSize);
        rightIndex = leftIndex;
        leftIndex++;
        if (leftIndex == layers.Length)
        leftIndex = 0;
        
    }

}

