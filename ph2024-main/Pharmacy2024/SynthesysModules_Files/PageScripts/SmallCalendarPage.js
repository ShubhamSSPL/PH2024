  
    
function dateDiff(date1,date2) {
		return Math.round((date2.getTime() - date1.getTime()) / 1000);
	};	
function showCalendar()
{	    

document.getElementById('CalendarView').style.display='';
document.getElementById('TableView').style.display='none';
$(document).ready(function(){	

	var clickDate = "";
	var clickAgendaItem = "";
	
	
	/**
	 * Initializes calendar with current year & month
	 * specifies the callbacks for day click & agenda item click events
	 * then returns instance of plugin object
	 */
	if(hddFlag=="1")
	{
	    var jfcalplugin = $("#mycal").jFrontierCal({
		    date: new Date(),
    		
		    agendaClickCallback: myAgendaClickHandler,
		    agendaDropCallback: myAgendaDropHandler,
		    agendaMouseoverCallback: myAgendaMouseoverHandler,
		    applyAgendaTooltipCallback: myApplyTooltip,
		    agendaDragStartCallback : myAgendaDragStart,
		    agendaDragStopCallback : myAgendaDragStop,
		    dragAndDropEnabled: true
	    }).data("plugin");
    	
    	
	    //function renderCalendarEvents()
	    //{
	    
	      atk = new Synthesys.AjaxTimeKeeper(new Array(4,8,12),'mycal','<b>Fetching</b>', '../SynthesysModules_Files/Images/BigProgress.gif');
          atk.Start('AppForm_WelcomePage.RenderEvents',UserTypeId,RenderEvents_Callback);  
    				     
	    //}
	}
	function RenderEvents_Callback(response)
	{
	  atk.Stop();
	  
	  var ds=response.value;
	  var todaysEvents='<b>Today\'s Events:</b>';
      if(ds.Tables[0].Rows.length>0)
      {
         for(var i=0;i<response.value.Tables[0].Rows.length;i++)
         {
            eventId=ds.Tables[0].Rows[i].EventId;
            var dtAndTime = ds.Tables[0].Rows[i].stDT.split(" ");
            var dtArray=dtAndTime[0].split("-");
            var time=dtAndTime[1].split(":");
            var sdt=new Date(Number(dtArray[0]),Number(dtArray[1])-1,Number(dtArray[2]),time[0],time[1],0,0);
//            if(dtArray[2]=="15") {alert('a'); 
//            
//            }
            dtAndTime = ds.Tables[0].Rows[i].endDT.split(" ");
            dtArray=dtAndTime[0].split("-");
            time=dtAndTime[1].split(":");       
		    var endDT=new Date(Number(dtArray[0]),Number(dtArray[1])-1,Number(dtArray[2]),time[0],time[1],0,0);
            if(dateDiff(sdt,new Date()) > 0 && dateDiff(new Date(),endDT)>0)
            todaysEvents+=ds.Tables[0].Rows[i].what+';';
            // add new event to the calendar
					    jfcalplugin.addAgendaItem(
						    "#mycal",
						    ds.Tables[0].Rows[i].what,
						    sdt,
						    endDT,
						    ds.Tables[0].Rows[i].AllDayEvent,
						    {
							    
						    },
						    {
							    backgroundColor: ds.Tables[0].Rows[i].backGroundColor,
							    foregroundColor: ds.Tables[0].Rows[i].foreGroundColor
						    }
					  );
    	 }
       }
       
       document.getElementById('panel7marquee').innerHTML=todaysEvents;
	}
	
	/**
	 * Do something when dragging starts on agenda div
	 */
	function myAgendaDragStart(eventObj,divElm,agendaItem){
		// destroy our qtip tooltip
		if(divElm.data("qtip")){
			divElm.qtip("destroy");
		}	
	};
	
	/**
	 * Do something when dragging stops on agenda div
	 */
	function myAgendaDragStop(eventObj,divElm,agendaItem){
		//alert("drag stop");
	};
	
	/**
	 * Custom tooltip - use any tooltip library you want to display the agenda data.
	 * for this example we use qTip - http://craigsworks.com/projects/qtip/
	 *
	 * @param divElm - jquery object for agenda div element
	 * @param agendaItem - javascript object containing agenda data.
	 */
	function myApplyTooltip(divElm,agendaItem){

		// Destroy currrent tooltip if present
		if(divElm.data("qtip")){
			divElm.qtip("destroy");
		}
		
		var displayData = "";
		
		var title = agendaItem.title;
		var startDate = agendaItem.startDate;
		var endDate = agendaItem.endDate;
		var allDay = agendaItem.allDay;
		var data = agendaItem.data;
		displayData += "<br><b>" + title+ "</b><br><br>";
		if(allDay){
			displayData += "(All day event)<br><br>";
		}else{
			displayData += "<b>Starts:</b> " + startDate + "<br>" + "<b>Ends:</b> " + endDate + "<br><br>";
		}
		for (var propertyName in data) {
			displayData += "<b>" + propertyName + ":</b> " + data[propertyName] + "<br>"
		}
		// use the user specified colors from the agenda item.
		var backgroundColor = agendaItem.displayProp.backgroundColor;
		var foregroundColor = agendaItem.displayProp.foregroundColor;
		var myStyle = {
			border: {
				width: 5,
				radius: 10
			},
			padding: 10, 
			textAlign: "left",
			tip: true,
			name: "dark" // other style properties are inherited from dark theme		
		};
		if(backgroundColor != null && backgroundColor != ""){
			myStyle["backgroundColor"] = backgroundColor;
		}
		if(foregroundColor != null && foregroundColor != ""){
			myStyle["color"] = foregroundColor;
		}
		// apply tooltip
		divElm.qtip({
			content: displayData,
			position: {
				corner: {
					tooltip: "bottomMiddle",
					target: "topMiddle"			
				},
				adjust: { 
					mouse: true,
					x: 0,
					y: -15
				},
				target: "mouse"
			},
			show: { 
				when: { 
					event: 'mouseover'
				}
			},
			style: myStyle
		});

	};

	/**
	 * Make the day cells roughly 3/4th as tall as they are wide. this makes our calendar wider than it is tall. 
	 */
	 if(hddFlag=="1")
	jfcalplugin.setAspectRatio("#mycal",0.75);

	/**
	 * Called when user clicks day cell
	 * use reference to plugin object to add agenda item
	 */
	function myDayClickHandler(eventObj){
		// Get the Date of the day that was clicked from the event object
		var date = eventObj.data.calDayDate;
		// store date in our global js variable for access later
		clickDate = date.getFullYear() + "-" + (date.getMonth()+1) + "-" + date.getDate();
		// open our add event dialog
		$('#add-event-form').dialog('open');
	};
	
	/**
	 * Called when user clicks and agenda item
	 * use reference to plugin object to edit agenda item
	 */
	function myAgendaClickHandler(eventObj){
	
		// Get ID of the agenda item from the event object
		var agendaId = eventObj.data.agendaId;		
		// pull agenda item from calendar
		var agendaItem = jfcalplugin.getAgendaItemById("#mycal",agendaId);
		clickAgendaItem = agendaItem;
		$("#display-event-form").dialog('open');
	};
	
	/**
	 * Called when user drops an agenda item into a day cell.
	 */
	function myAgendaDropHandler(eventObj){
	
		// Get ID of the agenda item from the event object
		var agendaId = eventObj.data.agendaId;
		// date agenda item was dropped onto
		var date = eventObj.data.calDayDate;
		// Pull agenda item from calendar
		var agendaItem = jfcalplugin.getAgendaItemById("#mycal",agendaId);		
//		alert("You dropped agenda item " + agendaItem.title + 
//			" onto " + date.toString() + ". Here is where you can make an AJAX call to update your database.");
		
		var s,e;
		s=parseInt(agendaItem.startDate.getMonth())+1+'/'+agendaItem.startDate.getDate()+'/'+agendaItem.startDate.getFullYear()+' '+agendaItem.startDate.getHours()+':'+agendaItem.startDate.getMinutes();
		e=parseInt(agendaItem.endDate.getMonth())+1+'/'+agendaItem.endDate.getDate()+'/'+agendaItem.endDate.getFullYear()+' '+agendaItem.endDate.getHours()+':'+agendaItem.endDate.getMinutes();
		
		atk = new Synthesys.AjaxTimeKeeper(new Array(4,8,12),'mycal','<b>Fetching</b>', 'BigProgress.gif');
        atk.Start('AppForm_WelcomePage.AddEditEvents',String(agendaItem.agendaId),agendaItem.title,String(agendaItem.allDay),agendaItem.displayProp.backgroundColor,agendaItem.displayProp.foregroundColor,s,e,EditEvents_Callback);  
				       	
	};
	function EditEvents_Callback(response)
	{
	  atk.Stop();
	}
	/**
	 * Called when a user mouses over an agenda item	
	 */
	function myAgendaMouseoverHandler(eventObj){
		var agendaId = eventObj.data.agendaId;
		var agendaItem = jfcalplugin.getAgendaItemById("#mycal",agendaId);
		//alert("You moused over agenda item " + agendaItem.title + " at location (X=" + eventObj.pageX + ", Y=" + eventObj.pageY + ")");
	};
	/**
	 * Initialize jquery ui datepicker. set date format to yyyy-mm-dd for easy parsing
	 */
	$("#dateSelect").datepicker({
		showOtherMonths: true,
		selectOtherMonths: true,
		changeMonth: true,
		changeYear: true,
		showButtonPanel: true,
		dateFormat: 'yy-mm-dd'
	});
	
	/**
	 * Set datepicker to current date
	 */
	$("#dateSelect").datepicker('setDate', new Date());
	/**
	 * Use reference to plugin object to a specific year/month
	 */
	$("#dateSelect").bind('change', function() {
		var selectedDate = $("#dateSelect").val();
		var dtArray = selectedDate.split("-");
		var year = dtArray[0];
		// jquery datepicker months start at 1 (1=January)		
		var month = dtArray[1];
		// strip any preceeding 0's		
		month = month.replace(/^[0]+/g,"")		
		var day = dtArray[2];
		// plugin uses 0-based months so we subtrac 1
		jfcalplugin.showMonth("#mycal",year,parseInt(month-1).toString());
	});	
	/**
	 * Initialize previous month button
	 */
	$("#ctl00_rightContainer_ContentTable1_BtnPreviousMonth").button();
	$("#ctl00_rightContainer_ContentTable1_BtnPreviousMonth").click(function() {
		jfcalplugin.showPreviousMonth("#mycal");
		// update the jqeury datepicker value
		var calDate = jfcalplugin.getCurrentDate("#mycal"); // returns Date object
		var cyear = calDate.getFullYear();
		// Date month 0-based (0=January)
		var cmonth = calDate.getMonth();
		var cday = calDate.getDate();
		// jquery datepicker month starts at 1 (1=January) so we add 1
		$("#dateSelect").datepicker("setDate",cyear+"-"+(cmonth+1)+"-"+cday);
		return false;
	});
	/**
	 * Initialize next month button
	 */
	$("#ctl00_rightContainer_ContentTable1_BtnNextMonth").button();
	$("#ctl00_rightContainer_ContentTable1_BtnNextMonth").click(function() {
		jfcalplugin.showNextMonth("#mycal");
		// update the jqeury datepicker value
		var calDate = jfcalplugin.getCurrentDate("#mycal"); // returns Date object
		var cyear = calDate.getFullYear();
		// Date month 0-based (0=January)
		var cmonth = calDate.getMonth();
		var cday = calDate.getDate();
		// jquery datepicker month starts at 1 (1=January) so we add 1
		$("#dateSelect").datepicker("setDate",cyear+"-"+(cmonth+1)+"-"+cday);		
		return false;
	});
	
	/**
	 * Initialize delete all agenda items button
	 */
	$("#BtnDeleteAll").button();
	$("#BtnDeleteAll").click(function() {	
		jfcalplugin.deleteAllAgendaItems("#mycal");	
		atk = new Synthesys.AjaxTimeKeeper(new Array(4,8,12),'mycal','<b>Fetching</b>', 'BigProgress.gif');
        atk.Start('AppForm_WelcomePage.DeleteEvents','0','All',DeleteEvents_Callback); 
		return false;
	});		
	
	/**
	 * Initialize iCal test button
	 */
	$("#BtnICalTest").button();
	$("#BtnICalTest").click(function() {
		// Please note that in Google Chrome this will not work with a local file. Chrome prevents AJAX calls
		// from reading local files on disk.		
		jfcalplugin.loadICalSource("#mycal",$("#iCalSource").val(),"html");	
		return false;
	});	

	/**
	 * Initialize add event modal form
	 */
	$("#add-event-form").dialog({
		autoOpen: false,
		height: 400,
		width: 400,
		modal: true,
		buttons: {
			'Add Event': function() {

				var what = jQuery.trim($("#what").val());
			    whatTitle=what;
				if(what == ""){
					alert("Please enter a short event description into the \"what\" field.");
				}else{
				
					var startDate = $("#startDate").val();
					var startDtArray = startDate.split("-");
					var startYear = startDtArray[0];
					// jquery datepicker months start at 1 (1=January)		
					var startMonth = startDtArray[1];		
					var startDay = startDtArray[2];
					// strip any preceeding 0's		
					startMonth = startMonth.replace(/^[0]+/g,"");
					startDay = startDay.replace(/^[0]+/g,"");
					var startHour = jQuery.trim($("#startHour").val());
					var startMin = jQuery.trim($("#startMin").val());
					var startMeridiem = jQuery.trim($("#startMeridiem").val());
					startHour = parseInt(startHour.replace(/^[0]+/g,""));
					if(startMin == "0" || startMin == "00"){
						startMin = 0;
					}else{
						startMin = parseInt(startMin.replace(/^[0]+/g,""));
					}
					if(startMeridiem == "AM" && startHour == 12){
						startHour = 0;
					}else if(startMeridiem == "PM" && startHour < 12){
						startHour = parseInt(startHour) + 12;
					}

					var endDate = $("#endDate").val();
					var endDtArray = endDate.split("-");
					var endYear = endDtArray[0];
					// jquery datepicker months start at 1 (1=January)		
					var endMonth = endDtArray[1];		
					var endDay = endDtArray[2];
					// strip any preceeding 0's		
					endMonth = endMonth.replace(/^[0]+/g,"");

					endDay = endDay.replace(/^[0]+/g,"");
					var endHour = jQuery.trim($("#endHour").val());
					var endMin = jQuery.trim($("#endMin").val());
					var endMeridiem = jQuery.trim($("#endMeridiem").val());
					endHour = parseInt(endHour.replace(/^[0]+/g,""));
					if(endMin == "0" || endMin == "00"){
						endMin = 0;
					}else{
						endMin = parseInt(endMin.replace(/^[0]+/g,""));
					}
					if(endMeridiem == "AM" && endHour == 12){
						endHour = 0;
					}else if(endMeridiem == "PM" && endHour < 12){
						endHour = parseInt(endHour) + 12;
					}
					
					//alert("Start time: " + startHour + ":" + startMin + " " + startMeridiem + ", End time: " + endHour + ":" + endMin + " " + endMeridiem);

					// Dates use integers
					stDT = new Date(parseInt(startYear),parseInt(startMonth)-1,parseInt(startDay),startHour,startMin,0,0);
					endDT = new Date(parseInt(endYear),parseInt(endMonth)-1,parseInt(endDay),endHour,endMin,0,0);

                    var s,e;
                    s=startMonth+'/'+startDay+'/'+startYear+' '+startHour+':'+startMin;
                    e=endMonth+'/'+endDay+'/'+endYear+' '+endHour+':'+endMin;
                    if(dateDiff(stDT,endDT) < 0){
					    alert("Sorry, you can't create an event that ends before it starts");
					} 
				    else{
                        atk = new Synthesys.AjaxTimeKeeper(new Array(4,8,12),'mycal','<b>Fetching</b>', 'BigProgress.gif');
                        atk.Start('AppForm_WelcomePage.AddEditEvents','',what,'false',$("#colorBackground").val(),$("#colorForeground").val(),s,e,AddEditEvents_Callback);  
				        $(this).dialog('close');
                    }
				}
				
			},
			Cancel: function() {
				$(this).dialog('close');
			}
			
		},
		open: function(event, ui){
			// initialize start date picker
			$("#startDate").datepicker({
				showOtherMonths: true,
				selectOtherMonths: true,
				changeMonth: true,
				changeYear: true,
				showButtonPanel: true,
				dateFormat: 'yy-mm-dd'
			});
			// initialize end date picker
			$("#endDate").datepicker({
				showOtherMonths: true,
				selectOtherMonths: true,
				changeMonth: true,
				changeYear: true,
				showButtonPanel: true,
				dateFormat: 'yy-mm-dd'
			});
			// initialize with the date that was clicked
			$("#startDate").val(clickDate);
			$("#endDate").val(clickDate);
			// initialize color pickers
			$("#colorSelectorBackground").ColorPicker({
				color: "#333333",
				onShow: function (colpkr) {
					$(colpkr).css("z-index","10000");
					$(colpkr).fadeIn(500);
					return false;
				},
				onHide: function (colpkr) {
					$(colpkr).fadeOut(500);
					return false;
				},
				onChange: function (hsb, hex, rgb) {
					$("#colorSelectorBackground div").css("backgroundColor", "#" + hex);
					$("#colorBackground").val("#" + hex);
				}
			});
			//$("#colorBackground").val("#1040b0");		
			$("#colorSelectorForeground").ColorPicker({
				color: "#ffffff",
				onShow: function (colpkr) {
					$(colpkr).css("z-index","10000");
					$(colpkr).fadeIn(500);
					return false;
				},
				onHide: function (colpkr) {
					$(colpkr).fadeOut(500);
					return false;
				},
				onChange: function (hsb, hex, rgb) {
					$("#colorSelectorForeground div").css("backgroundColor", "#" + hex);
					$("#colorForeground").val("#" + hex);
				}
			});
			//$("#colorForeground").val("#ffffff");				
			// put focus on first form input element
			$("#what").focus();
		},
		close: function() {
			// reset form elements when we close so they are fresh when the dialog is opened again.
			$("#startDate").datepicker("destroy");
			$("#endDate").datepicker("destroy");
			$("#startDate").val("");
			$("#endDate").val("");
			$("#startHour option:eq(0)").attr("selected", "selected");
			$("#startMin option:eq(0)").attr("selected", "selected");
			$("#startMeridiem option:eq(0)").attr("selected", "selected");
			$("#endHour option:eq(0)").attr("selected", "selected");
			$("#endMin option:eq(0)").attr("selected", "selected");
			$("#endMeridiem option:eq(0)").attr("selected", "selected");			
			$("#what").val("");
			//$("#colorBackground").val("#1040b0");
			//$("#colorForeground").val("#ffffff");
		}
	});
	/**
	 * Initialize edit event modal form
	 */
	$("#display-event-form-edit").dialog({
		autoOpen: false,
		height: 400,
		width: 400,
		modal: true,
		buttons: {
			'Edit Event': function() {

				var what = jQuery.trim($("#whatE").val());
			    whatTitle=what;
				if(what == ""){
					alert("Please enter a short event description into the \"what\" field.");
				}else{
				
					var startDate = $("#startDateE").val();
					var startDtArray = startDate.split("-");
					var startYear = startDtArray[0];
					// jquery datepicker months start at 1 (1=January)		
					var startMonth = startDtArray[1];		
					var startDay = startDtArray[2];
					// strip any preceeding 0's		
					startMonth = startMonth.replace(/^[0]+/g,"");
					startDay = startDay.replace(/^[0]+/g,"");
					var startHour = jQuery.trim($("#startHourE").val());
					var startMin = jQuery.trim($("#startMinE").val());
					var startMeridiem = jQuery.trim($("#startMeridiemE").val());
					startHour = parseInt(startHour.replace(/^[0]+/g,""));
					if(startMin == "0" || startMin == "00"){
						startMin = 0;
					}else{
						startMin = parseInt(startMin.replace(/^[0]+/g,""));
					}
					if(startMeridiem == "AM" && startHour == 12){
						startHour = 0;
					}else if(startMeridiem == "PM" && startHour < 12){
						startHour = parseInt(startHour) + 12;
					}

					var endDate = $("#endDateE").val();
					var endDtArray = endDate.split("-");
					var endYear = endDtArray[0];
					// jquery datepicker months start at 1 (1=January)		
					var endMonth = endDtArray[1];		
					var endDay = endDtArray[2];
					// strip any preceeding 0's		
					endMonth = endMonth.replace(/^[0]+/g,"");

					endDay = endDay.replace(/^[0]+/g,"");
					var endHour = jQuery.trim($("#endHourE").val());
					var endMin = jQuery.trim($("#endMinE").val());
					var endMeridiem = jQuery.trim($("#endMeridiemE").val());
					endHour = parseInt(endHour.replace(/^[0]+/g,""));
					if(endMin == "0" || endMin == "00"){
						endMin = 0;
					}else{
						endMin = parseInt(endMin.replace(/^[0]+/g,""));
					}
					if(endMeridiem == "AM" && endHour == 12){
						endHour = 0;
					}else if(endMeridiem == "PM" && endHour < 12){
						endHour = parseInt(endHour) + 12;
					}
					
					//alert("Start time: " + startHour + ":" + startMin + " " + startMeridiem + ", End time: " + endHour + ":" + endMin + " " + endMeridiem);

					// Dates use integers
					stDT = new Date(parseInt(startYear),parseInt(startMonth)-1,parseInt(startDay),startHour,startMin,0,0);
					endDT = new Date(parseInt(endYear),parseInt(endMonth)-1,parseInt(endDay),endHour,endMin,0,0);

                    var s,e;
                    s=startMonth+'/'+startDay+'/'+startYear+' '+startHour+':'+startMin;
                    e=endMonth+'/'+endDay+'/'+endYear+' '+endHour+':'+endMin;
                    if(dateDiff(stDT,endDT) < 0){
					    alert("Sorry, you can't create an event that ends before it starts");
					} 
				    else{
				   
				        jfcalplugin.deleteAgendaItemById("#mycal",clickAgendaItem.agendaId);
						eventId=clickAgendaItem.agendaId;
                        atk = new Synthesys.AjaxTimeKeeper(new Array(4,8,12),'mycal','<b>Fetching</b>', 'BigProgress.gif');
                        atk.Start('AppForm_WelcomePage.AddEditEvents',String(eventId),what,'false',$("#colorBackgroundE").val(),$("#colorForegroundE").val(),s,e,EditEvents_Callback);  
				        jfcalplugin.addAgendaItem(
						    "#mycal",
						    what,
						    stDT,
						    endDT,
						    false,
						    {
							    
						    },
						    {
							    backgroundColor: $("#colorBackgroundE").val(),
							    foregroundColor: $("#colorForegroundE").val()
						    }
					  );
				        
        
				        
				        $(this).dialog('close');
                    }
				}
				
			},
			Cancel: function() {
				$(this).dialog('close');
			}
			
		},
		open: function(event, ui){
			// initialize start date picker
			$("#startDateE").datepicker({
				showOtherMonths: true,
				selectOtherMonths: true,
				changeMonth: true,
				changeYear: true,
				showButtonPanel: true,
				dateFormat: 'yy-mm-dd'
			});
			// initialize end date picker
			$("#endDateE").datepicker({
				showOtherMonths: true,
				selectOtherMonths: true,
				changeMonth: true,
				changeYear: true,
				showButtonPanel: true,
				dateFormat: 'yy-mm-dd'
			});
			// initialize with the date that was clicked
			$("#startDateE").val(clickDate);
			$("#endDateE").val(clickDate);
			// initialize color pickers
			$("#colorSelectorBackgroundE").ColorPicker({
				color: "#333333",
				onShow: function (colpkr) {
					$(colpkr).css("z-index","10000");
					$(colpkr).fadeIn(500);
					return false;
				},
				onHide: function (colpkr) {
					$(colpkr).fadeOut(500);
					return false;
				},
				onChange: function (hsb, hex, rgb) {
					$("#colorSelectorBackgroundE div").css("backgroundColor", "#" + hex);
					$("#colorBackgroundE").val("#" + hex);
				}
			});
			//$("#colorBackground").val("#1040b0");		
			$("#colorSelectorForegroundE").ColorPicker({
				color: "#ffffff",
				onShow: function (colpkr) {
					$(colpkr).css("z-index","10000");
					$(colpkr).fadeIn(500);
					return false;
				},
				onHide: function (colpkr) {
					$(colpkr).fadeOut(500);
					return false;
				},
				onChange: function (hsb, hex, rgb) {
					$("#colorSelectorForegroundE div").css("backgroundColor", "#" + hex);
					$("#colorForeground").val("#" + hex);
				}
			});
			//$("#colorForeground").val("#ffffff");				
			// put focus on first form input element
			$("#whatE").focus();
		},
		close: function() {
			// reset form elements when we close so they are fresh when the dialog is opened again.
			$("#startDateE").datepicker("destroy");
			$("#endDateE").datepicker("destroy");
			$("#startDateE").val("");
			$("#endDateE").val("");
			$("#startHourE option:eq(0)").attr("selected", "selected");
			$("#startMinE option:eq(0)").attr("selected", "selected");
			$("#startMeridiemE option:eq(0)").attr("selected", "selected");
			$("#endHourE option:eq(0)").attr("selected", "selected");
			$("#endMinE option:eq(0)").attr("selected", "selected");
			$("#endMeridiemE option:eq(0)").attr("selected", "selected");			
			$("#whatE").val("");
			//$("#colorBackground").val("#1040b0");
			//$("#colorForeground").val("#ffffff");
		}
	});
	
	/**
	 * Initialize display event form.
	 */
	$("#display-event-form").dialog({
		autoOpen: false,
		height: 400,
		width: 400,
		modal: true,
		buttons: {		
			Cancel: function() {
				$(this).dialog('close');
			}
			
						
		},
		open: function(event, ui){
			if(clickAgendaItem != null){
				var title = clickAgendaItem.title;
				var startDate = clickAgendaItem.startDate;
				var endDate = clickAgendaItem.endDate;
				var allDay = clickAgendaItem.allDay;
				var data = clickAgendaItem.data;
				// in our example add agenda modal form we put some fake data in the agenda data. we can retrieve it here.
				$("#display-event-form").append(
					"<br><b>" + title+ "</b><br><br>"		
				);				
				if(allDay){
					$("#display-event-form").append(
						"(All day event)<br><br>"				
					);				
				}else{
					$("#display-event-form").append(
						"<b>Starts:</b> " + startDate + "<br>" +
						"<b>Ends:</b> " + endDate + "<br><br>"				
					);				
				}
				for (var propertyName in data) {
					$("#display-event-form").append("<b>" + propertyName + ":</b> " + data[propertyName] + "<br>");
				}			
			}		
		},
		close: function() {
			// clear agenda data
			$("#display-event-form").html("");
		}
	});	 

	/**
	 * Initialize our tabs
	 */
	$("#tabs").tabs({
		/*
		 * Our calendar is initialized in a closed tab so we need to resize it when the example tab opens.
		 */
		show: function(event, ui){
			if(ui.index == 1){
				jfcalplugin.doResize("#mycal");
			}
		}	
	});
	function DeleteEvents_Callback(response)
	{
	  atk.Stop();
	  
	}
	function AddEditEvents_Callback(response)
    {
      atk.Stop();
      var ds=response.value;
      
      if(ds.Tables[0].Rows.length>0)
      {
         eventId=ds.Tables[0].Rows[0].eventId;
         // add new event to the calendar
					    jfcalplugin.addAgendaItem(
						    "#mycal",
						    whatTitle,
						    stDT,
						    endDT,
						    false,
						    {
							   
						    },
						    {
							    backgroundColor: $("#colorBackground").val(),
							    foregroundColor: $("#colorForeground").val()
						    }
					  );
     }		
   }
});
}		

