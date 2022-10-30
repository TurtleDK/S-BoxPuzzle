using System;
using Sandbox;

[Library("ent_healthusable")]
public partial class HealthUsable : Prop, IUse
{
	private int code;
	private bool isResetBox;
	
	public HealthUsable(int codePress)
	{
		code = codePress;
	}
	
	public HealthUsable(bool reset)
	{
		isResetBox = reset;
	}
	
	public override void Spawn()
	{
		base.Spawn();
		
		SetModel( "models/citizen_props/crate01.vmdl_c" );
		base.RenderColor = Color.Blue;
		SetupPhysicsFromModel( PhysicsMotionType.Static, false );
	}

	public bool OnUse( Entity user )
	{
		if ( user is not Player ) return false;

		if ( isResetBox )
		{
			Array.Clear( CodeManager.writtenCode );
			
			CodeManager.WrittenCode();
			
			return false;
		}
		if ( !isResetBox && code == 0 )
		{
			if ( CodeManager.IsCodeCorrect() )
			{
				Log.Info( "Rigtig kode" );
			}
			else
			{
				Log.Info( "Forkert kode" );
			}
		}

		for ( int i = 0; i < CodeManager.writtenCode.Length; i++ )
		{
			if ( CodeManager.writtenCode[i] == 0 )
			{
				CodeManager.writtenCode[i] = code;
				
				break;
			}
		}

		CodeManager.WrittenCode();

		//Delete(); //Slette objektet
		
		return false;
	}

	public bool IsUsable( Entity user )
	{
		return user is Player; //&& plr.Health < 1000;
	}
}
