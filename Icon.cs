using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour
{
    public int iconID; // ID for the icon
    public float fadeDuration = 0.5f; // Duration for fading out
    private SpriteRenderer spriteRenderer;
    private TrailMakingManager trailMakingManager;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        trailMakingManager = FindObjectOfType<TrailMakingManager>(); // Find the TrailMakingManager in the scene
    }

    private void OnMouseDown()
    {
        if (trailMakingManager != null)
        {
            trailMakingManager.IconClicked(iconID);
            StartCoroutine(FadeOutAndDestroy());
        }
    }

    private IEnumerator FadeOutAndDestroy()
    {
        float elapsedTime = 0f;
        Color originalColor = spriteRenderer.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        // Ensure the sprite is fully transparent
        spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        Destroy(gameObject); // Remove the icon from the scene
    }
}
