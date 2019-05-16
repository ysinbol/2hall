﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectLiner : MonoBehaviour {

    [SerializeField, Range(0, 10)]

    float time = 1;



    [SerializeField]

    Vector3 endPosition;



    //[SerializeField]

    //AnimationCurve curve;


    private float startTime;

    private Vector3 startPosition;



    void OnEnable()

    {

        if (time <= 0)
        {

            transform.position = endPosition;

            enabled = false;

            return;

        }



        startTime = Time.timeSinceLevelLoad;

        startPosition = transform.position;

    }



    void Update()

    {

        int dest = (int)Time.deltaTime;

        var diff = Time.timeSinceLevelLoad - startTime;

        if (diff > time)
        {

            transform.position = endPosition;

            enabled = false;

        }



        var rate = diff / time;

        //var pos = curve.Evaluate(rate);



        transform.position = Vector3.Lerp(startPosition, endPosition, rate);

        //transform.position = Vector3.Lerp (startPosition, endPosition, pos);

        if (transform.position == endPosition && dest <= 3)
        {
            Destroy(gameObject);
        }

        if (dest <= 3.5)
        {
            dest = 0;
        }


    }



    void OnDrawGizmosSelected()

    {

#if UNITY_EDITOR



        if (!UnityEditor.EditorApplication.isPlaying || enabled == false)
        {

            startPosition = transform.position;

        }



        UnityEditor.Handles.Label(endPosition, endPosition.ToString());

        UnityEditor.Handles.Label(startPosition, startPosition.ToString());

#endif

        Gizmos.DrawSphere(endPosition, 0.1f);

        Gizmos.DrawSphere(startPosition, 0.1f);



        Gizmos.DrawLine(startPosition, endPosition);

    }
}
