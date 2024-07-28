using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Icon : MonoBehaviour
{
    public int iconID; // ID for the icon
    public float fadeDuration = 0.5f; // Duration for fading out
    private SpriteRenderer spriteRenderer;
    public TrailMakingManager manager; // Reference to the TrailMakingManager

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Remove the line that finds the manager, as we will assign it directly
    }

    private void OnMouseDown()
    {
        if (manager != null)
        {
            manager.IconClicked(iconID);
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
