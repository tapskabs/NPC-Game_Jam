using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ImageUpdater : MonoBehaviour
{
    public Image[] images; // Array of images to update
    public Sprite[] newSprites; // Array of new sprites for the images
    public TextMeshProUGUI[] texts; // Array of TextMeshPro texts to update
    public string[] newTexts; // Array of new text strings
    public Button nextButton; // Button to go to the next image
    public Button finishButton; // Button to enable when all images are updated

    private int currentIndex = 0;

    void Start()
    {
        // Ensure the finish button is disabled at the start
        finishButton.gameObject.SetActive(false);

        // Add listener to the next button
        nextButton.onClick.AddListener(UpdateImageAndText);
    }

    void UpdateImageAndText()
    {
        if (currentIndex < images.Length)
        {
            // Update the image sprite
            images[currentIndex].sprite = newSprites[currentIndex];

            // Update the text
            if (currentIndex < texts.Length && currentIndex < newTexts.Length)
            {
                texts[currentIndex].text = newTexts[currentIndex];
            }

            currentIndex++;

            // Check if we've updated all images
            if (currentIndex >= images.Length)
            {
                nextButton.gameObject.SetActive(false); // Disable the next button
                finishButton.gameObject.SetActive(true); // Enable the finish button
            }
        }
    }
}
