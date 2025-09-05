namespace ADOScripter;

public class Helper
{
    public bool boolHelper(string germanBool)
    {
        if (germanBool.ToLower() == "ja")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool crossToBoolHelper(string cross)
    {
        if (cross.ToLower() == "x")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
