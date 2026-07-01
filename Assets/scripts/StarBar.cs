using UnityEngine;
using UnityEngine.UI;

public class StarBar : MonoBehaviour
{
    public Sprite starEmpty;
    public Sprite starFull;

    public Image[] stars;

    void Start()
    {
        stars = GetComponentsInChildren<Image>();
    }

    public void LlenarEstrellas()
    {
        foreach (var star in stars)
            star.sprite = starFull;
    }

    public void VaciarEstrellas()
    {
        foreach (var star in stars)
            star.sprite = starEmpty;
    }
}