// ==UserScript==
// @name 		Include jQuery (3.5.1) script if not already present
// @namespace	My Scripts
// @grant		none
// @require		https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js
// @include		*
// ==/UserScript==


// a function that loads jQuery and calls a callback function when jQuery has finished loading
function addJQuery(callback) {
  if($ && $.fn.jquery) {
    setNoConflict(callback);
  }
  else {
  	var script = document.createElement("script");
  	script.setAttribute("src", "https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js");  // <-------------------------------
  	script.addEventListener('load', function() {
    	setNoConflict(callback);
    }, false);
  	document.body.appendChild(script);
  }
}

// a function to initialize jquery using custom variable *jQ*
function setNoConflict(callback) {
  var script = document.createElement("script");
  script.textContent = "window.jQ = jQuery.noConflict(true); (" + callback.toString() + ")();";
  document.body.appendChild(script);
}

// the guts of this userscript
function main() {
  // Note, jQ replaces $ to avoid conflicts.
  // Call any other scripts that use jquery and needs to be executed in all pages
  
}

// load jQuery and execute the main function
addJQuery(main);