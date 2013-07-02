///////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////
//       _____  _                       __  __          __               //
//      / ___/ (_)____ _ ____          / / / /____     / /_ ____         //
//      \__ \ / // __ `// __ \ ______ / / / // __ \   / __// __ \        //
//     ___/ // // /_/ // / / //_____// /_/ // /_/ /_ / /_ / /_/ /        //
//    /____//_/ \__, //_/ /_/        \____// .___/(_)\__/ \____/         //
//             /____/                     /_/                            //
//        ____                     __                                    //
//       / __ \ ___  _   __ ___   / /____   ____   ___   _____ _____     //
//      / / / // _ \| | / // _ \ / // __ \ / __ \ / _ \ / ___// ___/     //
//     / /_/ //  __/| |/ //  __// // /_/ // /_/ //  __// /   (__  )      //
//    /_____/ \___/ |___/ \___//_/ \____// .___/ \___//_/   /____/       //
//                                      /_/                              //
//                                                                       //
//                         ~~~~~~~~~~~~~~~~                              //
//                                                                       //
//          A client library for integrating with the Sign-Up.to         //
//           Permission Marketing API quickly and efficiently.           //
//                                                                       //
//                   Go to: https://dev.sign-up.to/                      //
//                                                                       //
///////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////////

## Installation

    $ npm install pmapi-client


## Example
```javascript
var pmapi				= require('pmapi-client'),
	PMAPIOptions		= {
		server				: 'xxx.xxx.xx',		// Optional - the domain for PMAPI requests
		version				: 1,				// Optional - the major version of PMAPI
		debugMode			: true				// Optional - log requests for debugging
	},
	RequestArguments	= {
		id					: 123,				// Optional - a resource attribute to filter by (GET)
		sort				: 'cdate'			// Optional - sort results by the 'cdate' attribute (GET)
	},
	RequestOptions		= {
		// Any valid options for the 'request' npm module (https://github.com/mikeal/request)
		// Please note: some required options may be over-witten by the PMAPI client library
	},
	Auth				= new pampi.auth.Hash(123, 456, "2b2d77e014a30792d5048e262e306783"),
	Request				= new pmapi.Request(Auth, PMAPIOptions);
	
 Request
 	.endpoint('list')
	.beforeSend(function(Response){
		// Do something
	})
	.success(function(Response){
		// Do something
	})
	.error(function(Response){
		// Do something
	})
	.complete(function(Response){
		// Response.get('status');
		// Response.get('headers');
		// Response.get('verb');

		if(Response.isError()){
			// Response.get('code');
			// Response.get('subcode');
			// Response.get('message');
		} else {
			// Response.get('data');
			// Response.get('count');
			// Response.get('next');
		}
	})
	.GET(RequestArguments, RequestOptions);
```