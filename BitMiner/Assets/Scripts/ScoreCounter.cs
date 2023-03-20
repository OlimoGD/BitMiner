using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour
{
    public delegate void ScoreChangedDelegate(ulong newScore, ulong oldScore);
    public event ScoreChangedDelegate OnScoreChanged;

    private ulong score;
    public ulong Score 
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

    public void AddScore(ulong value)
    {
        ulong oldScore = score;
        score += value;
        OnScoreChanged?.Invoke(score, oldScore);
    }
}
