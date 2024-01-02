using Godot;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

public partial class Library : Resource {
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
		}
	};
}
