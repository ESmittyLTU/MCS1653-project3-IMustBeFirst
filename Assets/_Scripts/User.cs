using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    
    public bool[] tags;


    //Face info
    public Sprite[] faces, angryFaces;
    private int selectedFace = Random.Range(0, 10);
    private SpriteRenderer face;

    //Color info
    public Material[] colors;
    public Material redRing;
    public Material greenRing;
    private Material facering;

    // Start is called before the first frame update
    void Start()
    {





        //Get the sprite renderer controlling the face
        face = transform.GetChild(0).GetComponent<SpriteRenderer>();

        //Set color of bg
        transform.GetChild(1).GetComponent<Renderer>().material = colors[Random.Range(0, 10)];

        //Get material component for face ring
        facering = transform.GetChild(2).GetComponent<Material>();

        //Set the face
        setFace();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setFace(bool angry = false)
    {
        if (angry)
        {
            face.sprite = angryFaces[selectedFace];
            facering = redRing;
        }
        else
        {
            face.sprite = faces[selectedFace];
            facering = greenRing;
        }
    }
}
