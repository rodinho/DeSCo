<?php

/*
 * Example PHP implementation used for the REST 'create' interface.
 */

include( "browsers.php" );

// The REST example uses 'DELETE' for the input, so we need to get the 
// parameters being sent to us from php://input
parse_str( file_get_contents('php://input'), $args );

$editor
	->process($args)
	->json();

