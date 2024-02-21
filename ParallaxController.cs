using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    private Transform camera;
    private Vector3 cameraStartPos;
    private float distance;
    private GameObject[] backgrounds;
    private Material[] materials;
    private float[] backSpeed;
    private float farthestBack;
    [Range(0.01f, 0.05f)] public float parallaxSpeed;

    private void Start()
    {
        camera = Camera.main.transform;
        cameraStartPos = camera.position;
        int backCount = transform.childCount;
        materials = new Material[backCount];
        backSpeed = new float[backCount];
        backgrounds = new GameObject[backCount];
        for (int i = 0; i < backCount; i++)
        {
            backgrounds[i] = transform.GetChild(i).gameObject;
            materials[i] = backgrounds[i].GetComponent<Renderer>().material;
        }
        BackSpeedCalculate(backCount);
    }

    void BackSpeedCalculate(int backCount)
    {
        for (int i = 0; i < backCount; i++)
        {
            if ((backgrounds[i].transform.position.z - camera.position.z) > farthestBack)
            {
                farthestBack = backgrounds[i].transform.position.z - camera.position.z;
            }
        }

        for (int i = 0; i < backCount; i++)
        {
            backSpeed[i] = 1 - (backgrounds[i].transform.position.z - camera.position.z) / farthestBack;
        }
    }

    private void LateUpdate()
    {
        distance = camera.position.x - cameraStartPos.x;
        transform.position = new Vector3(camera.position.x, transform.position.y, 0);
        for (int i = 0; i < backgrounds.Length; i++)
        {
            float speed = backSpeed[i] * parallaxSpeed;
            materials[i].SetTextureOffset("_MainTex", new Vector2(distance, 0) * speed);
        }
    }
}