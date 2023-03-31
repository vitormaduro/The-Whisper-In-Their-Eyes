using System;
using Godot;

public partial class GalleryButton : Node
{
	public long TabId { get; set; }
	public TextureButton Button { get; set; }
	public Action Action { get; set; }
}