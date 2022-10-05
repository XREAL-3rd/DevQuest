using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static GameOver main;

    public Target[] targets;

    private void Awake()
    {
        main = this;
    }

    public bool isGameEnd()
    {
        bool is_game_end = true;
        foreach (Target target in targets)
        {
            if (target != null)
            {
                is_game_end = false;
            }
        }
        return is_game_end;
    }
}
