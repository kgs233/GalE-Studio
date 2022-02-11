using OpenTK.Windowing.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Windowing.Desktop;

namespace GalE_Core
{
        internal class ClassOpenTK : GameWindow
        {
            // A simple constructor to let us set properties like window size, title, FPS, etc. on the window.
            public ClassOpenTK(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
                : base(gameWindowSettings, nativeWindowSettings)
            {
            }

            // This function runs on every update frame.
            protected override void OnUpdateFrame(FrameEventArgs e)
            {
                // Check if the Escape button is currently being pressed.
                if (KeyboardState.IsKeyDown(Keys.Escape))
                {
                    // If it is, close the window.
                    Close();
                }

                base.OnUpdateFrame(e);
            }
        }
}
