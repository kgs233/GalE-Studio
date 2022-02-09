using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace GalE_Core
{
    public class GameForm : InterfaceForm
    {
        public int xPx, yPx;
        //构造函数，生成窗口
        public GameForm(int xPx, int yPx, string name)
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new Vector2i(xPx, yPx),
                Title = name,
            };
            using (ClassOpenTK window = new ClassOpenTK(GameWindowSettings.Default, nativeWindowSettings))
            {
                window.Run();
            }
        }
        //返回窗口的大小
        public int[] GetSize()
        {
            return new int[] {xPx,yPx};
        }
    }
}
