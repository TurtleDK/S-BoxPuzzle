using Sandbox;
using Sandbox.UI.Construct;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

partial class MyPlayer: Player
{
	private TimeSince timeSinceDropped;
	private TimeSince timeSinceJumpReleased;

	private DamageInfo lastDamage;
	
	public ClothingContainer Clothing = new();
	
	
	public MyPlayer()
	{
		Inventory = new Inventory( this );
	}
	
	public override void Respawn()
	{
		// Sætter model af spiller, og siger den skal tage deres tøj på
		SetModel( "models/citizen/citizen.vmdl");
		Clothing.LoadFromClient( Client );
		Clothing.DressEntity( this );

		// Gør at spiller faktisk virker, til at gå rundt, animeret, og kamera sættes op
		Controller = new WalkController();
		Animator = new StandardPlayerAnimator();
		CameraMode = new ThirdPersonCamera();
		
		// typiske regler som kan være true eller false.
		EnableDrawing = true;
		EnableAllCollisions = true;
		EnableHideInFirstPerson = true;
		EnableShadowInFirstPerson = true;
		
		Inventory.Add( new Pistol(), true );
		
		base.Respawn();
	}
}
