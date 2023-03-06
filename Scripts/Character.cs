using Godot;
using System.Collections.Generic;

public partial class Character : Node
{
	public string Id { get; set; }
	public Dictionary<string, Texture2D> Sprites { get; set; } = new Dictionary<string, Texture2D>();
}
