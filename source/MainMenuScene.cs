using Godot;

public partial class MainMenuScene : Control
{
	[Export]
	private PackedScene _gameScene;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnStartGameButtonPressed()
	{
		GetTree().ChangeSceneToPacked(_gameScene);
		//GameManager.Instance.StartGame();
	}
}
