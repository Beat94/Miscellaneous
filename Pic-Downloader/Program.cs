namespace picDownloader;

public class Program
{
    public static void Main()
    {
        Runner run = new();
        run.savepath = ""; // Path of file including linklist
        run.datapath = ""; // Path of savinglocation
        run.cookie = "";

        run.running();
    }
}