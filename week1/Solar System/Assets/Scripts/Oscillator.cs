using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Vector3 startingPos;
    // Start is called before the first frame update
    void Start()
    {
        startingPos = GetComponent<Transform>().position;
        //Debug.Log("I'm in start at frame: " + Time.frameCount);
    }

    // Update is called once per frame
    void Update()
    {
        Transform siblingTransform = GetComponent<Transform>();

        float offset = Mathf.Sin(Time.time);
        siblingTransform.position = startingPos + Vector3.right * offset;
        //Debug.Log("I'm in update at frame: " + Time.frameCount);
    }
}
