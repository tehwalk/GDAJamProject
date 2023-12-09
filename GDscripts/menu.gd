extends Control


# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass


func _on_exit_pressed():
	$Panel.visible=false
	$PanelShadow.visible=false
	
	$"Start Shadow".visible=true
	$"Credits Shadow".visible=true
	$"Title Shadow".visible=true
	$Title.visible=true
	$ColorRect2.visible=true
	$ColorRect3.visible=true
	$Start.visible=true
	$Credits.visible=true


func _on_credits_pressed():
	$Panel.visible=true
	$PanelShadow.visible=true
	
	$"Start Shadow".visible=false
	$"Credits Shadow".visible=false
	$"Title Shadow".visible=false
	$Title.visible=false
	$ColorRect2.visible=false
	$ColorRect3.visible=false
	$Start.visible=false
	$Credits.visible=false


func _on_start_pressed():
	get_tree().change_scene_to_file("res://Scenes/main_scene.tscn")
