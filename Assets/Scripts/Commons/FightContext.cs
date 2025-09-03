public class FightContext
{
    private static FightContext _instance;

    public static FightContext Instance {
        get
        {
            _instance ??= new FightContext();
            return _instance;
        }
    }

    public string EnnemyName { get; set; }

    private FightContext()
    {
        
    }
}