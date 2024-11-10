public class GameEventSystem 
{
    public delegate void Game_Sequence(Utill_Eum.GameSequence Gamesequence);
    public static Game_Sequence Game_Sequence_Event = delegate { };
    public static void Send_GameSequence(Utill_Eum.GameSequence Gamesequence)
    {
        Game_Sequence_Event.Invoke(Gamesequence);
    }
}
