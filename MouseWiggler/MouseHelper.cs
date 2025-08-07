namespace MouseWiggler;
internal class MouseHelper
{
    public void equalNullcheck(string? str1, string? str2)
    {
        Func<string, string, string> logic = (string str11, string str21) =>
        {
            return str11 ?? str21;
        };

        Console.WriteLine(logic(str1, str2).Equals("asdf", StringComparison.InvariantCultureIgnoreCase) ? str1 : str2);
    }

    /// <summary>
    /// Moves the mouse cursor back and forth by a small amount in a continuous loop.
    /// </summary>
    /// <remarks>This method runs indefinitely until the process is terminated. It is typically used to
    /// simulate user activity or prevent idle detection by moving the mouse cursor slightly at regular
    /// intervals.</remarks>
    /// <param name="isIntelligent">Indicates whether intelligent movement logic should be applied. If <see langword="true"/>, the movement may
    /// adapt based on additional criteria; otherwise, standard movement is used.</param>
    /// <param name="isDebugMode">Indicates whether debug output should be enabled. If <see langword="true"/>, diagnostic information is written
    /// to the console during execution.</param>
    public void moveMouseslightly(bool isIntelligent, bool isDebugMode)
    {
        Console.WriteLine("Moving mouse slightly...");
        int x = 0, y = 0;

        try
        {
            (x, y) = Mouse.GetMousePosition();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error getting cursor position: " + ex.Message);
            return;
        }

        while (true)
        {
            mouseHelper(x, y, 1, 1, isDebugMode, isIntelligent);

            System.Threading.Thread.Sleep(1000); // Sleep for 1 second

            mouseHelper(x, y, -1, -1, isDebugMode, isIntelligent);

            System.Threading.Thread.Sleep(1000); // Sleep for 1 second
        }
    }

    private void mouseHelper(
        int xMousePos,
        int yMousePos,
        int xShift,
        int yShift,
        bool isDebugMode,
        bool isIntelligent)
    {
        if (isIntelligent)
        {
            IntelliMouseHelper(xShift, yShift, isDebugMode);
        }
        else
        {
            DumbMouseHelper(xShift, yShift, xMousePos, yMousePos, isDebugMode);
        }
    }

    private void DumbMouseHelper(
        int xShift, 
        int yShift, 
        int xMousePos, 
        int yMousePos, 
        bool isDebugMode)
    {
        if (isDebugMode)
        {
            Console.WriteLine($"Mouse position set to: x {xMousePos + xShift}, y {yMousePos + yShift}");
        }

        Mouse.SetCursorPos(xMousePos + xShift, yMousePos + xShift);
    }

    private void IntelliMouseHelper(int setX, int setY, bool isDebugMode)
    {
        int x = 0, y = 0;

        try
        {
            (x, y) = Mouse.GetMousePosition();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error getting cursor position: " + ex.Message);
            return;
        }

        if (isDebugMode)
        {
            Console.WriteLine($"IntelliMouse position set to: x {x}, y {y}");
        }

        Mouse.SetCursorPos(x + setX, y + setY);
    }
}