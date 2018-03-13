using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour {

    public delegate void EventScore(PlayerData player);

    public static EventScore OnScoreUpdated;
}
