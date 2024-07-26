using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailMakingManager : MonoBehaviour
{
    public Transform iconsParent; // Reference to IconsParent GameObject
    public GameObject[] iconPrefabs; // Array of icon prefabs
    public int numberOfIcons = 8; // Total number of icons to instantiate
    private List<int> correctOrder = new List<int>(); // Order of icons to click
    private int currentIndex = 0; // Index of the current correct icon
    private int errors = 0; // Count of errors

    private void Start()
    {
        // Instantiate icons
        for (int i = 0; i < numberOfIcons; i++)
        {
            GameObject iconPrefab = iconPrefabs[Random.Range(0, iconPrefabs.Length)];
            GameObject iconInstance = Instantiate(iconPrefab, GetRandomPosition(), Quaternion.identity, iconsParent);
            
            // Assign a unique ID to each icon (you need to set IDs in the prefabs)
            Icon iconScript = iconInstance.GetComponent<Icon>();
            if (iconScript != null)
            {
                iconScript.iconID = i; // Set an ID for each icon (change as needed)
                correctOrder.Add(iconScript.iconID); // Add to the correct order list
            }
        }
    }

    public void IconClicked(int id)
    {
        if (id == correctOrder[currentIndex])
        {
            currentIndex++;
            if (currentIndex >= correctOrder.Count)
            {
                // Game finished, show results
                ShowResults();
            }
        }
        else
        {
            errors++;
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
        // Implement the logic to show results, e.g., UI popup
        Debug.Log("Game Over! Errors: " + errors);
    }
}
