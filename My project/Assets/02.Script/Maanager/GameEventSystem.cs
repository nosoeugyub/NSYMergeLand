public class GameEventSystem 
{
    public delegate void Game_Sequence(Utill_Eum.GameSequence Gamesequence);
    public static Game_Sequence Game_Sequence_Event = delegate { };
    public static void Send_GameSequence(Utill_Eum.GameSequence Gamesequence)
    {
        Game_Sequence_Event.Invoke(Gamesequence);
    }


    public delegate void AddNpc(int Id);//���ϴ� ID�� Ȥ�� �����Ǿ��ִ� id�� npc �߰��ϸ鼭 ���
    public static AddNpc AddNpc_Event;
    public static void Send_AddNpc(int id)
    {
        if (AddNpc_Event != null)
        {
            AddNpc_Event.Invoke(id);
        }
    }
}
