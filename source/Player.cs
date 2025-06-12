using Godot;
using System.Collections.Generic;

public partial class Player : Area2D
{
	[Export]
	private float _speed = 15.0f;
	[Export]
	private int _hitpoints = 5;
	public int Hitpoints { get { return _hitpoints; } }

	[Export]
	private ShaderMaterial _shaderMaterial;

	private Vector2 _currentVelocity = Vector2.Zero;

	private Sprite2D _sprite;


	public override void _Ready()
	{
		_sprite = GetNode<Sprite2D>("Sprite2D");

		// Remove the shadermaterial from the sprite in the Godot editor.
		// Then, uncomment the two lines below. This will set the shader manually from code after 1.5 seconds.

		//Modulate = Colors.Transparent;
		//InitializeShader();
	}

	public override void _PhysicsProcess(double delta)
	{
		UpdatePosition(delta);
	}

	private void UpdatePosition(double delta)
	{
		Rect2 allowedArea = GetViewportRect();
		Vector2 mousePos = GetViewport().GetMousePosition();
		mousePos = mousePos.Clamp(allowedArea.Position, allowedArea.Size);
		Vector2 diff = mousePos - Position;
		_currentVelocity = diff * _speed;
		Position += _currentVelocity * (float)delta;
	}


	public void _OnBodyEntered(Node2D body)
	{
	}

	private async void InitializeShader()
	{
		_sprite.Material = _shaderMaterial;
		UpdateDamageShader();

		await ToSignal(GetTree().CreateTimer(1.5f), SceneTreeTimer.SignalName.Timeout);

		// So... the moment the sprite's shader becomes visible, the glitch happens. Even if it's 1.5 seconds after the shader was set...
		Tween tween = CreateTween();
		tween.TweenProperty(this, "modulate", Colors.White, 1);
	}

	private void UpdateDamageShader()
	{
		ShaderMaterial shaderMat = (ShaderMaterial)_sprite.Material;
		if (shaderMat == null)
		{
			GD.PrintErr("Missing shader material");
			return;
		}
		float pulseSpeed;
		if (_hitpoints <= 1)
		{
			pulseSpeed = 15;
		}
		else if (_hitpoints <= 2)
		{
			pulseSpeed = 8;
		}
		else
		{
			pulseSpeed = 3;
		}
		shaderMat.SetShaderParameter("pulse_speed", pulseSpeed);
	}
}
