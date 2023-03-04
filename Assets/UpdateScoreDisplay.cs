using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Netcode;
using UnityEngine;

public class UpdateScoreDisplay : NetworkBehaviour
{
    private int displayedScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var currentScore = GameStats.Score.Value;
        Debug.Log($"{OwnerClientId} {currentScore}");
        if (currentScore != displayedScore)
        {
            displayedScore = currentScore;
            GetComponent<TextMeshProUGUI>().text = $"Score: {displayedScore}";
        }
    }
}
