using ZeroElectric.Vinculum;

namespace Yoga.Tests.Visual; 

public static class Program {
    public static IScene[] Scenes = {
        new TestLayout()
    };

    public static IScene ActiveScene => Scenes[ActiveIndex];
    public static int ActiveIndex = 0;

    public static void Main() {
        Raylib.InitWindow(1280, 720, "Yoga Tests");
        ActiveScene.Init();
        while (!Raylib.WindowShouldClose()) {
            CycleScenes();
            
            ActiveScene.Update();
            
            Raylib.BeginDrawing();
                Raylib.ClearBackground(Raylib.BLACK);
                ActiveScene.Draw();
                var text = 
                    @$"Scene: {ActiveScene.GetType().Name}
FPS: {Raylib.GetFPS()}
Press Right and Left key to cycle available scenes";
                Raylib.DrawText(text,
                    1, 1, 20, Raylib.GRAY);
                Raylib.DrawText(text,
                    0, 0, 20, Raylib.WHITE);
            Raylib.EndDrawing();
        }
    }

    private static void CycleScenes() {
        if ((KeyboardKey)Raylib.GetKeyPressed() == KeyboardKey.KEY_RIGHT)
            ActiveIndex++;
        else if ((KeyboardKey)Raylib.GetKeyPressed() == KeyboardKey.KEY_RIGHT)
            ActiveIndex--;
        
        if (ActiveIndex >= Scenes.Length)
            ActiveIndex = 0;
        else if (ActiveIndex < 0)
            ActiveIndex = Scenes.Length - 1;
    }
}