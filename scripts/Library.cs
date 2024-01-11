using Godot;
using System;
using System.Collections.Generic;

public partial class Library : Resource {
	public PackedScene godotIcon = GD.Load<PackedScene>("res://scenes/Cards/godot_card.tscn");
	public int fuckmonkey = 0;
	public static Dictionary<string, Func<Card>> cards = new Dictionary<string, Func<Card>> {
		{"punch", () => {
			return new Card {
				mesh = new MeshInstance3D{
					MaterialOverlay = new StandardMaterial3D{
						AlbedoColor = new Color(0.5f, 0, 0)
					}
				},
				passive = () => {
					// GD.Print("I'm punching, go fuck yourself");
				},
				cast = (Battle battle, Character caster) => {
					int damage = 1;
					GD.Print("punching for ", damage.ToString(), "!");
					Character targetFoe = caster.findFoe();
					targetFoe.healthPool.useCards(targetFoe, damage);
				}
			};
		}}, { "mend", () => {
				return new Card {
					mesh = new MeshInstance3D{
						MaterialOverlay = new StandardMaterial3D{
							AlbedoColor = new Color(0, 0.5f, 0)
						}
					},
					cast = (Battle battle, Character caster) =>
					{
						caster.healthPool.addCardType("health", 1);
						// GD.Print("mending");
					}
				};
			}
		}, { "health", () => {
				return new Card {
					mesh = new MeshInstance3D{
						MaterialOverlay = new StandardMaterial3D{
							AlbedoColor = new Color(255, 0, 0)
						}
					},
					cast = (Battle battle, Character caster) =>
					{
						GD.Print("being cast from the health pool");
					}
				};
			}
		}, { "godot", () => {
				MeshInstance3D icon = (MeshInstance3D)GD.Load<PackedScene>("res://scenes/Cards/godot_card.tscn").Instantiate();
				return new Card {
					mesh = icon,
					cast = (Battle battle, Character caster) =>
					{
						// caster.healthPool.addCardType("health", 3);
						GD.Print("being cast from the health pool");
					}
				};
			}
		}
	};
}
