using System;
using System.Runtime.InteropServices;

namespace SDL2Net.Internal
{
    [Flags]
    public enum SDL_WindowFlags : uint
    {
        SDL_WINDOW_FULLSCREEN = 0x00000001,

        /**< fullscreen window */
        SDL_WINDOW_OPENGL = 0x00000002,

        /**< window usable with OpenGL context */
        SDL_WINDOW_SHOWN = 0x00000004,

        /**< window is visible */
        SDL_WINDOW_HIDDEN = 0x00000008,

        /**< window is not visible */
        SDL_WINDOW_BORDERLESS = 0x00000010,

        /**< no window decoration */
        SDL_WINDOW_RESIZABLE = 0x00000020,

        /**< window can be resized */
        SDL_WINDOW_MINIMIZED = 0x00000040,

        /**< window is minimized */
        SDL_WINDOW_MAXIMIZED = 0x00000080,

        /**< window is maximized */
        SDL_WINDOW_INPUT_GRABBED = 0x00000100,

        /**< window has grabbed input focus */
        SDL_WINDOW_INPUT_FOCUS = 0x00000200,

        /**< window has input focus */
        SDL_WINDOW_MOUSE_FOCUS = 0x00000400,

        /**< window has mouse focus */
        SDL_WINDOW_FULLSCREEN_DESKTOP = (SDL_WINDOW_FULLSCREEN | 0x00001000),
        SDL_WINDOW_FOREIGN = 0x00000800,

        /**< window not created by SDL */
        SDL_WINDOW_ALLOW_HIGHDPI = 0x00002000,

        /**< window should be created in high-DPI mode if supported.
                                                     On macOS NSHighResolutionCapable must be set true in the
                                                     application's Info.plist for this to have any effect. */
        SDL_WINDOW_MOUSE_CAPTURE = 0x00004000,

        /**< window has mouse captured (unrelated to INPUT_GRABBED) */
        SDL_WINDOW_ALWAYS_ON_TOP = 0x00008000,

        /**< window should always be above others */
        SDL_WINDOW_SKIP_TASKBAR = 0x00010000,

        /**< window should not be added to the taskbar */
        SDL_WINDOW_UTILITY = 0x00020000,

        /**< window should be treated as a utility window */
        SDL_WINDOW_TOOLTIP = 0x00040000,

        /**< window should be treated as a tooltip */
        SDL_WINDOW_POPUP_MENU = 0x00080000,

        /**< window should be treated as a popup menu */
        SDL_WINDOW_VULKAN = 0x10000000 /**< window usable for Vulkan surface */
    }

    [Flags]
    public enum SDL_MessageBoxFlags : uint
    {
        SDL_MESSAGEBOX_ERROR = 0x00000010,

        /**< error dialog */
        SDL_MESSAGEBOX_WARNING = 0x00000020,

        /**< warning dialog */
        SDL_MESSAGEBOX_INFORMATION = 0x00000040,

        /**< informational dialog */
        SDL_MESSAGEBOX_BUTTONS_LEFT_TO_RIGHT = 0x00000080,

        /**< buttons placed left to right */
        SDL_MESSAGEBOX_BUTTONS_RIGHT_TO_LEFT = 0x00000100 /**< buttons placed right to left */
    }

    public static partial class SDL
    {
        [DllImport(SDL2Lib, CharSet = CharSet.Ansi)]
        public static extern IntPtr SDL_CreateWindow(string title, int x, int y, int w, int h, SDL_WindowFlags flags);

        [DllImport(SDL2Lib)]
        public static extern void SDL_DestroyWindow(IntPtr window);

        [DllImport(SDL2Lib)]
        public static extern void SDL_ShowWindow(IntPtr window);

        [DllImport(SDL2Lib)]
        public static extern void SDL_HideWindow(IntPtr window);

        [DllImport(SDL2Lib)]
        public static extern IntPtr SDL_GetWindowTitle(IntPtr window);
        
        [DllImport(SDL2Lib, CharSet = CharSet.Ansi)]
        public static extern void SDL_SetWindowTitle(IntPtr window, string title);

        [DllImport(SDL2Lib, CharSet = CharSet.Ansi)]
        public static extern int SDL_ShowSimpleMessageBox(SDL_MessageBoxFlags flags, string title, string message, IntPtr window);
    }
}