using Godot;

public partial class MainMenuScene : Control
{
	[Export]
	private PackedScene _gameScene;

	public void OnStartGameButtonPressed()
	{
		GetTree().ChangeSceneToPacked(_gameScene);
	}
}
