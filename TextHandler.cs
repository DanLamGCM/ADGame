using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextHandler : MonoBehaviour
{

    public TMP_Text dialougeText;
    public Canvas textCanvas;
    public Transform playerTransform;
    private Transform myTransform;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = GetComponent<Transform>();
        textCanvas.transform.position = myTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        textCanvas.transform.LookAt(playerTransform);
        textCanvas.transform.Rotate(0,180,0);
        textCanvas.transform.position = myTransform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            dialougeText.text = "Fuck you";
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            dialougeText.text = "Hi Come Closer";
        }
    }
}
