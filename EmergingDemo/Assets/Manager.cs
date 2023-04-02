using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public TextMeshProUGUI volumeText;  // Reference to the UI text element
    public float increaseAmount = 10f;  // Amount to increase volume by
    private bool isVolumeUp = false;  // Flag to indicate if volume is being increased
    private bool isVolumeDown = false; // Flag to indicate if volume is being decreased

    public Image muteImage;  // Reference to the UI image element
    public Sprite unmutedSprite; // Reference to the sprite to use when unmuted
    public Sprite mutedSprite; // Reference to the sprite to use when muted

    public string data;
    public GameObject udp;

    private UDPReceive server;

    private void Start()
    {
        server = udp.GetComponent<UDPReceive>();
        data = server.data;
    }

    private void Update()
    {
        data = server.data;
        //print("test");

        if (data == "volume up")
        {
            if (!isVolumeUp && !isVolumeDown)
            {  // If volume isn't currently being increased or decreased
                InvokeRepeating("IncreaseVolume", 0f, .4f);  // Start increasing volume every second
                isVolumeUp = true;
            }
        }
        else if (data == "volume down")
        {
            if (!isVolumeDown && !isVolumeUp)
            {  // If volume isn't currently being decreased or increased
                InvokeRepeating("DecreaseVolume", 0f, .4f);  // Start decreasing volume every second
                isVolumeDown = true;
            }
        }
        else
        {
            if (isVolumeUp)
            {  // If volume is currently being increased
                CancelInvoke("IncreaseVolume");  // Stop increasing volume
                isVolumeUp = false;
            }
            if (isVolumeDown)
            {  // If volume is currently being decreased
                CancelInvoke("DecreaseVolume");  // Stop decreasing volume
                isVolumeDown = false;
            }
        }

        if (data == "mute")
        {
            muteImage.sprite = mutedSprite;
        }
        else if (data == "unmute")
        {
            muteImage.sprite = unmutedSprite;
        }
    }

    private void IncreaseVolume()
    {
        int currentVolume = int.Parse(volumeText.text);
        int newVolume = currentVolume + (int)increaseAmount;
        if (newVolume > 100)
        {  // Cap volume at 100
            newVolume = 100;
        }
        volumeText.text = newVolume.ToString();
    }

    private void DecreaseVolume()
    {
        int currentVolume = int.Parse(volumeText.text);
        int newVolume = currentVolume - 10;
        if (newVolume < 0)
        {
            newVolume = 0;
        }
        volumeText.text = newVolume.ToString();
    }
}