 public class Condition
{
    public bool IsCondition1 { get; set; }
    public bool IsCondition2 { get; set; }
    public bool IsCondition3 { get; set; }
    public bool IsCondition4 { get; set; }

    public bool ShouldAccept()
    {
        if (!IsCondition1)
        {
            return false;
        }
        if (!IsCondition2)
        {
            return false;
        }
        if (!IsCondition3)
        {
            return true;
        }
        if (!IsCondition4)
        {
            return false;
        }
        return true;
    }
    
    // can be refactored using pattern matching as

    public bool ShouldAccept()
    {
           return (IsCondition1, IsCondition2, IsCondition3, IsCondition4) switch
          {
            (false, _,     _,     _    ) => false,
            (true,  false, _,     _    ) => false,
            (true,  true,  false, _    ) => true,
            (true,  true,  true,  false) => false,
            (true,  true,  true,  true ) => true
          };
    }
}

