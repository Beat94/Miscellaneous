using System.Runtime.InteropServices;

namespace MouseWiggler;
internal class Mouse
{
    [DllImport("user32.dll")]
    internal static extern bool GetCursorPos(out POINT lpPoint);

    [DllImport("user32.dll")]
    internal static extern bool SetCursorPos(int x, int y);

    internal static (int x, int y) GetMousePosition()
    {
        POINT point;
        if (GetCursorPos(out point))
        {
            return (point.X, point.Y);
        }
        else
        {
            throw new System.ComponentModel.Win32Exception(Marshal.GetLastWin32Error());
        }
    }

    internal struct POINT
    {
        public int X;
        public int Y;
        public POINT(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
