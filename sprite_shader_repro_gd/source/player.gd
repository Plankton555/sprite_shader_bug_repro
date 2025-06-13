extends Area2D

@export var speed : float = 15
@export var hitpoints : float = 5

@export var shader_material : ShaderMaterial

var current_velocity : Vector2
var sprite : Sprite2D


func _ready():
	sprite = get_node("Sprite2D")


func _physics_process(delta):
	var allowed_area = get_viewport_rect()
	var mouse_pos = get_viewport().get_mouse_position()
	mouse_pos = mouse_pos.clamp(allowed_area.position, allowed_area.size)
	var diff = mouse_pos - position
	current_velocity = diff * speed
	position += current_velocity * delta
