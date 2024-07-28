using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrailMakingManager : MonoBehaviour
{
    public Transform iconsParent; // Reference to IconsParent GameObject
    public GameObject[] iconPrefabs; // Array of icon prefabs
    public int numberOfIcons = 20; // Total number of icons to instantiate
    public GameObject menuPanel; // Reference to the Menu Panel GameObject
    private int clickCount = 0; // Count of total clicks

    private void Start()
    {
        menuPanel.SetActive(false); // Ensure the menu panel is initially inactive
        Debug.Log("Game Started");

        // Instantiate icons
        for (int i = 0; i < numberOfIcons; i++)
        {
            GameObject iconPrefab = iconPrefabs[Random.Range(0, iconPrefabs.Length)];
            GameObject iconInstance = Instantiate(iconPrefab, GetRandomPosition(), Quaternion.identity, iconsParent);

            // Assign a unique ID to each icon
            Icon iconScript = iconInstance.GetComponent<Icon>();
            if (iconScript != null)
            {
                iconScript.iconID = i; // Set an ID for each icon
                iconScript.manager = this; // Assign the manager to the icon
            }
        }
    }

    public void IconClicked(int id)
    {
        Debug.Log("Icon clicked with ID: " + id);

        clickCount++;
        if (clickCount >= numberOfIcons) // Check after incrementing the click count
        {
            // Game finished, show results
            ShowResults();
        }
    }

    private Vector3 GetRandomPosition()
    {
        // Adjust this method to fit your specific map or bounds
        float x = Random.Range(-10f, 10f); // X bounds
        float y = Random.Range(-5f, 5f);  // Y bounds
        return new Vector3(x, y, 0f);
    }

    private void ShowResults()
    {
        // Show the menu panel when the game is finished
        Debug.Log("Game Over! Total clicks: " + clickCount);
        menuPanel.SetActive(true);
    }

    public void RestartGame()
    {
        // Restart the game by reloading the current scene
        Debug.Log("Restarting Game...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
