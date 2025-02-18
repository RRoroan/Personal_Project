using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlayerController player {  get; private set; }
    public FollowCamera _camera {  get; private set; }

    private void Awake()
    {
        player = FindAnyObjectByType<PlayerController>();
        _camera = FindAnyObjectByType<FollowCamera>();
    }
}
