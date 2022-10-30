using System;
using System.Collections.Generic;
using Sandbox;

public partial class CodeManager
{
	private static int[] code = new int[4];
	public static int[] writtenCode = new int[4];

	private static List<int> codesLeft = new ()
	{
		1,2,3,4
	};

	private static bool isSpawned;
	
	[ConCmd.Server( "Start" )]
	public static void StartGame()
	{
		Random rnd = new();
		for ( int i = 0; i < 4; i++ )
		{
			int randomInt = rnd.Next( 0, codesLeft.Count );
			code[i] = codesLeft[randomInt];
			codesLeft.RemoveAt( randomInt);
		}
		
		RealCode();
		
		if ( !isSpawned )
		{
			isSpawned = true;
			new HealthUsable( true ){Position = new Vector3( 0,0,130 )};
			new HealthUsable( 1 ){Position = new Vector3( 0,50,130 )};
			new HealthUsable( 2 ){Position = new Vector3( 0,100,130 )};
			new HealthUsable( 3 ){Position = new Vector3( 0,150,130 )};
			new HealthUsable( 4 ){Position = new Vector3( 0,200,130 )};
			new HealthUsable( false ){Position = new Vector3( 0,250,130 )};
		}
	}

	public static void WrittenCode()
	{
		Log.Info( $"Din kode: {writtenCode[0]}{writtenCode[1]}{writtenCode[2]}{writtenCode[3]}" );	
	}

	public static void RealCode()
	{
		Log.Info( $"Rigtig kode: {code[0]}{code[1]}{code[2]}{code[3]}" );	
	}

	public static bool IsCodeCorrect()
	{
		for ( int i = 0; i < 4; i++ )
		{
			if ( code[i] == writtenCode[i] )
			{
				continue;
			}
			
			RealCode();
			
			return false;
		}

		return true;
	}
}
