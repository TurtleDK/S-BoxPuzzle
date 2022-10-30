using Sandbox;

partial class MyPlayer: Player
{
	private ClothingContainer clothing = new();

	public MyPlayer()
	{
		//Inventory = new Inventory(this);
	}
	
	public override void Respawn()
	{
		SetModel( "models/citizen/citizen.vmdl");
		clothing.LoadFromClient( Client );
		clothing.DressEntity( this );
		
		Controller = new WalkController();
		Animator = new StandardPlayerAnimator();
		CameraMode = new ThirdPersonCamera();

		EnableDrawing = true;
		EnableAllCollisions = true;
		EnableHideInFirstPerson = true;
		EnableShadowInFirstPerson = true;
		
		//Get asset from map (FindByName(AssetName))

		//Inventory.Add( new Fists(), true);

		base.Respawn();
		
		Log.Info( "Client spawned" );
	}

	public override void Simulate( Client cl )
	{
		base.Simulate( cl );
		
		TickPlayerUse();
		
		if (Input.Pressed( InputButton.View ))
			if ( CameraMode is ThirdPersonCamera )
			{
				CameraMode = new FirstPersonCamera();
			}
			else
			{
				CameraMode = new ThirdPersonCamera();
			}
	}
}
