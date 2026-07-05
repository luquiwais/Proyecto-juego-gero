using UnityEngine;
using UnityEngine.UI;

public class StarBar : MonoBehaviour
{
    public Sprite starEmpty;
    public Sprite starFull;

    public Image[] stars;

    void EnsureStars()
    {
        if (stars == null || stars.Length == 0)
            stars = GetComponentsInChildren<Image>(true);
    }

    public void LlenarEstrellas()
    {
        EnsureStars();
        foreach (var star in stars)
            star.sprite = starFull;
    }

    public void VaciarEstrellas()
    {
        EnsureStars();
        foreach (var star in stars)
            star.sprite = starEmpty;
    }
}