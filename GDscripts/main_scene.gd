extends Node2D

var mpalakia=0
@export var label:Label

# Called when the node enters the scene tree for the first time.
func _ready():
	_update_label()


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	if mpalakia==300:
		print("win")
		get_tree().change_scene_to_file("res://Scenes/Victory.tscn")

func _on_solinas_deksia_pressed():
	$Area2D.rotation_degrees-= 10


func _on_solinas_mesi_pressed():
	$Area2D2.rotation_degrees-= 10


func _on_solinas_aristera_pressed():
	$Area2D3.rotation_degrees-= 10


func _on_thanatos_body_entered(body):
	print("xasame") # Αυτό θα σε στέλνει στο you loose
	get_tree().change_scene_to_file("res://Scenes/defeat.tscn")


func _on_niki_body_exited(body):
	if body.has_meta("isDroplet") && body.get_meta("isDroplet") == true:
		mpalakia+=1
		_update_label()
		body.queue_free()
		print(mpalakia)

func _update_label():
	label.text = "Drops: " + str(mpalakia) + "/300"
