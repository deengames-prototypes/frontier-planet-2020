extends Area2D

func _on_body_entered(body):
	if body.name == "MapPlayer":
		Globals.player_inventory.append(self.name.to_lower())
		self.get_parent().remove_child(self)
		self.queue_free()
