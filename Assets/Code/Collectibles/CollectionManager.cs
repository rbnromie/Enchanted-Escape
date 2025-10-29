using UnityEngine;
using TMPro;

public class CollectionManager : MonoBehaviour
{
    public TextMeshProUGUI gemGUI;
    int numsGemsCollected = 0;

    

    private void OnEnable()
    {
        Gem.OnGemCollected += GemCollected;
    }

    private void OnDisable()
    {
        Gem.OnGemCollected -= GemCollected;
    }


    private void GemCollected()
    {
        numsGemsCollected++;
        gemGUI.text = numsGemsCollected.ToString();
    }
} 
