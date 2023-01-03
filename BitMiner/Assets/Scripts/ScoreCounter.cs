using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour
{
    public delegate void ScoreChangedDelegate(int newScore, int oldScore);
    public event ScoreChangedDelegate OnScoreChanged;

    private int score;
    public int Score 
    { 
        get { return score; } 
    }

    public static ScoreCounter Instance { get; private set; }
    
    private void Awake() 
    {  
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        } 
    }

    public void AddScore(int value)
    {
        int oldScore = score;
        score += value;
        OnScoreChanged?.Invoke(score, oldScore);
    }
}
