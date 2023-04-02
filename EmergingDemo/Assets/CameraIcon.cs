using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraIcon : MonoBehaviour
{
    public Image image;
    public Sprite newimage;
    public Sprite oldimage;
    private bool Spritebool;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changeImage()
    {
        if (Spritebool)
        {
            Spritebool = false;
            image.sprite = newimage;
        }
        else if (Spritebool == false)
        {
            Spritebool = true;
            image.sprite = oldimage;
        }
    }
}