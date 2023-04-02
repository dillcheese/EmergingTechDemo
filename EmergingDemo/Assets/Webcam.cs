using UnityEngine;
using UnityEngine.UI;

public class Webcam : MonoBehaviour
{

    public RawImage displayImage;
    public int cameraIndex = 0;
    public int width = 640;
    public int height = 480;
    public int fps = 60;

    private WebCamTexture webcamTexture;
    private Texture2D texture;


    void Start()
    {
        // Get the default webcam device
        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices.Length == 0)
        {
            Debug.LogError("No webcam found!");
            return;
        }
        WebCamDevice device = devices[0];

        // Create a new webcam texture
        webcamTexture = new WebCamTexture(device.name, width, height, fps);

        // Set the webcam texture to the raw image component
        displayImage.texture = webcamTexture;

        // Start the webcam texture
        webcamTexture.Play();

        // Create a new texture for rendering
        texture = new Texture2D(width, height, TextureFormat.RGB24, false);
    }

    void Update()
    {
        // Check if the webcam texture is playing
        if (!webcamTexture.isPlaying)
        {
            return;
        }

        // Update the webcam texture
        webcamTexture.GetPixels().CopyTo(texture.GetPixels(),1);
        texture.Apply();

        // Set the updated texture to the raw image component
        displayImage.texture = texture;
    }

    //void Start()
    //{
    //    WebCamDevice[] devices = WebCamTexture.devices;

    //    if (devices.Length > 0)
    //    {
    //        string deviceName = devices[cameraIndex].name;
    //        webcamTexture = new WebCamTexture(deviceName, width, height, fps);
    //        displayImage.texture = webcamTexture;
    //        webcamTexture.Play();
    //    }
    //}

    //void OnDisable()
    //{
    //    if (webcamTexture != null)
    //    {
    //        webcamTexture.Stop();
    //    }
    //}


}