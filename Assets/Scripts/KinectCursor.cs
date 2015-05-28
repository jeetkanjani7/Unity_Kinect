﻿using UnityEngine;
using System.Collections;

public class KinectCursor : MonoBehaviour
{
    public float easing = 0.03f;

    private Transform tr;

	// Use this for initialization
	void Start ()
    {
        // get local component
        tr = GetComponent<Transform>();
	}

    // Update is called once per frame
    void Update()
    {
        if (BodySourceView.bodyTracked)
        {
            // fetch hand positions
            Vector3 hLeft = BodySourceView.jointObjs[7].position;

            // easing towards X
            float targetX = hLeft.x;
            float posX = tr.position.x;
            float dx = targetX - posX;
            if (Mathf.Abs(dx) > 1)
            {
                posX += dx * easing;
            }

            // easing towards Y
            float targetY = hLeft.y;
            float posY = tr.position.y;
            float dy = targetY - posY;
            if (Mathf.Abs(dy) > 1)
            {
                posY += dy * easing;
            }

            // update cursor position with new 
            tr.position = new Vector3(posX, posY, tr.position.z);
        }
    }
}
