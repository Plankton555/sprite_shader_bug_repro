extends Control

@export var game_scene : PackedScene

func OnStartGameButtonPressed():
	get_tree().change_scene_to_packed(game_scene)
