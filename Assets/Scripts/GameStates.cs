using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStates : MonoBehaviour
{
    public enum GameStatesType
    {
        GamePlaying,
        GameWon,
        GameLost, 
        OnMainMenu,
        OnPauseMenu
    };
}
