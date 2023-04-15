using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvents
{
    public static event Action onGameCompleted;
    public static void GameCompleted() => onGameCompleted?.Invoke();

    public static event Action onGameFault;
    public static void GameFault() => onGameFault?.Invoke();
}
