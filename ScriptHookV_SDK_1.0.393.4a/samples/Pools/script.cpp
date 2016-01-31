/*
	THIS FILE IS A PART OF GTA V SCRIPT HOOK SDK
				http://dev-c.com			
			(C) Alexander Blade 2015
*/

#include "script.h"
#include <vector>



void main()
{		
	try
	{
		Player play = Player(PLAYER::PLAYER_ID);

		GRAPHICS::START_PARTICLE_FX_LOOPED_ON_ENTITY("scr_fbi4", (Entity)play, 0, 4, 0, 0, 0, 0, 5, false, false, false);
		STREAMING::REQUEST_NAMED_PTFX_ASSET("scr_fbi4");
		GRAPHICS::_SET_PTFX_ASSET_NEXT_CALL("scr_fbi4");
	}
	catch (...)
	{

	}
}

void ScriptMain()
{	
	main();
}
