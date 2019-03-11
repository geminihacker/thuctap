function init()
{
	menus[0] = new menu(130, "vertical", 10, 10, -2, -2, "#CACAFF", "#0000A0", "Verdana,Helvetica", 9, 
		"bold", "bold", "black", "white", 1, "gray", 2, "rollover:images/tri-right1.gif:images/tri-right2.gif", false, true, true, true, 12, true, 4, 4, "black");
	menus[0].addItem("http://www.dynamicdrive.com", "", 22, "left", "Home", 0);
	menus[0].addItem("#", "", 22, "left", "Web Building", 1);
	menus[0].addItem("#", "", 22, "left", "News", 2);
	menus[0].addItem("#", "", 22, "left", "Search", 4);

//Sub Menu for 2nd Main Menu Item ("web building"):
	menus[1] = new menu(135, "vertical", 0, 0, -5, -5, "#CACAFF", "#0000A0", "Verdana,Helvetica", 9, "bold", 
		"bold", "black", "white", 1, "gray", 2, 62, false, true, false, true, 6, true, 4, 4, "black");
	menus[1].addItem("http://www.dynamicdrive.com", "", 22, "left", "Dynamic Drive", 0);
	menus[1].addItem("http://www.javascriptkit.com", "", 22, "left", "JavaScript Kit", 0);
	menus[1].addItem("http://www.codingforums.com", "", 22, "left", "Coding Forums", 0);
	menus[1].addItem("http://www.builder.com", "NEWWIN", 22, "left", "Builder.com", 0);

//Sub Menu for 3rd Main Menu Item ("News"):
	menus[2] = new menu(130, "vertical", 0, 0, 0, 0, "#CACAFF", "#0000A0", "Verdana,Helvetica", 9, "bold", 
		"bold", "black", "white", 1, "gray", 2, "rollover:images/tri-right1.gif:images/tri-right2.gif", false, true, false, false, 0, true, 4, 4, "black");
	menus[2].addItem("http://www.cnn.com", "", 22, "left", "CNN", 0);
	menus[2].addItem("http://www.msnbc.com", "", 22, "left", "MSNBC", 0);
	menus[2].addItem("http://news.bbc.co.uk", "", 22, "left", "BBC News", 0);
	menus[2].addItem("http://www.cbsnews.com", "", 22, "left", "Sports News", 3);

//Sub Menu for Sub Menu "Sports News":
	menus[3] = new menu(135, "vertical", 0, 0, 0, 0, "#E1E1E1", "black", "Verdana,Helvetica", 9, "bold", "bold", "black", "white", 1, "gray", 2, 62, false, true, false, false, 0, true, 4, 4, "black");
	menus[3].addItem("http://www.espn.com", "", 22, "left", "ESPN Sports", 0);
	menus[3].addItem("http://www.nba.com", "", 22, "left", "NBA", 0);

//Sub Menu for 4th Main Menu Item ("Search"):
	menus[4] = new menu(130, "vertical", 0, 0, 0, 0, "#CACAFF", "#0000A0", "Verdana,Helvetica", 9, "bold", "bold", "black", "white", 1, "gray", 2, ">>", false, true, false, false, 0, true, 4, 4, "black");
	menus[4].addItem("http://www.google.com", "", 22, "left", "Google", 0);
	menus[4].addItem("http://www.yahoo.com", "", 22, "left", "Yahoo", 0);
	menus[4].addItem("http://www.altavista.com", "", 22, "left", "AlltheWeb", 0);
	menus[4].addItem("http://www.teoma.com", "", 22, "left", "Teoma", 0);

} //OUTER CLOSING BRACKET. EVERYTHING ADDED MUST BE ABOVE THIS LINE.