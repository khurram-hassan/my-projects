// ==UserScript==
// @name 		For TRAC
// @namespace 	My Scripts
// @grant 		none
// @require		https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js
// @include 	http://34.231.97.28:8444/*
// ==/UserScript==


function main() {
    addFontAwesomeAndRelatedCustomStyles();
    //if(jQ) {
    //  myStartFunction();
    //}
    //else {
      var script = document.createElement("script");
        script.setAttribute("src", "https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js");
        script.addEventListener('load', function() {
        var script1 = document.createElement("script");
        script1.textContent = "window.jQ = jQuery.noConflict(true);"; // (" + myStartFunction.toString() + ")();";
        document.body.appendChild(script1);
      }, false);
        document.body.appendChild(script);
      myStartFunction();
    //}
  }
  
  function addFontAwesomeAndRelatedCustomStyles() {
    //Font Awesome
    var link = document.createElement("link");
    link.setAttribute("href", "https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css");
    link.setAttribute("rel", "stylesheet")
    link.setAttribute("integrity", "sha384-wvfXpqpZZVQGK6TAh5PVlGOfQNHSoD2xbE+QkPxCAFlNEevoEH3Sl0sibVcOQVnN")
    link.setAttribute("crossorigin", "anonymous");
    document.body.appendChild(link);
    
    //Custom Style
    var myStyle = document.createElement("style");
    myStyle.textContent = `
      #customControls
      {
          position: fixed;
          top: 2px;
          right: 2px;
          width: 200px;
          height: 60px;
          text-align: center;
          border: 1px solid gray;
          border-radius: 3px;
          background-color: beige;
          opacity: 0.5;
          box-shadow: -1px 2px 8px 1px grey;
          transition: all 0.5s;
      }
  
      #customControls:hover
      {
          opacity: 1;
      }
  
      #customControls > div
      {
          display: inline-block;
          text-align: center;
          border: blue;
      }
  
      div.icon
      {
          padding: 5px;
          position: relative;
          cursor: pointer;
          transform: translateY(10px);
          transition: all 0.5s;
      }
  
      .icon:hover
      {
          transform: scale(1.2) translateY(0px);
      }
  
      *.display-block
      {
          display: block;
      }
  
      .blue
      {
          color: blue;
      }
  
      .green
      {
          color: green;
      }
    `;
    document.body.appendChild(myStyle);
  }
  
  function addCustomControls() {
    var customControls = `
      <div id="customControls">
        <div class="icon blue document-top">
          <i class="fa fa-arrow-up fa-2x display-block"></i> TOP
        </div>
        <div class="icon green document-bottom">
          <i class="fa fa-arrow-down fa-2x display-block"></i> BOTTOM
        </div>
        
      </div>
    `;
    jQ(customControls).appendTo("body");
  }
  
  function myStartFunction() {
    addCustomControls();
    
    //Bind Events
    //var lnkModifyTicket = jQ("#no3");
    jQ(document).on("click", "#no3", function () {
      jQ("#action_reassign_reassign_owner").val("twilliams");
    });
    
    jQ(document).on("click", "div.icon", function () {
      if(jQ(this).hasClass("document-top")) {
        jQ("html, body").animate({ scrollTop: 0 }, "slow");
      }
      if(jQ(this).hasClass("document-bottom")) {
        jQ("html, body").animate({ scrollTop: jQ(document).height() }, "slow");
      }
    });
  }
  
  
  main();