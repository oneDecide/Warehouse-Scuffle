using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int score;
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    public void GainScore()
    {
        score++;
    }

    public int GetScore()
    {
        return score;
    }
}
